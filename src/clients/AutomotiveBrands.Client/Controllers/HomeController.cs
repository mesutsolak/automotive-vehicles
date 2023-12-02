namespace AutomotiveBrands.Client.Controllers
{
    public sealed class HomeController : BaseController
    {
        private readonly IAutomotiveBrandsService _automotiveBrandsService;

        public HomeController(IAutomotiveBrandsService automotiveBrandsService)
        {
            _automotiveBrandsService = automotiveBrandsService;
        }

        public async Task<IActionResult> List(BrandType brand)
        {
            var vehicleListResponse = await _automotiveBrandsService.VehicleListAsync(new VehicleListRequest(brand));

            if (!vehicleListResponse.Succeeded)
                return Redirect(Routes.Home);

            return View(new ListViewModel(vehicleListResponse.Data));
        }


        [Route("vehicledetail/{vehicleId:int}")]
        public async Task<IActionResult> Detail(int vehicleId)
        {
            var vehicleGetByIdResponse = await _automotiveBrandsService.VehicleGetByIdAsync(new VehicleGetByIdRequest(vehicleId));

            if (!vehicleGetByIdResponse.Succeeded)
                return Redirect(Routes.Home);

            var vehicleDetailResponse = await _automotiveBrandsService.VehicleDetailAsync(new VehicleDetailRequest(vehicleId));

            if (!vehicleDetailResponse.Succeeded)
                return Redirect(Routes.Home);

            return View(new DetailViewModel(vehicleDetailResponse.Data, vehicleGetByIdResponse.Data));
        }
    }
}
