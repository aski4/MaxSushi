using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enities
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage ="Введите Имя")]
        public string AccountName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Введите пароль")]
        public string AccountPassword { get; set; }

        public string AccountType { get; set; }
    }
}
