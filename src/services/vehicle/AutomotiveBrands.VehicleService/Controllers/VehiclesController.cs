namespace AutomotiveBrands.VehicleService.Controllers
{
    public sealed class VehiclesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Araçları listeler
        /// </summary>
        /// <remarks>Markalara göre araç listeler</remarks>
        /// <returns></returns>
        /// <response code="401">Yetkisiz kullanıcı</response>
        /// <response code="9001">İşlem başarılı</response>
        /// <response code="9004">Sistem hatası</response>

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel<List<VehicleListQueryResult>>), 9001)]
        public async Task<IActionResult> List([FromQuery] VehicleListQuery vehicleListQuery)
        {
            var vehicleListQueryResponse = await _mediator.Send(vehicleListQuery);
            return Ok();
        }
    }
}
