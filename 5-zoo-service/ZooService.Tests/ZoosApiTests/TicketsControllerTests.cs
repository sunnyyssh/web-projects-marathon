using Moq;
using ZooService.Model.Zoo;
using ZooService.ZoosApi;

namespace ZooService.Tests;

public class TicketsControllerTests
{
    [Fact]
    public async Task Gets_All_Without_Connected_Entities()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<Ticket>>();
        mockRepository.Setup(r => r.GetAllAsync(true)).ReturnsAsync([]);
        mockRepository.Setup(r => r.GetAllAsync(false)).ReturnsAsync([]);

        var controller = new TicketsController(mockRepository.Object);

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
        const int ticketId = 52;
        var mockRepository = new Mock<IRepository<Ticket>>();
        mockRepository.Setup(r => r.GetByIdAsync(ticketId, true)).ReturnsAsync(new Ticket());
        mockRepository.Setup(r => r.GetByIdAsync(ticketId, false)).ReturnsAsync(new Ticket());

        var controller = new TicketsController(mockRepository.Object);

        // Act
        _ = await controller.GetByIdAsync(ticketId);

        // Assert
        mockRepository.Verify(r => r.GetByIdAsync(ticketId, true), Times.Never);
        mockRepository.Verify(r => r.GetByIdAsync(ticketId, false), Times.Once);
    }
}
