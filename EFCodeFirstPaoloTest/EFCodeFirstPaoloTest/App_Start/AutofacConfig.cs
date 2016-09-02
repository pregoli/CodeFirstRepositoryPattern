using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using EFCodeFirstPaoloTest.Context;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Repository;
using EFCodeFirstPaoloTest.Services;
using EFCodeFirstPaoloTest.Services.Interfaces;

namespace EFCodeFirstPaoloTest.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer RegisterDependencies()
        {
            #region Create the builder
            var builder = new ContainerBuilder();
            #endregion

            #region Register all controllers for the assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            #endregion

            #region refister action filters
            //builder.RegisterFilterProvider();
            
            //builder.RegisterType<RequireTeamsList>().PropertiesAutowired();
            #endregion

            #region register services
            builder.RegisterType<PlayerService>().As<IPlayerService>();
            builder.RegisterType<TeamService>().As<ITeamService>();
            #endregion

            builder
              .RegisterType<LeagueDbContext>()
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            builder.Register<IRepository<Player>>(c => new PlayerRepository(new LeagueDbContext()));
            builder.Register<IRepository<Team>>(c => new TeamRepository(new LeagueDbContext()));

            return builder.Build();
        }
    }
}
