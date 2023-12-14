namespace AutomotiveBrands.Lib.ApiVersion.Infrastructure.Providers
{
    public sealed class CustomizedResponseProvider : DefaultErrorResponseProvider
    {
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            //ErrorResult errorResult = new(ExceptionMessage.ApiVersionNotCompatible);

            BadRequestObjectResult badRequestObjectResult = new(null)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            return badRequestObjectResult;
        }
    }
}
