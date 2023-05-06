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
        RecyclingmachineDbContext dbContext;

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

        public Bottle Read(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bottle> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Bottle item)
        {
            throw new NotImplementedException();
        }
    }
}
