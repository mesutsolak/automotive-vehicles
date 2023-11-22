namespace AutomotiveBrands.UserService.Application.Pipelines
{
    public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{@fullName} isteği yürütülüyor...", request.GetType().FullName);
            var response = await next();
            _logger.LogInformation("{@fullName} isteği tamamlandı...", request.GetType().FullName);

            return response;
        }
    }
}
