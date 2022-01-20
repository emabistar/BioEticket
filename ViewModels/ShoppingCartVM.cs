using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data.Cart;

namespace bioticket.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart  ShoppingCart{ get; set; }
        public double ShoppingCartTotal  { get; set; }
    }
}
