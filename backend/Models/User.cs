using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Controllers;

// One to Many Table
public class User
{
    public string Username{get;set;}
    public string Password {get;set;}
    public string EmailAddress{get;set;}
    public DateTime DateOfJoing{get;set;}
}
