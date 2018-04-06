using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="Введите пожалуйста имя")]
        public string Name { get; set; }

        [Display(Name ="Адрес")]
        [Required(ErrorMessage ="Введите пожалуйста адрес")]
        public string Line1 { get; set; }
        [Display(Name = "Адрес дополнительный")]
        public string Line2 { get; set; }
        [Display(Name = "Адрес дополнительный")]
        public string Line3 { get; set; }

        [Display(Name ="Номер телефона")]
        [RegularExpression("([+]?[3]?[8])?[0]\\d{2}[-. ]?\\d{3}[-. ]?\\d{2}[-. ]?\\d{2}", ErrorMessage = "Некорректный номер")]
        [Required(ErrorMessage ="Введите номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("(\\w*\\d*)*[-.]?(\\w*\\d*)?[@]\\w{1,10}[.]\\w{1,6}", ErrorMessage ="Некорректный Email адрес")]
        [Required(ErrorMessage ="Введите email")]
        public string CustomerEmail { get; set; }

        public bool GiftWrap { get; set; }
    }
}
