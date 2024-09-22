using System.Net;
using System.Security.Cryptography.X509Certificates;
using Identity.DAL.Users;
using Microsoft.Extensions.DependencyInjection;
using Shared.DAL;
using Shared.Helpers.Services;

namespace Identity.Users;

public class UserService(IUserRepository userRepository, [FromKeyedServices("uowIdentity")] IUnitOfWork unitOfWork) : IUserService
{
}
