using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ly.MyBarRepository.Models
{
    public class Order
    {
        public ICollection<Food> Foods { get; set; }
    }
}
