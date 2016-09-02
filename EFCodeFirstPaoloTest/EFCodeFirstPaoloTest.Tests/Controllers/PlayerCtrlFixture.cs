using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Controllers;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Repository;
using EFCodeFirstPaoloTest.Services;
using EFCodeFirstPaoloTest.Services.Interfaces;
using Moq;
using NUnit;
using NUnit.Framework;

namespace EFCodeFirstPaoloTest.Tests.Controllers
{
    [TestFixture]
    public class PlayerCtrlFixture
    {
        private Mock<IPlayerService> _playerServiceMock;
        private Mock<ITeamService> _teamServiceMock;
        private Mock<IRepository<Player>> _playerRepositoryMock;
        private PlayerService _playerService;
        private PlayersController _playersCtrl;
        
        [SetUp]
        public void Initialize()
        {
            _playerServiceMock = new Mock<IPlayerService>();
            _teamServiceMock = new Mock<ITeamService>();
            _playerRepositoryMock = new Mock<IRepository<Player>>();
            _playerService = new PlayerService(_playerRepositoryMock.Object);
            _playersCtrl = new PlayersController(_playerServiceMock.Object, _teamServiceMock.Object);
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
