using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnesbodyMVC.Models;

namespace Diploma.Models
{
    public class Account
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string password { get; set; }


        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }


        public bool IsValid(string _email, string _password)
        {
            {
                var entity = new DiplomEntities();
                try
                {
                    //Ищем email по БД
                    var user = entity.Authorization.Single(i => i.email == _email);
                    if (user.pass.ToLower() == Helpers.SHA1Encode(_password).ToLower())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    //Если такого нет, то возвращаем ошибку
                    return false;
                }
            }
        }

        public static Authorization GetName(string _email)
        {
            var entity = new DiplomEntities();
            var user = entity.Authorization.SingleOrDefault(i => i.email == _email);
            return (user);
        }

        /*public static int GetKidsNum(string _email)
        {
            int numberkids;
            var entity = new DiplomEntities();
            var auth = entity.Authorization.SingleOrDefault(i => i.email == _email);
            var user = entity.User.SingleOrDefault(u => u.authid == auth.id);
            if (user != null)
            {
                numberkids = user.authid;
            }
            else
            {
                numberkids = 0;
            }
            return (numberkids);
        }

        public static IEnumerable<User> GetKidsInfo(string _email, string _series, string _number)
        {
            var entity = new DiplomEntities();
            var auth = entity.Authorization.SingleOrDefault(i => i.email == _email);
            var users = entity.User.Where(i => i.authid == auth.id);
            var series_user = users.Where(i => i.series_doc == _series);
            var number_user = series_user.Where(i => i.number_doc == _number);
            return (number_user);
        }*/
    }

    public class RegisterAccount
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должен быть быть не короче {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Пароли не совпадают.")]
        [Display(Name = "Подтверждение пароля")]
        public string confirmpassword { get; set; }

        [Required]
        [Display(Name = "Имя пользователя")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "Фамилия пользователя")]
        public string last_name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string phone { get; set; }

    }
}