using CandyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Core.Interface
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
