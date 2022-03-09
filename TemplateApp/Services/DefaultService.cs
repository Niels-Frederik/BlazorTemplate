using Microsoft.EntityFrameworkCore;
using TemplateApp.Models;
using TemplateApp.Services;

namespace TemplateApp.Services;

public interface IDefaultService
{
    public Task<List<DefaultEntityDTO>> GetDataAsync();
}

public class DefaultService : IDefaultService
{
    private readonly IDbContextFactory<DatabaseContext> _dbFactory;
    public DefaultService(IDbContextFactory<DatabaseContext> dbFactory) 
    { 
        _dbFactory = dbFactory;
    }
    
    public async Task<List<DefaultEntityDTO>> GetDataAsync()
    {
        return new List<DefaultEntityDTO>()
        {
            new ("test1"), new ("test2"), new ("test3")
        }; 
    }
}
