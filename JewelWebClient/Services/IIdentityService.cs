using JewelWebClient;
using System.Security.Principal;

namespace JewelWebClient.Services
    {
    public interface IIdentityService<T>
        {
        T Get(IPrincipal principal);
        }
    }
