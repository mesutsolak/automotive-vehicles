namespace AutomotiveBrands.UserService.Test.Controllers
{
    public sealed class PreferencesControllerTest : IClassFixture<ControllerFixture>
    {
        private readonly PreferencesController _preferencesController;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ControllerFixture _controllerFixture;

        public PreferencesControllerTest(ControllerFixture controllerFixture)
        {
            _mediatorMock = new Mock<IMediator>();
            _controllerFixture = controllerFixture;
            _preferencesController = new PreferencesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task List_ReturnsSuccess()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<PreferenceListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ResponseModel<PreferenceListQueryResult>());

            var actionResult = await _preferencesController.List(It.IsAny<PreferenceListQuery>());

            _mediatorMock.Verify(um => um.Send(It.IsAny<PreferenceListQuery>(), It.IsAny<CancellationToken>()), Times.AtMost(1));

            _controllerFixture.VerifyActionResult<ActionResult>(actionResult);
        }
        [Fact]
        public async Task Add_ReturnsSuccess()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<AddPreferenceCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ResponseModel<Unit>());

            var actionResult = await _preferencesController.Add(It.IsAny<AddPreferenceCommand>());

            _mediatorMock.Verify(um => um.Send(It.IsAny<AddPreferenceCommand>(), It.IsAny<CancellationToken>()), Times.AtMost(1));

            _controllerFixture.VerifyActionResult<ActionResult>(actionResult);
        }
    }
}
