using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TemplateApp.Entities;

namespace TemplateApp.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<DefaultEntity> DefaultEntities{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var defaultEntities = builder.Entity<DefaultEntity>().ToTable("DefaultEntities");
        defaultEntities.HasKey(x => x.Name);
    }
    
    public override void Dispose()
    {
        Debug.WriteLine($"{ContextId} context disposed.");
        base.Dispose();
    }

    public override ValueTask DisposeAsync()
    {
        Debug.WriteLine($"{ContextId} context disposed async.");
        return base.DisposeAsync();
    }
}