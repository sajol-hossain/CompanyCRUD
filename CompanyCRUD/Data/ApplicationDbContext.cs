


using CompanyCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyCRUD.Data;
public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Company {  get; set; }
    public DbSet<CompanyEntry> CompanyEntries {  get; set; }
}
