using JwtAuthWebApi.Dtos;
using JwtAuthWebApi.Models;
using JwtAuthWebApi.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController: ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenClaimService;

    public AccountsController(SignInManager<ApplicationUser> signInManager, 
        ITokenService tokenClaimService)
    {
        _signInManager = signInManager;
        _tokenClaimService = tokenClaimService;
    }

    [HttpPost("Authenticate")]
    public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);

        var response = new AuthenticateResponse
        {
            Result = result.Succeeded,
            IsLockedOut = result.IsLockedOut,
            IsNotAllowed = result.IsNotAllowed,
            RequiresTwoFactor = result.RequiresTwoFactor,
            Username = request.Username
        };

        if (result.Succeeded)
        {
            response.AccessToken = await _tokenClaimService.GetAccessTokenAsync(request.Username);
        }

        return response;
    }
}
