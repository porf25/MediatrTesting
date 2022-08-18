

namespace GoofinApi.Handlers
{
    public class AddPorfsForecastHandler : IRequestHandler<AddPorfsForecastCommand, PorfForecast>
    {
        private readonly ITestRepo _testRepo;
        private readonly PorfForecastRepository _repo;
        public AddPorfsForecastHandler(ITestRepo testRepo, PorfForecastRepository repo)
        {
            _testRepo = testRepo;
            _repo = repo;
        }

        public async Task<PorfForecast> Handle(AddPorfsForecastCommand request, CancellationToken cancellationToken)
        {
            var test = _testRepo.GetTestData("test name");

            var cast = new PorfForecast
            {
                Id = Guid.NewGuid(),
                Message = $"Hey man, its {request.Name}.. dale"
            };

            return await _repo.Add(cast);
        }
    }
}
