using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoITA.BLL.DTO.TodoCategory;
using TodoITA.BLL.Services.Interfaces;
using TodoITA.DataAccess.Entities;
using TodoITA.WebApi.Controllers;
using TodoITA.WebApi.ViewModels;

namespace Tests.Controllers
{
    public class TodoCategoriesControllerTest
    {
        private TodoCategoriesController _categoriesController;
        private Mock<ITodoCategoryService> _categoriesServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _categoriesServiceMock = new Mock<ITodoCategoryService>();
            _mapperMock = new Mock<IMapper>();
            _categoriesController = new TodoCategoriesController(_categoriesServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetCategories_ReturnsIEnumerableViewModel()
        {
            // Arrange
            _categoriesServiceMock
                .Setup(c => c.GetTodoCategoriesAsync())
                .ReturnsAsync(new List<TodoCategory>());
            _mapperMock
                .Setup(m => m.Map<IEnumerable<TodoCategoryViewModel>>(It.IsAny<IEnumerable<TodoCategory>>()))
                .Returns(CreateListOfTodoCategoryViewModels());

            // Act
            IActionResult actionResult = await _categoriesController.GetCaterogies();
            var resultValue = (actionResult as ObjectResult).Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(resultValue);
            Assert.IsInstanceOf<IEnumerable<TodoCategoryViewModel>>(resultValue);
        }

        [Test]
        public async Task GetCategory_ReturnsEntity()
        {
            // Arrange
            _categoriesServiceMock
                .Setup(c => c.GetTodoCaterogyByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new TodoCategory());

            // Act
            IActionResult actionResult = await _categoriesController.GetCategoryById(It.IsAny<int>());
            var resultValue = (actionResult as ObjectResult).Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(resultValue);
            Assert.IsInstanceOf<TodoCategory>(resultValue);
        }

        [Test]
        public async Task CreateCategory_ReturnsCreatedViewModel()
        {
            // Arrange
            CreateTodoCategoryDto createTodoCategoryDto = new CreateTodoCategoryDto();
            _mapperMock
                .Setup(m => m.Map<TodoCategory>(It.IsAny<CreateTodoCategoryDto>()))
                .Returns(new TodoCategory());
            _mapperMock
                .Setup(m => m.Map<TodoCategoryViewModel>(It.IsAny<TodoCategory>()))
                .Returns(new TodoCategoryViewModel());

            // Act
            IActionResult actionResult = await _categoriesController.CreateCategory(createTodoCategoryDto);
            var resultValue = (actionResult as ObjectResult).Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<CreatedAtActionResult>(actionResult);
            Assert.IsNotNull(resultValue);
            Assert.IsInstanceOf<TodoCategoryViewModel>(resultValue);
        }

        [Test]
        public async Task UpdateCategory_ReturnsUpdatedViewModel()
        {
            // Arrange
            UpdateTodoCategoryDto updateTodoCategoryDto = new UpdateTodoCategoryDto();
            _categoriesServiceMock
                .Setup(c => c.GetTodoCaterogyByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new TodoCategory());
            _mapperMock.
                Setup(m => m.Map(updateTodoCategoryDto, It.IsAny<TodoCategory>()))
                .Returns(new TodoCategory());
            _mapperMock
                .Setup(m => m.Map<TodoCategoryViewModel>(It.IsAny<TodoCategory>()))
                .Returns(new TodoCategoryViewModel());

            // Act
            IActionResult actionResult = await _categoriesController.UpdateCategory(It.IsAny<int>(), updateTodoCategoryDto);
            var resultValue = (actionResult as ObjectResult).Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(resultValue);
            Assert.IsInstanceOf<TodoCategoryViewModel>(resultValue);
        }

        [Test]
        public async Task DeleteCategory_ReturnsOk()
        {
            // Arrange
            _categoriesServiceMock
                .Setup(c => c.DeleteTodoCategoryAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            IActionResult actionResult = await _categoriesController.DeleteCategory(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkResult>(actionResult);
        }

        private List<TodoCategoryViewModel> CreateListOfTodoCategoryViewModels()
            => new List<TodoCategoryViewModel>()
            {
                new TodoCategoryViewModel()
                {
                    Id = 1,
                    Title = "Category 1"
                },
                new TodoCategoryViewModel()
                {
                    Id = 2,
                    Title = "Category 2"
                }
            };
    }
}