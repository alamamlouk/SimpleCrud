﻿namespace SimpleCrud.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
        public List <Product> Products { get; set; } 
    }
}
