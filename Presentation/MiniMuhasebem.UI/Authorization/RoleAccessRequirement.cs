using Microsoft.AspNetCore.Authorization;
using MiniMuhasebem.UI.Models;

namespace MiniMuhasebem.UI.Authorization
{
    public class RoleAccessRequirement : IAuthorizationRequirement
    {
        public Roles[] Roles { get; set; }

        public RoleAccessRequirement(params Roles[] roles)
        {
            Roles = roles;
        }
    }
}
