using System;
using System.Linq;
using System.Threading.Tasks;
using EzTrading.Server.Data;
using EzTrading.Server.IRepository;
using EzTrading.Server.Models;
using EzTrading.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EzTrading.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Item> _items;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<Delivery> _deliveries;
        private IGenericRepository<Cart> _carts;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Seller> _sellers;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Item> Items
            => _items ??= new GenericRepository<Item>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<Delivery> Deliveries
            => _deliveries ??= new GenericRepository<Delivery>(_context);
        public IGenericRepository<Cart> Carts
            => _carts ??= new GenericRepository<Cart>(_context);
        public IGenericRepository<Seller> Sellers
            => _sellers ??= new GenericRepository<Seller>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);



        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}