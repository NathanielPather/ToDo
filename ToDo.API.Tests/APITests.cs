using Moq;
using ToDo.API.Controllers;
using ToDo.Core.Interfaces;
using Xunit;

namespace ToDo.API.Tests
{
    public class APITests
    {
        [Fact]
        public async Task GetAllToDoLists()
        {
            // arrange
            var toDoListService = new Mock<IToDoListService>();
            toDoListService.Setup(x => x.GetToDoList()).Returns(ToDoMockData.GetToDoList().Any());
            var sut = new ToDoListController(toDoListService.Object);

            /* https://www.learmoreseekmore.com/2022/02/dotnet6-unit-testing-aspnetcore-web-api-using-xunit.html */

            // act
            // assert
            Assert.True(true);
        }
    }
}
