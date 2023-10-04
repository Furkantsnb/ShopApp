﻿using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopapp.business.Abstract
{
    public interface IOrderService//sipariş hizmeti
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);//Sipariş al
    }
}
