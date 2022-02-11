using System;
using System.Threading.Tasks;
using EzTrading.Shared.Domain;
using Microsoft.AspNetCore.Http;

namespace EzTrading.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Cart> Carts { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Delivery> Deliveries { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Seller> Sellers { get; }
        IGenericRepository<Item> Items { get; }
    }
}