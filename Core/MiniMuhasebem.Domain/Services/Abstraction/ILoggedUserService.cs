﻿using MiniMuhasebem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Domain.Services.Abstraction
{
    public interface ILoggedUserService
    {
        int? UserId { get; }
        Roles? Role { get; }
        string UserName { get; }
        string Email { get; }
    }
}
