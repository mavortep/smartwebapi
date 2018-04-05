﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSmartv2.Infrastructure;

namespace WebApiSmartv2.Models
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}