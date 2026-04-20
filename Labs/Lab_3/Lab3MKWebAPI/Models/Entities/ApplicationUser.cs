using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Lab3MKWebAPI.Models.Entities;

public class ApplicationUser : IdentityUser {
    public string FirstName {get; set;} = String.Empty;
    public string LastName {get; set;} = String.Empty;
    public string Profile {get; set;} = String.Empty;

    [NotMapped]
    public ICollection<string> Roles {get; set;} = [];

    public bool HasRole(string rolename) {
        return Roles.Contains(rolename);
    }
}