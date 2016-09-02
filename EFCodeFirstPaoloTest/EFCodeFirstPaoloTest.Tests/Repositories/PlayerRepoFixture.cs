using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Context;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Repository;
using Moq;
using NUnit.Framework;

namespace EFCodeFirstPaoloTest.Tests.Repositories
{
    [TestFixture]
    public class PlayerRepoFixture
    {
        private LeagueDbContext _context;
        private PlayerRepository _playerRepository;

        [SetUp]
        public void Init()
        {
            _context = new LeagueDbContext
            {
                Players = MockDbSet(FakePlayersCollection[0], FakePlayersCollection[1]),
                Teams = MockDbSet(FakePlayersCollection[0].Team, FakePlayersCollection[1].Team)
            };
        }

        [Test]
        public void GetAll()
        {
            //Arrange
            _playerRepository = new PlayerRepository(_context);
            //Act
            var result = _playerRepository.GetAll();

            //Assert
            Assert.IsNotNull(result);
        }


        #region props and functions

        /// <summary>
        /// Return the DbSet by passing items from a fake collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <returns></returns>
        private static DbSet<T> MockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            dbSet.Setup(s => s.Include(It.IsAny<string>())).Returns(dbSet.Object);

            return dbSet.Object;
        }

        private static List<Player> FakePlayersCollection
        {
            get
            {
                return new List<Player>
                {
                    new Player
                    {
                        PlayerId = 0,
                        Name = "paolo",
                        Surname = "regoli",
                        Team = new Team{ TeamId = 0, Name = "team", Color = "blue"},
                        //TeamId = 0
                    },
                    new Player
                    {
                        PlayerId = 1,
                        Name = "paolo 1",
                        Surname = "regoli 1",
                        Team = new Team{ TeamId = 1, Name = "team1", Color = "red"},
                        //TeamId = 1
                    }
                };
            }
        }

        private static List<Team> FakeTeamsCollection
        {
            get
            {
                return new List<Team>
                {
                    new Team
                    {
                        TeamId = 0,
                        Name = "team 0",
                        Color = "blue",
                        Players = new List<Player>{new Player{ Name = "paolo", Surname = "regoli", PlayerId = 0}}
                    },
                    new Team
                    {
                        TeamId = 1,
                        Name = "team 1",
                        Color = "Red",
                        Players = new List<Player>{new Player{ Name = "paolo 1", Surname = "regoli 1", PlayerId = 1}}
                    }
                };
            }
        }

        #endregion
    }
}
