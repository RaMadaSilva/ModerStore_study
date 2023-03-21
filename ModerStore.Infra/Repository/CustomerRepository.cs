﻿using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.CommandResult;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repository;
using ModernStore.Infra.Context;
using ModernStore.Shared.Command;

namespace ModernStore.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDbContext _context;

        public CustomerRepository(ModernStoreDbContext context)
        {
            _context = context;
        }
        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x=>x.Document.Number ==document);
        }

        public Customer Get(Guid id)
        {
            var customer = _context.Customers
                .Include(x=>x.User)
                .AsNoTracking()
                .FirstOrDefault(x=>x.Id ==id);

            return customer; 
        }

        public ICommandResult Get(string userName)
        {
            var result = _context.Customers
               .Include(x => x.User)
               .AsNoTracking()
               .Select(x => new
                        GetCustomerCommandResult(x.Name.ToString(),
                               x.Document.Number,
                               x.Email.Adress,
                               x.User.UserName,
                               x.User.Passeword,
                               x.User.Active)).FirstOrDefault(x => x.UserName == userName);

            return result; 
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges(); //passará para o unite of Work
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified; 
        }
    }
}
