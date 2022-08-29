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
    public class TodoCategoriesServiceTest
    {
        private ITodoCategoryService _todoCategoryService;
        private Mock<ITodoCategoryRepository> _repositoryMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<ITodoCategoryRepository>();
            _todoCategoryService = new TodoCategoryService(_repositoryMock.Object);
        }

        [Test]
        public async Task GetCategories_ReturnsIEnumerable()
        {
            // Arrange
            _repositoryMock
                .Setup(c => c.GetAllAsync())
                .ReturnsAsync(CreateListOfTodoCategories());

            // Act
            var result = await _todoCategoryService.GetTodoCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<TodoCategory>>(result);
        }

        [Test]
        public async Task GetCategory_ReturnsEntity()
        {
            // Arrange
            _repositoryMock
                .Setup(c => c.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new TodoCategory());

            // Act
            var result = await _todoCategoryService.GetTodoCaterogyByIdAsync(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<TodoCategory>(result);
        }

        [Test]
        public async Task CreateCategory_VerifyCreate()
        {
            // Arrange

            // Act
            await _todoCategoryService.CreateTodoCategoryAsync(It.IsAny<TodoCategory>());

            // Assert
            _repositoryMock.Verify(r => r.CreateAsync(It.IsAny<TodoCategory>()), Times.Once);
        }

        [Test]
        public async Task UpdateCategory_VerifyUpdate()
        {
            // Arrange

            // Act
            await _todoCategoryService.UpdateTodoCategoryAsync(It.IsAny<TodoCategory>());

            // Assert
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TodoCategory>()), Times.Once);
        }

        [Test]
        public async Task DeleteCategory_ReturnsTrue()
        {
            // Arrange
            _repositoryMock
                .Setup(c => c.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            await _todoCategoryService.DeleteTodoCategoryAsync(It.IsAny<int>());

            // Assert
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Once);
        }

        private IEnumerable<TodoCategory> CreateListOfTodoCategories()
            => new List<TodoCategory>()
            {
                new TodoCategory
                {
                    Id = 1,
                    Title = "Category 1",
                    TodoItems = new List<TodoItem>()
                },
                new TodoCategory
                {
                    Id = 2,
                    Title = "Category 2",
                    TodoItems = new List<TodoItem>()
                }
            };
    }
}
