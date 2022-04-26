using System.Reflection.PortableExecutable;
using System.IO;
using System.Text.RegularExpressions;
using Api_Disney.Models;
using Api_Disney.Services;
using Api_Disney.ViewModels.CRUD.Characters;
using Microsoft.AspNetCore.Mvc;

namespace Api_Disney.Controllers;

[ApiController]
public class CharacterController : Controller
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        this._characterService = characterService;
    }

    // GENERIC REPOSITORY IMPLEMENTATION
    [HttpGet]
    [Route ("character/getAll")]
    public async Task<ActionResult> GetAllCharacters() => Ok(await _characterService.GetAll());

    // [HttpGet]
    // [Route ("characters")]
    // public async Task<IActionResult> GetQueryable()
    // {
    //     try
    //     {            
    //         var query = _characterService.GetQueryable()
    //                     .Select(c => new ListViewModel{name = c.Name, img_url = c.Image_url})
    //                     .ToList();
    //                     //.Select(c => new {c.Name, c.Image_url})
    //                     //.ToList(); 

    //         return query;
    //     }
    //     catch (System.Exception e)
    //     {
    //         throw new Exception(e.Message);
    //     }
    // }

    // GENERIC REPOSITORY IMPLEMENTATION
    [HttpGet]        
    [Route("search/byId")]
	public async Task<ActionResult> GetById(int id)
	{
		if(id == 0)
			return NotFound("Please, set an ID.");

        var user = await _characterService.GetById(id);
        return user != null ? Ok(user) : NotFound("User doesn't exists");
	}    

    // CREATE CHARACTER
    [HttpPost]       
    [Route("character/create")]
	public async Task<ActionResult> Create(CreateViewModel model)
	{     
        var exists = await _characterService.SingleOrDefaultAsync(m => m.Name == model.name);

        if (exists != null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                Status = "Error",
                Message = "The character already exists!"
            });
        }

        var character =  new Character
        {
            Image_url = model.image_url,
            Name = model.name,
            Age = model.age,
            Weight = model.weight,
            Story = model.story
        };

        if(ModelState.IsValid)
        {
            try
            {        
                if(string.IsNullOrEmpty(model.image_url))
                {                   
                    return Ok("Image not found");
                }
                if(string.IsNullOrEmpty(model.name))
                {
                    return Ok("Name required");                    
                }
                if(string.IsNullOrEmpty(model.story))
                {
                    return Ok("Story required");
                }

                await _characterService.Insert(character);
            }
            catch (System.Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }     
                
        return Ok(new 
        {
            Status = "Success",
			Message = "Character creation successfully!"
        });   
             
	}

    // UPDATE CHARACTER
    [HttpPut]       
    [Route("character/update")]
    public async Task<ActionResult> Edit(UpdateViewModel model)
    {
        //var match2 = await _characterService.GetById(model.id);
        var match = _characterService.GetQueryable().FirstOrDefault(c => c.CharacterID == model.id);

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
                match.Name = model.name;
                match.Age = model.age;
                match.Weight = model.weight;
                match.Story = model.story;

                if(string.IsNullOrEmpty(model.image_url))
                {                   
                    return Ok("Image not found");
                }
                if(string.IsNullOrEmpty(model.name))
                {
                    return Ok("Name required");                    
                }
                if(string.IsNullOrEmpty(model.story))
                {
                    return Ok("Story required");
                }

                //return Ok("Se ejecuto esto");
			    await _characterService.Update(match);
            }
            catch (System.Exception ex)
            {                
                throw new Exception(ex.Message);
            }
		}
		
        return Ok(new 
        {
            Status = "Success",
			Message = "Character updated successfully!"
        }); 
    }

    // DELETE CHARACTER
    [HttpDelete]       
    [Route("character/delete")]
    public async Task<ActionResult> Delete(int? id)
    {
        try
        {
            if(id == null)
                return NotFound();

            await _characterService.Delete(id.Value);

            return Ok(new 
            {
                Status = "Success",
                Message = "Character deleted successfully!"
            }); 
        }
        catch (Exception)
        {
            return NotFound("Character doesn't exists");
        }
    }
    
}
