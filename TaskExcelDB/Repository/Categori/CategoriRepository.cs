using System;
using System.Collections.Generic;
using System.Linq;
using TaskExcelDB.Helpers;
using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.Categori
{
    public class CategoriRepository : ICategoriRepository
    {
        private readonly ExcelService _excelService;

        public CategoriRepository(ExcelService excelService)
        {
            _excelService = excelService;
        }

        public Categories GetCategoriById(int? id)
        {
            // Excel'den belirli bir categoriyi id'ye göre almak için
            var categoriList = _excelService.ReadCategoriesFromExcel("Veritabani.xlsx");
            return categoriList.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Categories> GetAllCategoris()
        {
            // Tüm categorileri Excel'den almak için
            return _excelService.ReadCategoriesFromExcel("Veritabani.xlsx");
        }

        public void AddCategori(Categories categori)
        {
            // Yeni bir categoriyi Excel'e eklemek için
            var categoriList = _excelService.ReadCategoriesFromExcel("Veritabani.xlsx");
            categori.id = GetNextCategoriId(categoriList);
            categoriList.Add(categori);
            _excelService.WriteCategoriesToExcel("Veritabani.xlsx", categoriList);
        }

        public void UpdateCategori(Categories categori)
        {
            // Bir categoriyi Excel'de güncellemek için
            var categoriList = _excelService.ReadCategoriesFromExcel("Veritabani.xlsx");
            var existingCategori = categoriList.FirstOrDefault(p => p.id == categori.id);

            if (existingCategori != null)
            {
                // categoriyi güncelle
                existingCategori.name = categori.name;

                // Diğer özellikleri güncelle...

                _excelService.WriteCategoriesToExcel("Veritabani.xlsx", categoriList);
            }
        }

        public void DeleteCategori(int id)
        {
            // Bir categoriyi Excel'den silmek için
            //var categoriList = _excelService.ReadCategorisFromExcel("Veritabani.xlsx");
            //var CategoriToDelete = categoriList.FirstOrDefault(p => p.id == id);

            //if (CategoriToDelete != null)
            //{
            //    categoriList.Remove(CategoriToDelete);
            //    _excelService.WriteCategorisToExcel("Veritabani.xlsx", categoriList);
            //}
            _excelService.DeleteCategoriFromExcel("Veritabani.xlsx", id); // ID 1'e sahip categoriyi siler
        }

        private int GetNextCategoriId(List<Categories> categoriList)
        {
            // Yeni bir categori için bir sonraki benzersiz id'yi almak için
            if (categoriList.Count == 0)
            {
                return 1;
            }
            else
            {
                var maxId = categoriList.Max(p => p.id);
                return maxId + 1;
            }
        }
    }
}
