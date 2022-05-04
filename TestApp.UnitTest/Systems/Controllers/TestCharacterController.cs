using System.Linq;
using System.Threading.Tasks;
using Api_Disney.Controllers;
using Api_Disney.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestApp.UnitTest.MockData;
using Xunit;

namespace TestApp.UnitTest.Systems.Controllers;

public class TestCharacterController
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnStatus200()
    {
        // Arrange
        var characterService = new Mock<ICharacterService>();
        characterService.Setup(x => x.GetQueryable()).Returns(CharacterMockData.GetCharacters().AsQueryable());
        var sut = new CharacterController(characterService.Object); // sut = Stands for System under test

        // Act
        var result = await sut.GetAllAsync();

        //Assert
        result.GetType().Should().Be(typeof(OkObjectResult));
        (result as OkObjectResult).StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task GetDetails_ShouldReturnStatus200()
    {
        // Arrange
        var characterService = new Mock<ICharacterService>();
        characterService.Setup(x => x.GetCharacterDetails()).Returns(CharacterMockData.GetCharacters().AsQueryable());
        var sut = new CharacterController(characterService.Object); 

        // Act
        var result = await sut.GetDetails();

        //Assert
        result.GetType().Should().Be(typeof(OkObjectResult));
        (result as OkObjectResult).StatusCode.Should().Be(200);

    }

    // [Fact]
    // public async Task Create_ShouldReturn200Status()
    // {
    //     // Arrange
    //     var characterService = new Mock<ICharacterService>();
    //     var newCharacter = CharacterMockData.InsertCharacter();
    //     var sut = new CharacterController(characterService.Object);

    //     // Act
    //     var result = await sut.Create(newCharacter); //Error in this line

    //     //Assert
    //     characterService.Verify(x => x.Insert(newCharacter));

    // }
}
