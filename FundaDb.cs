using Microsoft.EntityFrameworkCore;

public class FundaDb : DbContext
{
    public FundaDb(DbContextOptions<FundaDb> options)
        : base(options) { }

    public DbSet<House> Houses => Set<House>();
}