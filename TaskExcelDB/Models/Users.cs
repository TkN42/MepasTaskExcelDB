using System.ComponentModel.DataAnnotations;

namespace TaskExcelDB.Models
{
    public class Users : Base
    {
        public string name { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string surname { get; set; }
        public string username { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool status { get; set; }
    }
}
