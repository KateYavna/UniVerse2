using Moq;
using UniVerse.Models;
using UniVerse.Services.Interfaces;
using UniVerse.Services;

namespace Tests
{
    [TestFixture]
    public class ClientServiceTests
    {
        [Test]
        public async Task CreateClient_ShouldReturnTrue()
        {
            // Arrange
            var clientService = new ClientService(MockDbServiceForEditData(1));

            // Act
            var result = await clientService.CreateClient(new Client());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteClient_ShouldReturnTrue()
        {
            // Arrange
            var clientService = new ClientService(MockDbServiceForEditData(1));

            // Act
            var result = await clientService.DeleteClient(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetClient_ShouldReturnClient()
        {
            // Arrange
            var clientService = new ClientService(MockDbServiceForGetAsync(new Client()));

            // Act
            var result = await clientService.GetClient(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Client>(result);
        }

        [Test]
        public async Task GetClientList_ShouldReturnClientList()
        {
            // Arrange
            var clientService = new ClientService(MockDbServiceForGetAll(new[] { new Client(), new Client() }));

            // Act
            var result = await clientService.GetClientList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Client>>(result);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdateClient_ShouldReturnUpdatedClient()
        {
            // Arrange
            var clientService = new ClientService(MockDbServiceForEditData(1));

            // Act
            var result = await clientService.UpdateClient(new Client());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Client>(result);
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
