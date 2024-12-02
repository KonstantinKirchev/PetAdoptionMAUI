namespace PetAdoption.API.Controllers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.API.Services.Interfaces;
using PetAdoption.Shared.Dtos;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserPetService _userPetService;

    public UserController(IUserPetService userPetService)
    {
        _userPetService = userPetService;
    }

    private int UserId => Convert.ToInt32(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

    // GET: api/user/adoptions
    [HttpGet("adoptions")]
    public async Task<ApiResponse<PetListDto[]>> GetUserAdoptionsAsync() =>
        await _userPetService.GetUserAdoptionsAsync(UserId);

    // GET: api/user/favorites
    [HttpGet("favorites")]
    public async Task<ApiResponse<PetListDto[]>> GetUserFavoritesAsync() =>
        await _userPetService.GetUserFavoritesAsync(UserId);

    // POST: api/user/favorites/1
    [HttpPost("favorites/{petId:int}")]
    public async Task<ApiResponse> ToggleFavoritesAsync(int petId) =>
        await _userPetService.ToggleFavoritesAsync(UserId, petId);

    // POST: api/user/adopt/1
    [HttpPost("adopt/{petId:int}")]
    public async Task<ApiResponse> AdoptPetAsync(int petId) =>
        await _userPetService.AdoptPetAsync(UserId, petId);
}


