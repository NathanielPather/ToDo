using Microsoft.AspNetCore.Mvc;
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
            toDoListService.Setup(x => x.GetToDoList()).Returns(ToDoMockData.GetToDoList());
            var sut = new ToDoListController(toDoListService.Object);

            /* https://www.learmoreseekmore.com/2022/02/dotnet6-unit-testing-aspnetcore-web-api-using-xunit.html */

            // act
            var result = (OkObjectResult)await sut.GetAllToDoLists();

            // assert
            Assert.True(result.StatusCode.Equals(200));

            // should all apis return a status code
                // yes, bool is pointless as status code provides more info
            // should all apis be async
                // no, depends on requirements, minimal processing should not be async
            // should apis return an object/list of objects
                // depends on what you want
        }
    }
}
