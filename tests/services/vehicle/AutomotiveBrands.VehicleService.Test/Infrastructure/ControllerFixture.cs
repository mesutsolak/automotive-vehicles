namespace AutomotiveBrands.VehicleService.Test.Infrastructure;

[CollectionDefinition("AutomotiveBrands.VehicleService.Controllers")]
public class ControllerFixtureCollection : ICollectionFixture<ControllerFixture>
{
}

public sealed class ControllerFixture
{
    public void VerifyActionResult<T>(IActionResult result, bool isCheckForNull = true)
    {
        var responseModel = Assert.IsAssignableFrom<T>(result);
        if (isCheckForNull)
            Assert.NotNull(responseModel);
        Assert.NotNull(responseModel);
    }
}