using System;
using Shared.DAL;

namespace Identity.DAL;

/// <summary>
/// niye tanımladım ? benzersiz interface ihtiyacını karşılamak için.
/// Api tanımlanmaz ise IUnitOfWork birden fazla nımlanır. public interface IIdentityUnitOfWork : IUnitOfWork;
/// diğer cözüm;
/// builder.Services.AddKeyedSingleton<IService, ServiceA>("ServiceA");
/// builder.Services.AddKeyedSingleton<IService, ServiceB>("ServiceB");
/// </summary>
public class IdentityUnitOfWork(IdentityDbContext context) : UnitOfWork(context)
{
}
