﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Yana.Application.Contracts.UserService;
using Yana.Domain.Enums;

namespace Yana.Api.Filters;

public sealed class GoogleUserAttribute : AuthorizeAttribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var httpContext = context.HttpContext;

        if (!httpContext.User.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userRepositoryService = context.HttpContext.RequestServices.GetService<IUserRepositoryService>();
        var userAuthService = context.HttpContext.RequestServices.GetService<IUserAuthService>();

        var principal = httpContext.User;
        var userDto = userAuthService!.GetUserFromPrincipal(principal);

        if (userDto.ExternalId == Guid.Empty.ToString() || string.IsNullOrEmpty(userDto.Email))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var user = await userRepositoryService!.GetUserByEmail(userDto.Email);
        if (user is null)
        {
            user = new UserProfile
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                ExternalUserProfiles =
                [
                    new ExternalUserProfile
                    {
                        Id = userDto.ExternalId,
                        AuthProvider = AuthProvider.Google
                    }
                ]
            };
        }
        else if (user.ExternalUserProfiles.All(x => x.AuthProvider != AuthProvider.Google))
        {
            user.ExternalUserProfiles.Add(new ExternalUserProfile
            {
                Id = userDto.ExternalId,
                AuthProvider = AuthProvider.Google
            });
        }


        if (context.Controller is YanaControllerBase controller)
        {
            controller.AuthenticatedUser = user;
        }

        await next();
    }
}