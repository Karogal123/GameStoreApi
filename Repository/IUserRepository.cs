using GameStore.Auth;
using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public interface IUserRepository
    {
        Task<AuthenticationResult> RegisterAsync(User user);
        Task<AuthenticationResult> LoginAsync(User user);
    }
}
