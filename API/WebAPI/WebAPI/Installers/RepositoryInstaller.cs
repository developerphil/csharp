using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IExampleRepository>().ImplementedBy<ExampleRepository>().LifeStyle.PerWebRequest);
        }
    }
}