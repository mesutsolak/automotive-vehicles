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
        public async Task<IActionResult> Add(CreatePreferenceCommand createPreferenceCommand)
        {
            var createPreferenceCommandResponse = await _mediator.Send(createPreferenceCommand);
            return Ok(createPreferenceCommandResponse);
        }

        /// <summary>
        /// Tercih güncelleme
        /// </summary>
        /// <remarks>Tercih güncelleme/remarks>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePreferenceCommand updatePreferenceCommand)
        {
            var updatePreferenceCommandResponse = await _mediator.Send(updatePreferenceCommand);
            return Ok(updatePreferenceCommandResponse);
        }
    }
}
