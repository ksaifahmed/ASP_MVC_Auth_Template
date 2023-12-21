using GB.Inventory.Repository.BaseClasses;
using GB.Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Inventory.Repository.DatabaseRepositories
{
    public class UserRepository : EntityFrameworkRepository<User>
    {
        private readonly DatabaseContext context;
        public UserRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
    }
}
