using BookStore.DataAccess.Configurations;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookStore.DataAccess;

public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
{
    public DbSet<BookEntity> Books { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<RoleEntity> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);

        //modelBuilder.ApplyConfiguration(new RolePermissionConfigurations(authOptions.Value));
    }

}
