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
        /// <returns>Araçlar</returns>
        /// 

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] VehicleListQuery vehicleListQuery)
        {
            var vehicleListQueryResponse = await _mediator.Send(vehicleListQuery);
            return Ok(vehicleListQueryResponse);
        }

        /// <summary>
        /// Araç id'sine göre araç detaylarını listeler
        /// </summary>
        /// <remarks>Araç detaylarını listeler/remarks>
        /// <param name="vehicleDetailQuery">Araç id bilgisi</param>
        /// <returns>Araç detayları</returns>
        /// 

        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] VehicleDetailQuery vehicleDetailQuery)
        {
            var vehicleDetailQueryResponse = await _mediator.Send(vehicleDetailQuery);
            return Ok(vehicleDetailQueryResponse);
        }

        /// <summary>
        /// Araç id'sine göre aracın bilgisini listeler
        /// </summary>
        /// <remarks>Araç bilgisini listeler/remarks>
        /// <param name="vehicleGetByIdQuery">Araç id bilgisi</param>
        /// <returns>Araç bilgisi</returns>
        /// 

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] VehicleGetByIdQuery vehicleGetByIdQuery)
        {
            var vehicleGetByIdQueryResponse = await _mediator.Send(vehicleGetByIdQuery);
            return Ok(vehicleGetByIdQueryResponse);
        }
    }
}
