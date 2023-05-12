﻿namespace CartApi.Model
    {
    public class Cart
        {
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; }
        public Cart() { }

        public Cart(string cartId) 
            {
            BuyerId = cartId;
            Items = new List<CartItem>();
            }
        }
    }
