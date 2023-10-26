using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PhoneSeller_WebAPI.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Tamamlandı")]
        Completed = 0,
        [Display(Name = "Devam Ediyor")]
        Continues = 1,
    }
}
