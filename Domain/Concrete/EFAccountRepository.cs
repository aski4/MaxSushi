using System;
using Domain.Abstract;
using Domain.Enities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFAccountRepository : IAccountRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Account> Accounts
        {
            get { return context.Accounts; }
        }
        
    }
}
