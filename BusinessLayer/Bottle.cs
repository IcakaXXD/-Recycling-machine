using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Bottle
    {
        [Key]
        public int Id { get; set; }
       
        public char Type { get; set; }
        public char Size { get; set; }
        [Range(0,100000,ErrorMessage ="Price must be greater than -1.")]
        public decimal Price { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        private Bottle()
        {

        }
        public Bottle(char type, char size,decimal price,int userId)
        {
            this.Type = type;
            Size = size;
            Price = price;
            UserId = userId;
        }
    }
}
