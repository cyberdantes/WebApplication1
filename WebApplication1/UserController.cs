namespace WebApplication1;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UserController
{
    public static async Task<IResult> GetUserHello(string userName, [FromServices] AppDbContext context)
    {
        var result =await  context.Users.FirstOrDefaultAsync(u => u.Name == userName);        
        return result == default ?  Results.NotFound("User not found") : Results.Ok($"Hello, {userName}!");
    }
}

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
}

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}