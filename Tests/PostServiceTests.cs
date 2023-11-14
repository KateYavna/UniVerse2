using Moq;
using UniVerse.Models;
using UniVerse.Services.Interfaces;
using UniVerse.Services;

namespace Tests
{
    [TestFixture]
    public class PostServiceTests
    {
        [Test]
        public async Task CreatePost_ShouldReturnTrue()
        {
            // Arrange
            var postService = new PostService(MockDbServiceForEditData(1));

            // Act
            var result = await postService.CreatePost(new Post());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeletePost_ShouldReturnTrue()
        {
            // Arrange
            var postService = new PostService(MockDbServiceForEditData(1));

            // Act
            var result = await postService.DeletePost(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetPost_ShouldReturnPost()
        {
            // Arrange
            var postService = new PostService(MockDbServiceForGetAsync(new Post()));

            // Act
            var result = await postService.GetPost(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Post>(result);
        }

        [Test]
        public async Task GetPostList_ShouldReturnPostList()
        {
            // Arrange
            var postService = new PostService(MockDbServiceForGetAll(new[] { new Post(), new Post() }));

            // Act
            var result = await postService.GetPostList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Post>>(result);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdatePost_ShouldReturnUpdatedPost()
        {
            // Arrange
            var postService = new PostService(MockDbServiceForEditData(1));

            // Act
            var result = await postService.UpdatePost(new Post());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Post>(result);
        }

        private IDbService MockDbServiceForEditData(int returnValue)
        {
            var mockDbService = new Mock<IDbService>();
            mockDbService.Setup(x => x.EditData(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(returnValue);
            return mockDbService.Object;
        }

        private IDbService MockDbServiceForGetAsync<T>(T returnValue)
        {
            var mockDbService = new Mock<IDbService>();
            mockDbService.Setup(x => x.GetAsync<T>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(returnValue);
            return mockDbService.Object;
        }

        private IDbService MockDbServiceForGetAll<T>(IEnumerable<T> returnValue)
        {
            var mockDbService = new Mock<IDbService>();
            mockDbService.Setup(x => x.GetAll<T>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(returnValue.ToList()));
            return mockDbService.Object;
        }
    }
}