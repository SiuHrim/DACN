using System.Collections.Generic;

namespace DABanDan.InputModels.Product
{
    public class ProductIndexModel
    {
        public IEnumerable<object> Orders { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<ProductViewModel> TimKiem { get; set; }
    }
}