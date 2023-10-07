using System;
using System.Collections.Generic;
using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.Product
{
    public interface IProductRepository
    {
        Products GetProductById(int? id);
        IEnumerable<Products> GetAllProducts();
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(int id);
    }
}
