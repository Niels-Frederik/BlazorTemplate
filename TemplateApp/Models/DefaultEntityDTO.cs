using TemplateApp.Entities;

namespace TemplateApp.Models;

public class DefaultEntityDTO
{
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public DefaultEntityDTO(string name)
    {
        Name = name;
        Date = DateTime.Now;
    }
}