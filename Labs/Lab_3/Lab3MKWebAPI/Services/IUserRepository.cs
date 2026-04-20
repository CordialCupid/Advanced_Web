using Lab3MKWebAPI.Models.Entities;

namespace Lab3MKWebAPI.Services;

public interface IUserRepository {
    Task<ICollection<ApplicationUser>> ReadAllAsync();

    Task<ApplicationUser> CreateAsync(ApplicationUser newUser, string password);

    Task<ApplicationUser?> ReadByUsernameAsync(string username);

    Task UpdateAsync(string username, ApplicationUser updatedUser);

    Task DeleteAsync(string username);
}