using Moq;
using ZooService.Model.Zoo;
using ZooService.ZoosApi;

namespace ZooService.Tests;


public class ZoosControllerTests
{
    [Fact]
    public async Task Gets_All_Without_Connected_Entities()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<ZooInfo>>();
        mockRepository.Setup(r => r.GetAllAsync(true)).ReturnsAsync([]);
        mockRepository.Setup(r => r.GetAllAsync(false)).ReturnsAsync([]);

        var controller = new ZoosController(mockRepository.Object);

        // Act
        _ = await controller.GetAllAsync();

        // Assert
        mockRepository.Verify(r => r.GetAllAsync(true), Times.Never);
        mockRepository.Verify(r => r.GetAllAsync(false), Times.Once);
    }

    [Fact]
    public async Task Gets_One_With_Connected_Entities()
    {
        // Arrange
        const int zooId = 52;
        var mockRepository = new Mock<IRepository<ZooInfo>>();
        mockRepository.Setup(r => r.GetByIdAsync(zooId, true)).ReturnsAsync(new ZooInfo());
        mockRepository.Setup(r => r.GetByIdAsync(zooId, false)).ReturnsAsync(new ZooInfo());

        var controller = new ZoosController(mockRepository.Object);

        // Act
        _ = await controller.GetByIdAsync(zooId);

        // Assert
        mockRepository.Verify(r => r.GetByIdAsync(zooId, true), Times.Never);
        mockRepository.Verify(r => r.GetByIdAsync(zooId, false), Times.Once);
    }
}
