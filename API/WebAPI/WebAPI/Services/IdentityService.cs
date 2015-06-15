using System.Threading;
using WebAPI.Services.Interface;

namespace WebAPI.Services
{
    public class IdentityService : IIdentityService
    {
        public string GetUser()
        {
            return Thread.CurrentPrincipal.Identity.Name;
        }
    }
}