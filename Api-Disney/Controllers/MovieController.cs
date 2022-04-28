using System.Text.Json;
using Api_Disney.Models;
using Api_Disney.Services;
using Api_Disney.ViewModels.CRUD.Movie;
using Microsoft.AspNetCore.Mvc;

namespace Api_Disney.Controllers;

[ApiController]
public class MovieController : Controller
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        this._movieService = movieService;
    }

    [HttpGet]
    [Route ("movie/getAll")]
    public async Task<ActionResult> GetAllMovies() => Ok(await _movieService.GetAll());

    // CREATE CHARACTER
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
}
