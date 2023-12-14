namespace AutomotiveBrands.UserService.Test.Infrastructure;

[CollectionDefinition("AutomotiveBrands.UserService.Controllers")]
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