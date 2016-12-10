using System.Web.Mvc;
using System.Reflection;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DaysCalculator.BLL.Services.ServiceImpl;
using DaysCalculator.BLL.Services.ServiceInterfaces;

namespace DaysCalculator.WindsorConfiguration
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            //Register all controllers
            container.Register(
                //All services
                Classes.FromAssembly(Assembly.GetAssembly(typeof(ICustomDateService))).
                    InSameNamespaceAs<CustomDateService>().WithService.DefaultInterfaces().LifestylePerWebRequest(),

                //All MVC controllers
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient(),

                //All API Controllers
                Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient()

                //All DbContexts
                //Component.For<DemoEntities>()
                //                    .LifestylePerWebRequest().IsDefault()
                //
            );

            //Register Facilities
            container.AddFacility<EntityFrameWorkRelatedFacility>();
            container.AddFacility<GeneralFacility>();


        }

    }
}