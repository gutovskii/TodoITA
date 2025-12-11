using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoITA.BLL.DTO.TodoItem;
using TodoITA.BLL.Services.Interfaces;
using TodoITA.DataAccess.Entities;
using TodoITA.WebApi.Controllers;
using TodoITA.WebApi.Hubs;
using TodoITA.WebApi.ViewModels;

namespace Tests.Controllers
{
    public class TodoItemsControllerTest
    {
        private TodoItemController _itemsController;
        private Mock<ITodoItemService> _itemsServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IHubContext<TodoHub>> _hubContextMock;
        private Mock<IHubClients> _mockClients;
        private Mock<IClientProxy> _mockClientProxy;

        [SetUp]
        public void Setup()
        {
            _itemsServiceMock = new Mock<ITodoItemService>();
            _mapperMock = new Mock<IMapper>();
            _hubContextMock = new Mock<IHubContext<TodoHub>>();
            _mockClients = new Mock<IHubClients>();
            _mockClientProxy = new Mock<IClientProxy>();

            _mockClients.Setup(clients => clients.All).Returns(_mockClientProxy.Object);
            _hubContextMock.Setup(x => x.Clients).Returns(() => _mockClients.Object);

            _itemsController = new TodoItemController(_itemsServiceMock.Object, _mapperMock.Object, _hubContextMock.Object);
        }

        [Test]
        public async Task CreateItem_ReturnsTodoItemViewModel()
        {
            // Arrange
            CreateTodoItemDto createTodoItemDto = new CreateTodoItemDto();
            _mapperMock
                .Setup(m => m.Map<TodoItem>(createTodoItemDto))
                .Returns(new TodoItem());
            _mapperMock
                .Setup(m => m.Map<TodoItemViewModel>(It.IsAny<TodoItem>()))
                .Returns(new TodoItemViewModel());

            // Act
            IActionResult actionResult = await _itemsController.CreateItem(createTodoItemDto);
            var resultValue = (actionResult as ObjectResult).Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<CreatedAtRouteResult>(actionResult);
            Assert.IsNotNull(resultValue);
            Assert.IsInstanceOf<TodoItemViewModel>(resultValue);
            _mockClientProxy.Verify(x => x.SendCoreAsync("ItemCreated", It.IsAny<object[]>(), default), Times.Once);
        }

        [Test]
        public async Task UpdateItem_ReturnsTodoItemViewModel()
        {
            // Arrange
            UpdateTodoItemDto updateTodoItemDto = new UpdateTodoItemDto();
            _itemsServiceMock
                .Setup(i => i.GetTodoItemByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new TodoItem());
            _mapperMock
                .Setup(m => m.Map(updateTodoItemDto, It.IsAny<TodoItem>()))
                .Returns(new TodoItem());
            _mapperMock
                .Setup(m => m.Map<TodoItemViewModel>(It.IsAny<TodoItem>()))
                .Returns(new TodoItemViewModel());

            // Act
            IActionResult actionResult = await _itemsController.UpdateItem(It.IsAny<int>(), updateTodoItemDto);
            var resultValue = (actionResult as ObjectResult).Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(resultValue);
            Assert.IsInstanceOf<TodoItemViewModel>(resultValue);
            _mockClientProxy.Verify(x => x.SendCoreAsync("ItemUpdated", It.IsAny<object[]>(), default), Times.Once);
        }

        [Test]
        public async Task UpdateItemPatch_ReturnsTodoItemViewModel()
        {
            // Arrange
            JsonPatchDocument<TodoItem> patchDocument = new JsonPatchDocument<TodoItem>();
            _itemsServiceMock
                .Setup(i => i.GetTodoItemByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new TodoItem());
            _mapperMock
                .Setup(m => m.Map<TodoItemViewModel>(It.IsAny<TodoItem>()))
                .Returns(new TodoItemViewModel());

            // Act
            IActionResult actionResult = await _itemsController.UpdateItemPatch(It.IsAny<int>(), patchDocument);
            var resultValue = (actionResult as ObjectResult).Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(resultValue);
            Assert.IsInstanceOf<TodoItemViewModel>(resultValue);
            _mockClientProxy.Verify(x => x.SendCoreAsync("ItemUpdated", It.IsAny<object[]>(), default), Times.Once);
        }

        [Test]
        public async Task DeleteItem_ReturnsOk()
        {
            // Arrange
            _itemsServiceMock
                .Setup(i => i.DeleteTodoItemAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            IActionResult actionResult = await _itemsController.DeleteItem(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkResult>(actionResult);
            _mockClientProxy.Verify(x => x.SendCoreAsync("ItemDeleted", It.IsAny<object[]>(), default), Times.Once);
        }
    }
}
