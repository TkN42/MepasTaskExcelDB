using System;
using System.Collections.Generic;
using System.Linq;
using TaskExcelDB.Helpers;
using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ExcelService _excelService;

        public UserRepository(ExcelService excelService)
        {
            _excelService = excelService;
        }

        public Users GetUserById(int? id)
        {
            // Excel'den belirli bir kullanıcıyı id'ye göre almak için
            var userList = _excelService.ReadUsersFromExcel("Veritabani.xlsx");
            return userList.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Users> GetAllUsers()
        {
            // Tüm kullanıcıları Excel'den almak için
            return _excelService.ReadUsersFromExcel("Veritabani.xlsx");
        }

        public void AddUser(Users user)
        {
            // Yeni bir kullanıcıyı Excel'e eklemek için
            var userList = _excelService.ReadUsersFromExcel("Veritabani.xlsx");
            user.id = GetNextUserId(userList);
            userList.Add(user);
            _excelService.WriteUsersToExcel("Veritabani.xlsx", userList);
        }

        public void UpdateUser(Users user)
        {
            // Bir kullanıcıyı Excel'de güncellemek için
            var userList = _excelService.ReadUsersFromExcel("Veritabani.xlsx");
            var existingUser = userList.FirstOrDefault(p => p.id == user.id);

            if (existingUser != null)
            {
                // kullanıcıyı güncelle
                existingUser.name = user.name;
                existingUser.surname = user.surname;
                existingUser.username = user.username;
                existingUser.password = user.password;
                existingUser.status = user.status;

                _excelService.WriteUsersToExcel("Veritabani.xlsx", userList);
            }
        }

        public void DeleteUser(int id)
        {
            // Bir kullanıcıyı Excel'den silmek için
            //var UserList = _excelService.ReadUsersFromExcel("Veritabani.xlsx");
            //var UserToDelete = UserList.FirstOrDefault(p => p.id == id);

            //if (UserToDelete != null)
            //{
            //    UserList.Remove(UserToDelete);
            //    _excelService.WriteUsersToExcel("Veritabani.xlsx", UserList);
            //}
            _excelService.DeleteUserFromExcel("Veritabani.xlsx", id); // ID 1'e sahip kullanıcıyı siler
        }

        private int GetNextUserId(List<Users> userList)
        {
            // Yeni bir kullanıcı için bir sonraki benzersiz id'yi almak için
            if (userList.Count == 0)
            {
                return 1;
            }
            else
            {
                var maxId = userList.Max(p => p.id);
                return maxId + 1;
            }
        }
    }
}
