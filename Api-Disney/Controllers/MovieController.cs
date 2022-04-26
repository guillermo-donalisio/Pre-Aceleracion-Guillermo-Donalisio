using Api_Disney.Services;
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
    [Route ("movie")]
    public async Task<ActionResult> GetAllUser() => Ok(await _movieService.GetAll());
}
