using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.Categori
{
    public interface ICategoriRepository
    {
        TaskExcelDB.Models.Categories GetCategoriById(int? id);
        IEnumerable<TaskExcelDB.Models.Categories> GetAllCategoris();
        void AddCategori(TaskExcelDB.Models.Categories categori);
        void UpdateCategori(TaskExcelDB.Models.Categories categori);
        void DeleteCategori(int id);
    }
}