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
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            var preferenceListResponse = await _automotiveBrandsService.PreferenceListAsync(new PreferenceListRequest(brand));

            if (preferenceListResponse.Succeeded)
            {
                var foundVehicleListResponse = vehicleListResponse.Data.FirstOrDefault(x => x.Id == preferenceListResponse.Data.VehicleId);

                if (foundVehicleListResponse is not null)
                {
                    vehicleListResponse.Data.Remove(foundVehicleListResponse);

                    vehicleListResponse.Data.Insert(0, foundVehicleListResponse);
                }
            }

            return View(new ListViewModel(vehicleListResponse.Data));
        }

        [Route("vehicledetails/{vehicleId:int}")]
        public async Task<IActionResult> Detail(int vehicleId)
        {
            var vehicleGetByIdResponse = await _automotiveBrandsService.VehicleGetByIdAsync(new VehicleGetByIdRequest(vehicleId));

            if (!vehicleGetByIdResponse.Succeeded)
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            var vehicleDetailResponse = await _automotiveBrandsService.VehicleDetailAsync(new VehicleDetailRequest(vehicleId));

            if (!vehicleDetailResponse.Succeeded)
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            var preferenceAddResponse = await _automotiveBrandsService.PreferenceAddAsync(new PreferenceAddRequest(vehicleId, BrandType.Audi));

            if (!preferenceAddResponse.Succeeded)
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            var groupedVehicles = vehicleDetailResponse.Data.GroupBy(car => car.ModelName)
                                  .ToDictionary(group => group.Key, group => group.ToList());

            return View(new DetailViewModel(groupedVehicles, vehicleGetByIdResponse.Data.ImageName));
        }

        [Route("vehicledetail/{vehicleDetailId:int}")]
        public async Task<IActionResult> VehicleDetail(int vehicleDetailId)
        {
            var vehicleGetByDetailIdResponse = await _automotiveBrandsService.VehicleGetByDetailIdAsync(new VehicleGetByDetailIdRequest(vehicleDetailId));

            if (!vehicleGetByDetailIdResponse.Succeeded)
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            return Json(new
            {
                vehicleGetByDetailIdResponse.Data.ModelDescription,
                Price = string.Format(StringFormats.DoublePrice, vehicleGetByDetailIdResponse.Data.Price),
                vehicleGetByDetailIdResponse.Data.FuelConsumption,
                vehicleGetByDetailIdResponse.Data.CO2,
                vehicleGetByDetailIdResponse.Data.Engine,
                EngineCapacity = string.Format(StringFormats.Centimeter, vehicleGetByDetailIdResponse.Data.EngineCapacity),
                NetPrice = string.Format(StringFormats.DoublePrice, vehicleGetByDetailIdResponse.Data.NetPrice),
                VAT = string.Format(StringFormats.DoublePrice, vehicleGetByDetailIdResponse.Data.Vat),
                ExciseDuty = string.Format(StringFormats.DoublePrice, vehicleGetByDetailIdResponse.Data.ExciseDuty),
                vehicleGetByDetailIdResponse.Data.ExciseDutyRate,
                TrafficRegistrationOfficialFee = string.Format(StringFormats.NormalPrice, vehicleGetByDetailIdResponse.Data.TrafficRegistrationOfficialFee.ToString("N2", Cultures.Turkish)),
                TrafficRegistrationServiceFee = string.Format(StringFormats.NormalPrice, vehicleGetByDetailIdResponse.Data.TrafficRegistrationServiceFee.ToString("N2", Cultures.Turkish)),
                MotorVehicleTax = string.Format(StringFormats.NormalPrice, vehicleGetByDetailIdResponse.Data.MotorVehicleTax.ToString("N2", Cultures.Turkish))
            });
        }
    }
}
