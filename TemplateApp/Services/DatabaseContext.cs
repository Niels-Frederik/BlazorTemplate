using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TemplateApp.Entities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    
    /// <summary>
    ///     Dispose pattern.
    /// </summary>
    public override void Dispose()
    {
        Debug.WriteLine($"{ContextId} context disposed.");
        base.Dispose();
    }

    /// <summary>
    ///     Dispose pattern.
    /// </summary>
    /// <returns>A <see cref="ValueTask" /></returns>
    public override ValueTask DisposeAsync()
    {
        Debug.WriteLine($"{ContextId} context disposed async.");
        return base.DisposeAsync();
    }
}