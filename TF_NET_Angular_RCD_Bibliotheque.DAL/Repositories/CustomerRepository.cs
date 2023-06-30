using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.DAL.DataContext;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryContext dbContext) : base(dbContext) { }

        public Customer? Login(string pseudo, byte[] password)
        {
            return _entities.SingleOrDefault(e => e.Pseudo == pseudo && e.Password == password);
        }
    }
}
