﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BallastLane.Domain.Interfaces;

namespace BallastLane.Infra.CrossCutting.Identity.Models;

public class AspNetUser : IUser
{
    private readonly IHttpContextAccessor _accessor;

    public AspNetUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string Name => GetName();

    private string GetName()
    {
        return _accessor.HttpContext.User.Identity.Name ?? 
               _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    }

    public bool IsAuthenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public IEnumerable<Claim> GetClaimsIdentity()
    {
        return  _accessor.HttpContext.User.Claims;
    }
}
