using Authentication.Models.Entities;

namespace Authentication.Services;

public interface IUserRepository {
    Task<ApplicationUser?> ReadByUsernameAsync(string username);

    Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
}