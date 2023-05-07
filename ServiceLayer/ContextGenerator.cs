using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ContextGenerator
    {
        public static RecyclingmachineDbContext dbContext;
        public static UserContext usersContext;
        public static BottleContext bottlesContext;

        public static RecyclingmachineDbContext GetDbContext()
        {
            if (dbContext == null)
            {
                SetDbContext();
            }
            return dbContext;
        }

        public static void SetDbContext()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }

            dbContext = new RecyclingmachineDbContext();
        }

        public static UserContext GetUsersContext()
        {
            if (usersContext == null)
            {
                SetUsersContext();
            }

            return usersContext;
        }

        public static void SetUsersContext()
        {
            usersContext = new UserContext(GetDbContext());
        }

        public static BottleContext GetBottlesContext()
        {
            if (bottlesContext == null)
            {
                SetBottlesContext();
            }

            return bottlesContext;
        }

        public static void SetBottlesContext()
        {
            bottlesContext = new BottleContext(GetDbContext());
        }


    }
}
