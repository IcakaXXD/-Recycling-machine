using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, int>
    {

        private RecyclingmachineDbContext dbContext;

        public UserContext(RecyclingmachineDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public User Read(int key, bool useNavigationalProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ReadAll(bool useNavigationalProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(User item, bool useNavigationalProperties)
        {
            throw new NotImplementedException();
        }
    }
}
