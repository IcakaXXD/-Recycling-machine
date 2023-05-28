using BusinessLayer;
using Microsoft.EntityFrameworkCore;
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
            try
            {
             

                dbContext.Users.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                   query = query.Include(p => p.bottles);
                   query = query.Include(p => p.boxes);

                }

                return query.FirstOrDefault(p => p.ID == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.bottles);
                    query = query.Include(p => p.boxes);
                }

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User item, bool useNavigationalProperties = false)
        {
            try
            {
                User userFromDb = Read(item.ID, useNavigationalProperties);

                if (userFromDb == null)
                {
                    Create(item);
                    return;
                }

                userFromDb.Name = item.Name;
                userFromDb.Money = item.Money;

               

                dbContext.SaveChanges();
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
                User userFromDb = Read(key);

                if (userFromDb != null)
                {
                    dbContext.Users.Remove(userFromDb);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Product with that ID does not exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

