using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Enities
{
    public class Product
    {
        
        [Display(Name = "ID")]
        public int ProductId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage ="Введите название")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Описание(Состав)")]
        [Required(ErrorMessage ="Введите описание")]
        public string Description { get; set; }

        [Display(Name ="Категория")]
        [Required(ErrorMessage ="Введите категорию товара")]
        public string Category { get; set; }

        [Display(Name ="Цена (грн)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Некорректная цена")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

    }
}
