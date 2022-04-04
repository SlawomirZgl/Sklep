using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }
        public double Count { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        [ForeignKey("Product")]
        public int IdProduct{ get; set; }
    }
}
