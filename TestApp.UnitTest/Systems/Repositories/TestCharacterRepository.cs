using System.Linq;
using System;
using System.Threading.Tasks;
using Api_Disney.Data;
using Api_Disney.Repositories.Implements;
using Microsoft.EntityFrameworkCore;
using TestApp.UnitTest.MockData;
using Xunit;
using FluentAssertions;

namespace TestApp.UnitTest.Systems.Repositories;

public class TestCharacterRepository : IDisposable
{
    private readonly DisneyContext _disneyContext;
    public TestCharacterRepository()
    {
        var options = new DbContextOptionsBuilder<DisneyContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _disneyContext = new DisneyContext(options);
        _disneyContext.Database.EnsureCreated();
    }

    /* 
    Note: 
        If I remove the method OnConfiguring() from DisneyContext.cs this test pass. 
        Because I want to provide 'Microsoft.EntityFrameworkCore.InMemory' 
        but 'Microsoft.EntityFrameworkCore.SqlServer' have been registered in the service provider.
    */
    [Fact]
    public async Task GetCharacterDetails_ReturnCharacterCollection()
    {
        // Arrange
        _disneyContext.Characters.AddRange(CharacterMockData.GetCharacters());
        _disneyContext.SaveChanges();

        var sut = new CharacterRepository(_disneyContext);

        // Act
        var result = sut.GetCharacterDetails().AsQueryable();

        //Assert
        result.Should().HaveCount(CharacterMockData.GetCharacters().AsQueryable().Count());
    }


    public void Dispose()
    {
        _disneyContext.Database.EnsureDeleted();
        _disneyContext.Dispose();
    }
}
