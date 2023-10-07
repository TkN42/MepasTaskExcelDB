using System;
using System.Collections.Generic;
using System.Linq;
using TaskExcelDB.Helpers;
using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ExcelService _excelService;

        public ProductRepository(ExcelService excelService)
        {
            _excelService = excelService;
        }

        public Products GetProductById(int?  id)
        {
            // Excel'den belirli bir ürünü id'ye göre almak için
            var productList = _excelService.ReadProductsFromExcel("Veritabani.xlsx");
            return productList.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Products> GetAllProducts()
        {
            // Tüm ürünleri Excel'den almak için
            return _excelService.ReadProductsFromExcel("Veritabani.xlsx");
        }

        public void AddProduct(Products product)
        {
            // Yeni bir ürünü Excel'e eklemek için
            var productList = _excelService.ReadProductsFromExcel("Veritabani.xlsx");
            product.id = GetNextProductId(productList);
            productList.Add(product);
            _excelService.WriteProductsToExcel("Veritabani.xlsx", productList);
        }

        public void UpdateProduct(Products product)
        {
            // Bir ürünü Excel'de güncellemek için
            var productList = _excelService.ReadProductsFromExcel("Veritabani.xlsx");
            var existingProduct = productList.FirstOrDefault(p => p.id == product.id);

            if (existingProduct != null)
            {
                // Ürünü güncelle
                existingProduct.name = product.name;
                existingProduct.category_id = product.category_id;
                existingProduct.price = product.price;
                existingProduct.unit = product.unit;
                existingProduct.stock = product.stock;
                existingProduct.color = product.color;
                existingProduct.weight = product.weight;
                existingProduct.width = product.width;
                existingProduct.height = product.height;
                existingProduct.added_user_id = product.added_user_id;
                existingProduct.updated_user_id = product.updated_user_id;
                existingProduct.created_date = product.created_date;
                existingProduct.updated_date = product.updated_date;

                // Diğer özellikleri güncelle...

                _excelService.WriteProductsToExcel("Veritabani.xlsx", productList);
            }
        }

        public void DeleteProduct(int id)
        {
            // Bir ürünü Excel'den silmek için
            //var productList = _excelService.ReadProductsFromExcel("Veritabani.xlsx");
            //var productToDelete = productList.FirstOrDefault(p => p.id == id);

            //if (productToDelete != null)
            //{
            //    productList.Remove(productToDelete);
            //    _excelService.WriteProductsToExcel("Veritabani.xlsx", productList);
            //}
            _excelService.DeleteProductFromExcel("Veritabani.xlsx", id); // ID 1'e sahip ürünü siler
        }

        private int GetNextProductId(List<Products> productList)
        {
            // Yeni bir ürün için bir sonraki benzersiz id'yi almak için
            if(productList.Count == 0)
            {
                return 1;
            }
            else
            {
                var maxId = productList.Max(p => p.id);
                return maxId + 1;
            }
        }
    }
}
