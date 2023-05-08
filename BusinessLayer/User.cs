using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Range(5,30,ErrorMessage ="Name must not be smaller than 5 symbols and larger than 30 symbols.")]
        public string Name { get; set; }

        [Range(0,10000000,ErrorMessage ="Money cannot be less than zero.")]
        public decimal Money { get; set; }

        public List<Bottle> bottles { get; set; }

        private User()
        {
            bottles = new List<Bottle>();
        }
        public User(string name)
        {
            this.Name = name;
            Money = 0;
            bottles = new List<Bottle>();
        }

    }
}
