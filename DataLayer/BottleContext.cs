using BusinessLayer;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                dbContext.Bottles.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bottle Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Bottle> query = dbContext.Bottles;

                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.User);
                      
                }

                return query.FirstOrDefault(p => p.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Bottle> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Bottle> query = dbContext.Bottles;

                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.User);
                   
                }

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Bottle item, bool useNavigationalProperties = false)
        {
            return;
        }

        public void Delete(int key)
        {
            try
            {
                Bottle bottleFromDb = Read(key);

                if (bottleFromDb != null)
                {
                    dbContext.Bottles.Remove(bottleFromDb);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Product with that Id does not exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
