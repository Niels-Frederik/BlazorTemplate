using TemplateApp.Entities;
using TemplateApp.Models;

namespace TemplateApp.Data;

public interface IDefaultService
{
    public Task<List<DefaultEntityDTO>> GetDataAsync();
}

public class DefaultService : IDefaultService
{
    private List<DefaultEntityDTO> data = new()
    {
        new DefaultEntityDTO("test1"), new DefaultEntityDTO("test2"), new DefaultEntityDTO("test3")
    };

    public async Task<List<DefaultEntityDTO>> GetDataAsync()
    {
        return data;
    }
}
