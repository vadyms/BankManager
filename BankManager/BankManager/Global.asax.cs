using Autofac;
//using Autofac.Integration.Mvc;
using BankManager.Interfaces;
using BankManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BankManager
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801


    public class MvcApplication : System.Web.HttpApplication
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute() );
        }

        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {

            var builder = new ContainerBuilder();
            //builder.RegisterControllers( typeof( MvcApplication ).Assembly );
            //builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType( typeof(ClientService)).AsImplementedInterfaces();
            builder.RegisterType( typeof(ClientRepository)).AsImplementedInterfaces();
            builder.RegisterType( typeof(StatusService)).AsImplementedInterfaces();
            builder.RegisterType( typeof(StatusRepository)).AsImplementedInterfaces();
            
            //builder.Register(c=> new ClientService(c.Resolve<IClient>()));
            var container = builder.Build();
            //DependencyResolver.SetResolver( new AutofacDependencyResolver( container ) );
            //var client = container.Resolve<IClientService>();

            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory( @"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True" );

            RegisterGlobalFilters( GlobalFilters.Filters );
            RegisterRoutes( RouteTable.Routes );
            log4net.Config.XmlConfigurator.Configure( new FileInfo( Server.MapPath( "~/Web.config" ) ) );
            logger.Info( "Logger started." );
        }
    }
}