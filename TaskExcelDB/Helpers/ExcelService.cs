using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml; // NuGet paketi EPPlus ile eklenir
using static OfficeOpenXml.ExcelErrorValue;

namespace TaskExcelDB.Helpers
{
    public class ExcelService
    {
        #region Product
        public List<Products> ReadProductsFromExcel(string filePath)
        {
            var productList = new List<Products>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Products"];
                var dimension = worksheet.Dimension;
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // İlk satır başlıklar olduğu için 2'den başlattım
                {
                    productList.Add(new Products
                    {
                        id = Convert.ToInt32(worksheet.Cells[row, 14].Value),
                        name = worksheet.Cells[row, 1].Value.ToString() ?? "",
                        category_id = Convert.ToInt32(worksheet.Cells[row, 2].Value),
                        price = Convert.ToDecimal(worksheet.Cells[row, 3].Value),
                        unit = worksheet.Cells[row, 4].Value.ToString(),
                        stock = Convert.ToInt32(worksheet.Cells[row, 5].Value),
                        color = worksheet.Cells[row, 6].Value.ToString(),
                        weight = Convert.ToDecimal(worksheet.Cells[row, 7].Value),
                        width = Convert.ToDecimal(worksheet.Cells[row, 8].Value),
                        height = Convert.ToDecimal(worksheet.Cells[row, 9].Value),
                        added_user_id = Convert.ToInt32(worksheet.Cells[row, 10].Value),
                        updated_user_id = worksheet.Cells[row, 11].Value != null ? Convert.ToInt32(worksheet.Cells[row, 11].Value) : null, 
                        created_date = DateTime.FromOADate((double)worksheet.Cells[row, 12].Value),
                        updated_date = worksheet.Cells[row, 13].Value != null ? DateTime.FromOADate((double)worksheet.Cells[row, 13].Value) : null 

                    });

                }
                //package.Save();
            }

            return productList;
        }

        public void WriteProductsToExcel(string filePath, List<Products> productList)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Products"];
                worksheet.Cells.LoadFromCollection(productList, true);
                package.Save();
            }
        }

        public void DeleteProductFromExcel(string filePath, int productId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Products"];

                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var cellValue = worksheet.Cells[row, 14].Value; // ID hücresini kontrol ediyorum
                    if (cellValue != null && Convert.ToInt32(cellValue) == productId)
                    {
                        worksheet.DeleteRow(row); // bulunan ürünün satırını siliyorum
                        break; 
                    }
                }

                package.Save();
            }
        }
        #endregion

        #region Categori
        public List<Categories> ReadCategoriesFromExcel(string filePath)
        {
            var categoriList = new List<Categories>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Categories"]; 
                var dimension = worksheet.Dimension;
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) 
                {
                    categoriList.Add(new Categories
                    {
                        id = Convert.ToInt32(worksheet.Cells[row, 2].Value),
                        name = worksheet.Cells[row, 1].Value.ToString()

                    });

                }
                //package.Save();
            }

            return categoriList;
        }

        public void WriteCategoriesToExcel(string filePath, List<Categories> categoriList)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Categories"];
                worksheet.Cells.LoadFromCollection(categoriList, true);
                package.Save();
            }
        }

        public void DeleteCategoriFromExcel(string filePath, int categoriId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Categories"];

                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var cellValue = worksheet.Cells[row, 2].Value; 
                    if (cellValue != null && Convert.ToInt32(cellValue) == categoriId)
                    {
                        worksheet.DeleteRow(row); 
                        break; 
                    }
                }

                package.Save();
            }
        }
        #endregion

        #region User
        public List<Users> ReadUsersFromExcel(string filePath)
        {
            var userList = new List<Users>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Users"];
                var dimension = worksheet.Dimension;
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) 
                {
                    userList.Add(new Users
                    {
                        id = Convert.ToInt32(worksheet.Cells[row, 6].Value),
                        name = worksheet.Cells[row, 1].Value.ToString(),
                        surname = worksheet.Cells[row, 2].Value.ToString(),
                        username = worksheet.Cells[row, 3].Value.ToString(),
                        password = worksheet.Cells[row, 4].Value.ToString(),
                        status = Convert.ToBoolean(worksheet.Cells[row, 5].Value.ToString())
                        //status = worksheet.Cells[row, 6].Value != null && worksheet.Cells[row, 6].Value.ToString().Equals("true", StringComparison.OrdinalIgnoreCase)

                    });

                }
                //package.Save();
            }

            return userList;
        }

        public void WriteUsersToExcel(string filePath, List<Users> userList)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Users"];
                worksheet.Cells.LoadFromCollection(userList, true);
                package.Save();
            }
        }

        public void DeleteUserFromExcel(string filePath, int userId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets["Users"];

                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var cellValue = worksheet.Cells[row, 6].Value; 
                    if (cellValue != null && Convert.ToInt32(cellValue) == userId)
                    {
                        worksheet.DeleteRow(row); 
                        break; 
                    }
                }

                package.Save();
            }
        }
        #endregion

    }

}
