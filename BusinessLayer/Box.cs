using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Box
    {
        [Key]
        public int Id { get; set; }
        public char Type { get; set; }
        //c(carton)
        //p(plastic)
        //w(wood)
        public char Size { get; set; }
        // s(small) - do h(high)-1m na w(width)-1m na l(lenght)-1m
        // m(medium) - ot s(h,w,l) do 1,5m na 1,5m na 1,5m
        // b(big) - ot m(h,w,l) do 2,5m na 2,5m na 2,5m
        // h(huge) - poveche on b(h,w,l)
        public int Amount { get; set; }
        [Range(0, 100000, ErrorMessage = "Price must be greater than -1.")]
        public double Price { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        private Box()
        {

        }
        public Box(char type, char size, int amaunt, double price, int userId)
        {
            this.Type = type;
            Size = size;
            Amount = amaunt;
            Price = price;
            UserId = userId;
        }
    }
}
