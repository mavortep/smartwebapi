﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSmartv2.Infrastructure;

namespace WebApiSmartv2.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                    .Where(p => p.Product.Id == product.Id)
                    .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
    }
}