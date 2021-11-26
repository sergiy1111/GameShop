using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Models
{
    public class ProductInputViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Поле \"Назва\" має бути введено")]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "День Релізу")]
        [Required(ErrorMessage = "Поле \"День Релізу\" має бути введено")]
        public int Day { get; set; }
        [Display(Name = "Місяць Релізу")]
        [Required(ErrorMessage = "Поле \"Місяць Релізу\" має бути введено")]
        public int Month { get; set; }
        [Display(Name = "Рік Релізу")]
        [Required(ErrorMessage = "Поле \"Рік Релізу\" має бути введено")]
        public int Year { get; set; }

        [Display(Name = "Ціна")]
        [Required(ErrorMessage = "Поле \"Ціна\" має бути введено")]
        public double Price { get; set; }

        [Display(Name = "Рейтинг")]
        public double Raiting { get; set; }


        [Display(Name = "Розробник")]
        public int Developer { get; set; }


        [Display(Name = "Видавник")]
        public int Publisher { get; set; }

        [Display(Name = "Категорії")]
        public List<int> Categories { get; set; }

        [Display(Name = "Файли")]
        public List<HttpPostedFileBase> Files { get; set; }

        public List<string> FilesForEdit { get; set; }

        [Display(Name = "Процесор")]
        [Required(ErrorMessage = "Поле \"Процесор\" має бути введено")]
        public string Processor { get; set; }

        [Display(Name = "ОЗУ")]
        [Required(ErrorMessage = "Поле \"ОЗУ\" має бути введено")]
        public string RAM { get; set; }

        [Display(Name = "Відеокарта")]
        [Required(ErrorMessage = "Поле \"Відеокарта\" має бути введено")]
        public string VideoCard { get; set; }

        [Display(Name = "Місце на диску")]
        [Required(ErrorMessage = "Поле \"Місце на диску\" має бути введено")]
        public string DriveSpace { get; set; }

        [Display(Name = "Інші")]
        public string Other { get; set; }

        [Display(Name = "Операційні системи")]
        public List<int> OperatingSystems { get; set; }

        [Display(Name = "Ключі")]
        public List<string> Keys { get; set; }
    }
}