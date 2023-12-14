namespace AutomotiveBrands.VehicleService.Test.Controllers
{
    public sealed class VehiclesControllerTest : IClassFixture<ControllerFixture>
    {
        private readonly VehiclesController _vehiclesController;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ControllerFixture _controllerFixture;

        public VehiclesControllerTest(ControllerFixture controllerFixture)
        {
            _mediatorMock = new Mock<IMediator>();
            _controllerFixture = controllerFixture;
            _vehiclesController = new VehiclesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task List_ReturnsSuccess()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<VehicleListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ResponseModel<List<VehicleListQueryResult>>());

            var actionResult = await _vehiclesController.List(It.IsAny<VehicleListQuery>());

            _mediatorMock.Verify(um => um.Send(It.IsAny<VehicleListQuery>(), It.IsAny<CancellationToken>()), Times.AtMost(1));

            _controllerFixture.VerifyActionResult<ActionResult>(actionResult);
        }

        [Fact]
        public async Task Detail_ReturnsSuccess()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<VehicleDetailQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ResponseModel<List<VehicleDetailQueryResult>>());

            var actionResult = await _vehiclesController.Detail(It.IsAny<VehicleDetailQuery>());

            _mediatorMock.Verify(um => um.Send(It.IsAny<VehicleDetailQuery>(), It.IsAny<CancellationToken>()), Times.AtMost(1));

            _controllerFixture.VerifyActionResult<ActionResult>(actionResult);
        }

        [Fact]
        public async Task GetById_ReturnsSuccess()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<VehicleGetByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ResponseModel<VehicleGetByIdQueryResult>());

            var actionResult = await _vehiclesController.GetById(It.IsAny<VehicleGetByIdQuery>());

            _mediatorMock.Verify(um => um.Send(It.IsAny<VehicleGetByIdQuery>(), It.IsAny<CancellationToken>()), Times.AtMost(1));

            _controllerFixture.VerifyActionResult<ActionResult>(actionResult);
        }

        [Fact]
        public async Task GetByDetailId_ReturnsSuccess()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<VehicleGetByDetailIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ResponseModel<VehicleGetByDetailIdQueryResult>());

            var actionResult = await _vehiclesController.GetByDetailId(It.IsAny<VehicleGetByDetailIdQuery>());

            _mediatorMock.Verify(um => um.Send(It.IsAny<VehicleGetByDetailIdQuery>(), It.IsAny<CancellationToken>()), Times.AtMost(1));

            _controllerFixture.VerifyActionResult<ActionResult>(actionResult);
        }
    }
}
