

namespace GoofinApi.Processors
{
    public class TestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private PorfContext _context;

        public TestPostProcessor(PorfContext context)
        {
            _context = context;
        }
        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            var changes = _context.ChangeTracker.Entries();

            if(changes.Any())
            {
                await _context.SaveChangesAsync(cancellationToken);
            };            
        }
    }
}
