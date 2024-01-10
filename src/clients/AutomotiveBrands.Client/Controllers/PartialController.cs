namespace AutomotiveBrands.Client.Controllers
{
    public sealed class PartialController : BaseController
    {
        private readonly IAutomotiveBrandsService _automotiveBrandsService;

        public PartialController(IAutomotiveBrandsService automotiveBrandsService)
        {
            _automotiveBrandsService = automotiveBrandsService;
        }

        [HttpGet]
        public async Task<IActionResult> VehicleDetail(SearchDetailModel searchDetailModel)
        {
            var vehicleGetByIdResponse = await _automotiveBrandsService.VehicleGetByIdAsync(new VehicleGetByIdRequest(searchDetailModel.VehicleId));

            if (!vehicleGetByIdResponse.Succeeded)
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            var vehicleDetailResponse = await _automotiveBrandsService.VehicleDetailAsync(new VehicleDetailRequest(searchDetailModel.VehicleId));

            if (!vehicleDetailResponse.Succeeded)
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            var preferenceAddResponse = await _automotiveBrandsService.PreferenceAddAsync(new PreferenceAddRequest(searchDetailModel.VehicleId, BrandType.Audi));

            if (!preferenceAddResponse.Succeeded)
                return RedirectToAction(ActionNames.PageError, ControllerNames.Error);

            if (!searchDetailModel.ModelNames.IsNullOrNotAny())
            {
                vehicleDetailResponse.Data = vehicleDetailResponse.Data.FindAll(x => searchDetailModel.ModelNames.Contains(x.ModelName));
            }

            if (!searchDetailModel.Prices.IsNullOrNotAny())
            {
                vehicleDetailResponse.Data = vehicleDetailResponse.Data.FindAll(x => searchDetailModel.Prices.Exists(y => x.Price >= y));
            }

            if (!searchDetailModel.VatRates.IsNullOrNotAny())
            {
                vehicleDetailResponse.Data = vehicleDetailResponse.Data.FindAll(x => searchDetailModel.VatRates.Exists(y => x.VatRate >= y));
            }

            if (!searchDetailModel.ExciseDutyRates.IsNullOrNotAny())
            {
                vehicleDetailResponse.Data = vehicleDetailResponse.Data.FindAll(x => searchDetailModel.ExciseDutyRates.Exists(y => x.ExciseDutyRate >= y));
            }

            var groupedVehicles = vehicleDetailResponse.Data.GroupBy(car => car.ModelName)
                                  .ToDictionary(group => group.Key, group => group.ToList());

            return PartialView(new VehicleDetailViewModel(groupedVehicles, vehicleGetByIdResponse.Data.ImageName));
        }
    }
}
