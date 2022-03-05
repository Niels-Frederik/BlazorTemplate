using TemplateApp.Entities;

namespace TemplateApp.Data;

public class DefaultService
{
    private List<DefaultEntity> data = new()
    {
        new DefaultEntity(){Name = "test1"}, new DefaultEntity(){Name = "test2"}, new DefaultEntity(){Name = "test3"}
    };

    public async Task<List<DefaultEntity>> GetDataAsync()
    {
        return data;
    }
}
