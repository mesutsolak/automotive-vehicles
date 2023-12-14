namespace AutomotiveBrands.UserService.Controllers
{
    public sealed class PreferencesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PreferencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Tercihleri listeler
        /// </summary>
        /// <remarks>Tercihleri listeler</remarks>
        /// <returns>Tercihler</returns>

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PreferenceListQuery preferenceListQuery)
        {
            var preferenceListQueryResponse = await _mediator.Send(preferenceListQuery);
            return Ok(preferenceListQueryResponse);
        }

        /// <summary>
        /// Tercih ekleme
        /// </summary>
        /// <remarks>Tercih ekleme/remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPreferenceCommand addPreferenceCommand)
        {
            var addPreferenceCommandResponse = await _mediator.Send(addPreferenceCommand);
            return Ok(addPreferenceCommandResponse);
        }
    }
}
