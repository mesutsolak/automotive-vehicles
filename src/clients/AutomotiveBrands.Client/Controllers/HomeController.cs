namespace AutomotiveBrands.Client.Controllers
{
    public sealed class HomeController : BaseController
    {


        public HomeController()
        {

        }

        [Route("{modelYear:int?}")]
        public async Task<IActionResult> List(int? modelYear)
        {
            return null;
        }
    }
}
