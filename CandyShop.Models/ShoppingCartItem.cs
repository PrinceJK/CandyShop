﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class ShoppingCartItem
    {
        public string Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
