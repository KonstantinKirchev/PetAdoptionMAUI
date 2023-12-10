using Microsoft.EntityFrameworkCore;
using PetAdoption.API.Data;
using PetAdoption.API.Services.Interfaces;
using PetAdoption.Shared.Dtos;
using PetAdoption.Shared.Models.EntityModels;

namespace PetAdoption.API.Services
{
	public class AuthService: IAuthService
    {
        private readonly PetContext _context;
        private readonly TokenService _tokenService;

        public AuthService(PetContext context, TokenService tokenService) 
		{
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(user => user.Email == dto.Email);

            if (dbUser is null)
                return ApiResponse<AuthResponseDto>.Fail("User does not exist");
            if (dbUser.Password != dto.Password)
                return ApiResponse<AuthResponseDto>.Fail("Incorrect password");

            var token = _tokenService.GenerateJWT(dbUser);

            return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(dbUser.Id, dbUser.Name, token));
        }

        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto)
        {
            var existingUser = _context.Users.FirstOrDefaultAsync(user => user.Email == dto.Email);

            if (existingUser is not null)
                return ApiResponse<AuthResponseDto>.Fail("This user already exist");

            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var token = _tokenService.GenerateJWT(newUser);

            return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(newUser.Id, newUser.Name, token));
        } 
	}
}

