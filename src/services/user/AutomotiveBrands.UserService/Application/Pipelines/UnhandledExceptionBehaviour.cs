﻿namespace AutomotiveBrands.UserService.Application.Pipelines
{
    public sealed class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "-- İstek: {@Name} {@Request} İsteği için işlenmeyen hata.", typeof(TRequest).Name, request);
                throw;
            }
        }
    }
}
