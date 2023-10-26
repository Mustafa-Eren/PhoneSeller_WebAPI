using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PhoneSeller_WebAPI.Enums
{
    public enum StockStatus
    {
        [Display(Name = "Mevcut Değil")]
        NotAvailable = 0,
        [Display(Name = "Mevcut")]
        Available = 1,
    }
}
