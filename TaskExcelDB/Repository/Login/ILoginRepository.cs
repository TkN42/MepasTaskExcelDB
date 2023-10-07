using System;
using System.Collections.Generic;
using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.Login
{
    public interface ILoginRepository
    {
        Users GetUserByUsernameAndPassword(string username, string password);
    }
}
