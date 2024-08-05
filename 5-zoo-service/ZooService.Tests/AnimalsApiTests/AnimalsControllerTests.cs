using Moq;
using ZooService.AnimalsApi;
using ZooService.Model.Animals;

namespace ZooService.Tests;

public class AnimalsControllerTests
{
    [Fact]
    public async Task Gets_All_Without_Connected_Entities() 
    {
        // Arrange
        var mockRepository = new Mock<IAnimalsRepository>();
        mockRepository.Setup(r => r.GetAllAsync(true)).ReturnsAsync([]);
        mockRepository.Setup(r => r.GetAllAsync(false)).ReturnsAsync([]);

        var controller = new AnimalsController(mockRepository.Object);
        
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
        const int animalId = 52;
        var mockRepository = new Mock<IAnimalsRepository>();
        mockRepository.Setup(r => r.GetByIdAsync(52, true)).ReturnsAsync(new AnimalInfo());
        mockRepository.Setup(r => r.GetByIdAsync(52, false)).ReturnsAsync(new AnimalInfo());

        var controller = new AnimalsController(mockRepository.Object);

        // Act
        _ = await controller.GetByIdAsync(animalId);

        // Assert
        mockRepository.Verify(r => r.GetByIdAsync(animalId, true), Times.Never);
        mockRepository.Verify(r => r.GetByIdAsync(animalId, false), Times.Once);
    }
}
