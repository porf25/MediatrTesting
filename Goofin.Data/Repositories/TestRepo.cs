namespace GoofinApi.Repositories
{
    public interface ITestRepo
    {
        PorfForecast GetTestData(string name);
    }

    public class TestRepo : ITestRepo
    {
        public PorfForecast GetTestData(string name)
        {
            return new PorfForecast
            {
                Id = Guid.NewGuid(),
                Message = $"Hey man, its {name}.. dale"
            };
        }
    }
}
