﻿namespace AutomotiveBrands.UserService.Application.Pipelines
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

                var failures = validationResults
                           .SelectMany(validationResult => validationResult.Errors)
                           .Where(validationFailure => validationFailure is not null)
                           .ToList();

                _logger.LogInformation("--- {CommandType} komutu doğrulanıyor.", request.GetType().FullName);

                if (failures.Any())
                {
                    _logger.LogWarning("Doğrulama hataları - {CommandType} - Komut: {@Command} - Hatalar: {@ValidationErrors}", typeof(TRequest).Name, request, failures);
                    throw new ValidationException(failures);
                }

            }

            return await next();
        }
    }
}
