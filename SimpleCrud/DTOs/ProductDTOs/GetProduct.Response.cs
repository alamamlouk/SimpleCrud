﻿namespace SimpleCrud.DTOs.ProductDTOs
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
