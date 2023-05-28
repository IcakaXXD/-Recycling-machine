using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class BoxContext : IDb<Box, int>
    {
        private RecyclingmachineDbContext dbContext;
        public BoxContext(RecyclingmachineDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Box item)
        {
            try
            {
                dbContext.Boxes.Add(item);
                IQueryable<User> users = dbContext.Users;
                User user = users.FirstOrDefault(x => x.ID == item.UserId);
                if (user != null)
                {
                    user.Money += item.Price;
                    dbContext.Users.Update(user);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                Box boxFromDb = Read(key);

                if (boxFromDb != null)
                {
                    dbContext.Boxes.Remove(boxFromDb);
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

        public Box Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Box> query = dbContext.Boxes;

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

        public IEnumerable<Box> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Box> query = dbContext.Boxes;

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

        public void Update(Box item, bool useNavigationalProperties = false)
        {
             return;
        }
    }
}
