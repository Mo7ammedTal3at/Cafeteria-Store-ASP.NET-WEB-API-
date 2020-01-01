using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDemo.Models.ViewModels.StoreViewModels.GoodsViewModels
{
    public class GoodsPostViewModel
    {
        public int SellerId { get; set; }
        [Index(IsUnique = true)]
        [StringLength(255)]
        [Required(ErrorMessage = "لابد من ادخال اسم المنتج")]
        public string Name { get; set; }
        [Required(ErrorMessage = "لابد من ادخال سعر البيع")]
        public float SellPrice { get; set; }
        [Required(ErrorMessage = "لابد من ادخال اسم الجملة")]
        public float BuyPrice { get; set; }
        [Required(ErrorMessage = "لابد من ادخال عدد الكراتين")]
        public int NumberOfBoxes { get; set; }
        public int NumberOfItemsInBox { get; set; }
        public int AlertLimit { get; set; }
        public int CategoryId { get; set; }
    }
}