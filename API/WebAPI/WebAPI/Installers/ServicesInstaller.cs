using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Services;
using WebAPI.Services.Interface;

namespace WebAPI.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IIdentityService>().ImplementedBy<IdentityService>().LifeStyle.PerWebRequest);
        }
    }
}