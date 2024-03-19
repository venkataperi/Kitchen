using Kitchen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace VassuKitchen.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {


    }
    public DbSet<Category> Category { get; set; }
    public DbSet<FoodType> FoodType { get; set; }
    public DbSet<MenuItem> MenuItem { get; set; }

}
