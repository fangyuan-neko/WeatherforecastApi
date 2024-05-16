using Model;
using Method;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Security.Claims;

namespace Services;

public class UserService(IConfiguration Configuration, DBConfig database)
{
    private readonly DBConfig db = database;
    public bool AddUser(UserModel user)
    {
        user.Token = GenerateJWT(user.Username);
        db.Users.Add(user);
        db.SaveChanges();
        return true;
    }
    public List<UserModel> GetAllUser()
    {
        return db.Users.ToList();
    }
    public UserModel GetUser(string Email)
    {
        var user = db.Users.Single(user => user.Email == Email);
        return user;
    }
    public string GenerateJWT(string Username)
    {
        return new JsonWebTokenHandler()
        .CreateToken(new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new("iss", Username),
            }, JwtBearerDefaults.AuthenticationScheme),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtConfig:SecretKey").Value)), SecurityAlgorithms.HmacSha256)
        });
    }
    public string GetTokenByUsernameAndPassword(string Username, string Password)
    {
        foreach (UserModel username in db.Users)
        {
            if (Username == username.Username)
            {
                foreach (UserModel user in db.Users)
                {
                    if (Password == user.Password)
                    {
                        return user.Token;
                    }
                }
            }
        }
        return "404 NotFound";
    }
}