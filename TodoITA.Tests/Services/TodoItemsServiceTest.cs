using Microsoft.AspNetCore.JsonPatch;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.BLL.Services.Interfaces;
using TodoITA.BLL.Services.Realization;
using TodoITA.DataAccess.Entities;
using TodoITA.DataAccess.Repositories.Interfaces;

namespace Tests.Services
{
    public class TodoItemsServiceTest
    {
        private ITodoItemService _todoItemService;
        private Mock<ITodoItemRepository> _repositoryMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<ITodoItemRepository>();
            _todoItemService = new TodoItemService(_repositoryMock.Object);
        }

        [Test]
        public async Task CreateItem_VerifyCreate()
        {
            // Arrange

            // Act
            await _todoItemService.CreateTodoItemAsync(It.IsAny<TodoItem>());

            // Assert
            _repositoryMock.Verify(r => r.CreateAsync(It.IsAny<TodoItem>()), Times.Once);
        }

        [Test]
        public async Task UpdateItem_InvokedOneTime_Success()
        {
            // Arrange

            // Act
            await _todoItemService.UpdateTodoItemAsync(It.IsAny<TodoItem>());

            // Assert
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TodoItem>()), Times.Once);
        }

        [Test]
        public async Task UpdateItemPatch_VerifyUpdatePatch()
        {
            // Arrange

            // Act
            await _todoItemService.UpdateTodoItemPatchAsync(It.IsAny<TodoItem>(), It.IsAny<JsonPatchDocument<TodoItem>>());

            // Assert
            _repositoryMock.Verify(r => r.UpdatePatchAsync(It.IsAny<TodoItem>(), It.IsAny<JsonPatchDocument<TodoItem>>()));
        }

        [Test]
        public async Task DeleteItem_ReturnsTrue()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            await _todoItemService.DeleteTodoItemAsync(It.IsAny<int>());

            // Assert
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
