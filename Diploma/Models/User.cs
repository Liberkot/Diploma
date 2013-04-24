using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SelectListItem = System.Web.WebPages.Html.SelectListItem;

namespace Diploma.Models
{
    public class Users
    {
        //Данные о ребёнке
        [Required(ErrorMessage = "Необходимо ввести Имя")]
        [RegularExpression(@"^[а-яА-яёЁ\-]{2,}$", ErrorMessage = "Неверный формат имени")]
        [Display(Name = "Имя")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Необходимо ввести Фамилию")]
        [RegularExpression(@"^[а-яА-яёЁ\-]{2,}$", ErrorMessage = "Неверный формат фамилии")]
        [Display(Name = "Фамилия")]
        public string second_name { get; set; }

        [Required(ErrorMessage = "Необходимо ввести Отчество")]
        [Display(Name = "Отчество")]
        public string third_name { get; set; }

        //[Required(ErrorMessage = "Необходимо ввести Дату рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime date_birth { get; set; }

        [Required(ErrorMessage = "Необходимо указать Пол ребёнка")]
        [Display(Name = "Пол")]
        public bool sex { get; set; }

        [Required(ErrorMessage = "Необходимо указать Тип документа")]
        [Display(Name = "Тип документа")]
        public string type_doc { get; set; }

        [Required(ErrorMessage = "Необходимо указать Серию документа")]
        [RegularExpression(@"^([IVXLCDM\d]+)-([А-Я]{2})$", ErrorMessage = "Неверная серия документа")]
        [Display(Name = "Серия документа")]
        public string series_doc { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Неверный номер документа")]
        [Display(Name = "Номер документа")]
        public string number_doc { get; set; }

        //[Required(ErrorMessage = "Необходимо ввести Дату выдачи")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yy}", ApplyFormatInEditMode=true)]
        [Display(Name = "Дата выдачи")]
        public DateTime date_issue { get; set; }

        //Адрес проживания ребёнка
        /*private List<SelectListItem> streets = new List<SelectListItem>();
        private List<SelectListItem> _houses = new List<SelectListItem>();
        public List<SelectListItem> Streets
        {
            get { return streets; }
        }

        public List<SelectListItem> Houses
        {
            get { return _houses; }
        }*/
        [Required(ErrorMessage = "Пожалуйста выберите район")]
        [Display(Name = "Район проживания")]
        public int adr_district { get; set; }

        [Required(ErrorMessage = "Пожалуйста выберите улицу")]
        [Display(Name = "Улица")]
        public int adr_street { get; set; }

        [Required]
        [Display(Name = "Номер дома")]
        public int adr_house { get; set; }

        //Данные о представителях
        [Required]
        [Display(Name = "Тип представителя")]
        public string pr_type { get; set; }

        public static List<SelectListItem> GetPrTypes()
        {
            var types = new List<SelectListItem>();
            types.Add(new SelectListItem { Text = "Мать", Value = "1" });
            types.Add(new SelectListItem { Text = "Отец", Value = "2" });
            types.Add(new SelectListItem { Text = "Законный представитель", Value = "3" });
            return (types);
        }

        [Required]
        [Display(Name = "Имя")]
        public string pr_first_name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string pr_last_name { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string pr_third_name { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Неверная серия паспорта")]
        [Display(Name = "Серия паспорта")]
        public string pr_series_doc { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Неверный номер паспорта")]
        [Display(Name = "Номер паспорта")]
        public string pr_number_doc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        public string pr_date_issue { get; set; }

        //Данные о детском саде
        [Required]
        [Display(Name = "Дата поступления")]
        public int year_enter { get; set; }

        /*private List<SelectListItem> _years = new List<SelectListItem>();
        public List<SelectListItem> Years
        {
            get { return _years; }
        }*/

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Предлагать поступление в течение года")]
        public bool during_year_offer { get; set; }

        [Required]
        [Display(Name = "Район главных ДОУ")]
        public int dou_district { get; set; }

        [Required]
        [Display(Name = "Район дополнительных ДОУ")]
        public int dou_district2 { get; set; }

        [Required]
        [Display(Name = "Главные ДОУ")]
        public string[] main_dou { get; set; }

        [Required]
        [Display(Name = "Дополнительные ДОУ")]
        public string[] another_dou { get; set; }

        [Required]
        [Display(Name = "Льгота")]
        public int privilege { get; set; }
    }
}