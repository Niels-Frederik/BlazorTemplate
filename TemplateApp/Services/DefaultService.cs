using Microsoft.EntityFrameworkCore;
using TemplateApp.Entities;
using TemplateApp.Models;

namespace TemplateApp.Data;

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
            new DefaultEntityDTO("test1"), new DefaultEntityDTO("test2"), new DefaultEntityDTO("test3")
        }; 
    }
}
