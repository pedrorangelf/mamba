using Mamba.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Mamba.API.Extensions
{
    public class UserApp : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApp(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Name => _httpContextAccessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }

        public string GetCurrentPath()
        {
            return _httpContextAccessor.HttpContext.Features.Get<IHttpRequestFeature>().Path;
        }

        public string GetUserEmail()
        {
            return _httpContextAccessor.HttpContext.User.GetUserEmail();
        }

        public Guid GetUserId()
        {
            if (!IsAuthenticated()) return Guid.Empty;

            return Guid.Parse(_httpContextAccessor.HttpContext.User.GetUserId());
        }

        public Guid GetEmpresaId()
        {
            if (!IsAuthenticated() || !IsInRole("Empresa")) return Guid.Empty;

            return Guid.Parse(_httpContextAccessor.HttpContext.User.GetEmpresaId());
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _httpContextAccessor.HttpContext.User.IsInRole(role);
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));

            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));

            return claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
        }

        public static string GetEmpresaId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue("EmpresaId");
        }
    }
}
