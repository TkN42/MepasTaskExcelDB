using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskExcelDB.Helpers;
using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {

        public LoginRepository()
        {
        }

        public Users GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo("Veritabani.xlsx")))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = package.Workbook.Worksheets["Users"]; // Excel sayfa adınızı buraya ekleyin

                    // Excel'den kullanıcıları okuma
                    var userList = new List<Users>();
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
                        });
                    }

                    // Kullanıcıyı doğrulama
                    var authenticatedUser = userList.Find(u => u.username == username && u.password == password);
                    return authenticatedUser;
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada ele alınabilir
                Console.WriteLine("Hata: " + ex.Message);
                return null;
            }
        }
    }
}
