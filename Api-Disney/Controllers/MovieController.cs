using Api_Disney.Models;
using Api_Disney.Services;
using Api_Disney.ViewModels.CRUD.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;


namespace Api_Disney.Controllers;

[ApiController]
[Authorize]
public class MovieController : Controller
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        this._movieService = movieService;
    }

    // GET CHARACTER NAME, IMAGE & DATE CREATION
    [HttpGet]
    [Route ("movies")]
    public async Task<IActionResult> GetMovieList()
    {
        try
        {           
            var query = _movieService.GetQueryable()
                        .Select(m => new ListMovieDTO{img_url = m.Image_url, title = m.Title, date = m.Date_creation})
                        .ToList();

            return Ok(query);
        }
        catch (System.Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    // GET MOVIE DETAILS
    [HttpGet]
    [Route ("movie/details")]
    public async Task<IActionResult> GetMovieDetails()
    {
        try
        {
            var query = _movieService.GetMovieDetails();
            return Ok(query);
        }
        catch (System.Exception e)
        {
            throw new Exception(e.Message);
        }
    } 

    // SEARCH MOVIE
    [HttpGet]        
    [Route("movie/byTitle")]
	public async Task<ActionResult> GetMovieByTitle([FromQuery] SearchMovieDTO model)
	{
        var exists2 = await _movieService.FirstOrDefaultAsync(m => m.Title.Contains(model.title));

        if (exists2 == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                Status = "Error",
                Message = "The movie doesn't exists!"
            });
        }
        
        try
        {
            var query = _movieService.GetMovieByTitle(model.title, model.genreId, model.orderBy);            
            return Ok(query);
        }
        catch (System.Exception ex)
        {            
            throw new Exception(ex.Message);
        }
	}

    // CREATE MOVIE
    [HttpPost]       
    [Route("movie/create")]
	public async Task<ActionResult> Create([FromBody] CreateMovieDTO model)
	{     
        var exists = await _movieService.SingleOrDefaultAsync(m => m.Title == model.title);

        if (exists != null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                Status = "Error",
                Message = "The character already exists!"
            });
        }

        var movie =  new Movie
        {
            Image_url = model.image_url,
            Title = model.title,
            Date_creation = model.date_creation,
            Rating = model.rating,
        };

        if(ModelState.IsValid)
        {
            try
            {        
                if(string.IsNullOrEmpty(model.image_url))
                {                   
                    return Ok("Image not found");
                }
                if(string.IsNullOrEmpty(model.title))
                {
                    return Ok("Name required");                    
                }

                await _movieService.Insert(movie);
            }
            catch (System.Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }     
                
        return Ok(new 
        {
            Status = "Success",
			Message = "Movie creation successfully!"
        });   
             
	}

    // UPDATE MOVIE
    [HttpPut]       
    [Route("movie/update")]
    public async Task<ActionResult> Edit(UpdateMovieDTO model)
    {
        var match = _movieService.GetQueryable().FirstOrDefault(c => c.MovieID == model.movieID);

        if (match == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                Status = "Error",
                Message = "Id number not found!"
            });
        }

        if(ModelState.IsValid)
		{
            try
            {
                match.Image_url = model.image_url;
                match.Title = model.title;
                match.Date_creation = model.date_creation;
                match.Rating = model.rating;

                if(string.IsNullOrEmpty(model.image_url))
                {                   
                    return Ok("Image not found");
                }
                if(string.IsNullOrEmpty(model.title))
                {
                    return Ok("Name required");                    
                }

			    await _movieService.Update(match);
            }
            catch (System.Exception ex)
            {                
                throw new Exception(ex.Message);
            }
		}
		
        return Ok(new 
        {
            Status = "Success",
			Message = "Movie updated successfully!"
        }); 
    }

    // DELETE MOVIE
    [HttpDelete]       
    [Route("movie/delete")]
    public async Task<ActionResult> Delete(int? id)
    {
        try
        {
            if(id == null)
                return NotFound();

            await _movieService.Delete(id.Value);

            return Ok(new 
            {
                Status = "Success",
                Message = "Movie deleted successfully!"
            }); 
        }
        catch (Exception)
        {
            return NotFound("Movie doesn't exists");
        }
    }
}
