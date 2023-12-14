namespace AutomotiveBrands.Client.Controllers
{
    public sealed class ErrorController : BaseController
    {
        public IActionResult Index(int? statusCode)
        {
            if (statusCode is not null && statusCode == (int)HttpStatusCode.NotFound)
            {
                return RedirectToAction(ActionNames.Page404, ControllerNames.Error);
            }

            return RedirectToAction(ActionNames.PageError, ControllerNames.Error);
        }

        public IActionResult Page404()
        {
            return View();
        }

        public IActionResult PageError()
        {
            return View();
        }
    }
}
