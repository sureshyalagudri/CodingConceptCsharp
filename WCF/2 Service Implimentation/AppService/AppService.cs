using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Entities;
using Zza.Data;
using System.ServiceModel;

namespace AppService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    class AppService : IAppService, IDisposable
    {
        readonly ZzaDbContext dbContext = new ZzaDbContext();
        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
        public List<Customer> GetCustomers()
        {
            return dbContext.Customers.ToList();
        }

        [OperationBehavior(TransactionScopeRequired=true)]
        public void SubmitOrder(Order order)
        {
            dbContext.Orders.Add(order);
            order.OrderItems.ForEach(oi=> dbContext.OrderItems.Add(oi));
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}   
