
namespace GoofinApi;

public class PorfForecast : IEntity
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public int Age => 38;
}
