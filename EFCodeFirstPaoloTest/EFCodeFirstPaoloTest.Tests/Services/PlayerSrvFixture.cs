using System.Collections.Generic;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Repository;
using EFCodeFirstPaoloTest.Services;
using Moq;
using NUnit.Framework;

namespace EFCodeFirstPaoloTest.Tests.Services
{
    [TestFixture]
    public class PlayerSrvFixture
    {
        private Mock<IRepository<Player>> _playerRepositoryMock;
        private PlayerService _playerService;

        [SetUp]
        public void Init()
        {
            _playerRepositoryMock = new Mock<IRepository<Player>>();
            _playerService = new PlayerService(_playerRepositoryMock.Object);
        }

        [Test]
        public void GetAll()
        {
            //Arrange
            _playerRepositoryMock.Setup(x => x.GetAll()).Returns(FakePlayersCollection);
            //Act
            var result = _playerService.GetAll();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Player>>(result);
            Assert.AreEqual(result.Count, FakePlayersCollection.Count);
            Assert.AreEqual(result[0].Name, FakePlayersCollection[0].Name);
            Assert.AreEqual(result[0].Surname, FakePlayersCollection[0].Surname);
            Assert.AreEqual(result[1].Name, FakePlayersCollection[1].Name);
            Assert.AreEqual(result[1].Surname, FakePlayersCollection[1].Surname);
        }

        #region private props and functions

        public List<Player> FakePlayersCollection
        {
            get
            {
                return new List<Player>
                {
                    new Player
                    {
                        Name = "paolo",
                        Surname = "regoli"
                    },
                    new Player
                    {
                        Name = "paolo 1",
                        Surname = "regoli 1"
                    }
                };
            }
        }

        #endregion
    }
}
