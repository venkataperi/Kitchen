using Microsoft.EntityFrameworkCore;
using VassuKitchen.Model;

namespace VassuKitchen.Data;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {


    }

    public DbSet<Category> Category { get; set; }

}
