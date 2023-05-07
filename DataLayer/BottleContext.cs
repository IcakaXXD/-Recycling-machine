using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BottleContext : IDb<Bottle, int>
    {
        private RecyclingmachineDbContext dbContext;

        public BottleContext(RecyclingmachineDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Bottle item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Bottle Read(int key, bool useNavigationalProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bottle> ReadAll(bool useNavigationalProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(Bottle item, bool useNavigationalProperties)
        {
            throw new NotImplementedException();
        }
    }
}
