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

    [HttpGet]
    [Route ("all/characters")]
    public async Task<ActionResult> GetAllCharacters() => Ok(await _characterService.GetAll());

    // [HttpGet]
    // [Route ("characters")]
    // public async Task<IActionResult> GetQueryable()
    // {
    //     try
    //     {
    //         var query = _characterService.GetQueryable()
    //                     .Select(c => new {c.Name, c.Image_url})
    //                     .ToList(); 

    //         return query;
    //     }
    //     catch (System.Exception e)
    //     {
    //         throw new Exception(e.Message);
    //     }
    // }


    [HttpGet]        
    [Route("search/byId")]
	public async Task<ActionResult> GetById(int id)
	{
		if(id == 0)
			return NotFound("Please, set an ID.");

        var user = await _characterService.GetById(id);
        return user != null ? Ok(user) : NotFound("User doesn't exists");
	}    

    [HttpPost]       
    [Route("create/character")]
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
			Message = "Character Creation Successfully!"
        });   
             
	}

    [HttpPut]       
    [Route("update/character/{id}")]
    public async Task<ActionResult> Edit(Character character)
    {
        if(ModelState.IsValid)
		{
			character = await _characterService.Update(character);
		}
		return Ok(character);
    }
    
    [HttpDelete]       
    [Route("delete/character/{id}")]
    public async Task<ActionResult> Delete(int? id)
    {
        try
        {
            if(id == null)
                return NotFound();

            await _characterService.Delete(id.Value);

            return Ok("User deleted successfully.");
        }
        catch (Exception)
        {
            return NotFound("User doesn't exists");
        }
    }
    
}
