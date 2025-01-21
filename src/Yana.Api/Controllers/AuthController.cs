﻿using Yana.Application.Features.Auth.Command.LoginGoogleUser;
using Yana.Application.Features.Auth.Command.RegisterGoogleUser;
using Yana.Application.Features.Auth.Query.RefreshGoogleToken;

namespace Yana.Api.Controllers;

public sealed class AuthController(IMediator mediator) : YanaControllerBase(mediator)
{
    [HttpPost("register/google")]
    [Produces("application/json")]
    [ApiConventionMethod(typeof(SwaggerApiConvention), nameof(SwaggerApiConvention.StatusResponseTypes))]
    [ActionName(nameof(RegisterGoogleUser))]
    [GoogleUser]
    public async Task<ActionResult<UserVm>> RegisterGoogleUser()
        => await SendCommand<UserVm, RegisterGoogleUserCommand>(
            new RegisterGoogleUserCommand(AuthenticatedUser!));

    [HttpPost("login/google")]
    [Produces("application/json")]
    [ApiConventionMethod(typeof(SwaggerApiConvention), nameof(SwaggerApiConvention.StatusResponseTypes))]
    [ActionName(nameof(LoginGoogleUser))]
    public async Task<ActionResult<AuthenticationVm>> LoginGoogleUser(AuthorizationCodeDto dto)
        => await SendCommand<AuthenticationVm, LoginGoogleUserCommand>(new LoginGoogleUserCommand(dto));

    [HttpPost("refresh-token/google")]
    [Produces("application/json")]
    [ApiConventionMethod(typeof(SwaggerApiConvention), nameof(SwaggerApiConvention.StatusResponseTypes))]
    [ActionName(nameof(RefreshGoogleToken))]
    public async Task<ActionResult<AccessTokenVm>> RefreshGoogleToken(string userId)
        => await SendQuery<AccessTokenVm, RefreshGoogleTokenQuery>(new RefreshGoogleTokenQuery(userId));
}