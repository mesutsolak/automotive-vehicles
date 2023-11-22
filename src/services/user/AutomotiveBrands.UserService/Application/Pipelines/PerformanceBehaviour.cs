namespace AutomotiveBrands.UserService.Application.Pipelines
{
    public sealed class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _stopwatch;
        private readonly ILogger<TRequest> _logger;

        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _stopwatch.Start();
            var response = await next();
            _stopwatch.Stop();

            var elapsedSeconds = _stopwatch.Elapsed.TotalSeconds;
            if (elapsedSeconds >= 40)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning("Uzun Süreli İstek: {Name} ({elapsedSeconds} saniye) {@Request}", requestName, elapsedSeconds, request);
            }

            return response;
        }
    }
}
