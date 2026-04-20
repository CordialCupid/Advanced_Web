using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Lab3MKWebAPI.Models.Entities;

namespace Lab3MKWebAPI.Services;

public class DbUserRepository : IUserRepository {
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public DbUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager) {
        _db=db;
        _userManager=userManager;
    }

    public async Task<ICollection<ApplicationUser>> ReadAllAsync() {
        return await _db.Users.ToListAsync();
    }

    public async Task<ApplicationUser> CreateAsync(ApplicationUser newUser, string password) {
        await _userManager.CreateAsync(newUser, password);
        return newUser;
    }

    public async Task<ApplicationUser?> ReadByUsernameAsync(string username) {
        return await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task UpdateAsync(string username, ApplicationUser updatedUser)
    {
        var userToUpdate = await ReadByUsernameAsync(username);
        if (userToUpdate != null) {
            userToUpdate.FirstName = updatedUser.FirstName;
            userToUpdate.LastName = updatedUser.LastName;
            userToUpdate.Profile = updatedUser.Profile;

            await _db.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(string username) {
        var userToDelete = await ReadByUsernameAsync(username);

        if (userToDelete != null) {
            _db.Users.Remove(userToDelete);
            await _db.SaveChangesAsync();
        }
    }
}