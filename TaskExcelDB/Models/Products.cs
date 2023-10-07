using System.ComponentModel.DataAnnotations;

namespace TaskExcelDB.Models
{
    public class Products : Base
    {
        [Required(ErrorMessage = "name alanı boş bırakılamaz.")]
        public string name { get; set; }

        [Required(ErrorMessage = "category_id alanı boş bırakılamaz.")]
        public int category_id { get; set; }

        [Required(ErrorMessage = "price alanı boş bırakılamaz.")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "unit alanı boş bırakılamaz.")]
        public string unit { get; set; }

        [Required(ErrorMessage = "stock alanı boş bırakılamaz.")]
        public int stock { get; set; }

        [Required(ErrorMessage = "color alanı boş bırakılamaz.")]
        public string color { get; set; }

        [Required(ErrorMessage = "weight alanı boş bırakılamaz.")]
        public decimal weight { get; set; }

        [Required(ErrorMessage = "width alanı boş bırakılamaz.")]
        public decimal width { get; set; }

        [Required(ErrorMessage = "height alanı boş bırakılamaz.")]
        public decimal height { get; set; }

        public int added_user_id { get; set; }
        public int? updated_user_id { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? updated_date { get; set; }
    }
}
