using System.Collections.Generic;

namespace DABanDan.InputModels.Category
{
    public class CategoryIndexModel
    {
        public IEnumerable<object> Orders { get; set; }
        public IEnumerable<CategoryViewModel> Categorys { get; set; }
    }
}