using Authentication.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Services;

public class DbUserRepository : IUserRepository {
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public DbUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager) {
        _db = db;
        _userManager = userManager;
    }

    public async Task<ApplicationUser?> ReadByUsernameAsync(string username) {
        return await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password) {
        await _userManager.CreateAsync(user, password);
        return user;
    }
}