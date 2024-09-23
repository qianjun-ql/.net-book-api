using Microsoft.AspNetCore.Identity;
using BookServicesApi.Models;
using System.Threading.Tasks;

namespace BookServicesApi.Services {
    public class AuthService {
        private readonly UserManager<User> _userManager;

        public AuthService(UserManager<User> userManager) {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(User user, string password) {
            return await _userManager.CreateAsync(user,password);
        }

        public async Task<User> FindUserByEmailAsync(string email) {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password) {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}