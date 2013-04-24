using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Diploma.Models
{
    public class Algoritm
    {
        [Required]
        [Display(Name = "Группа 0-1 года")]
        public bool group01 { get; set; }

        [Required]
        [Display(Name = "Группа 1-2 лет")]
        public bool group12 { get; set; }

        [Required]
        [Display(Name = "Группа 2-3 лет")]
        public bool group23 { get; set; }

        [Required]
        [Display(Name = "Группа 3-4 лет")]
        public bool group34 { get; set; }


        [Required]
        [Display(Name = "Группа 4-5 лет")]
        public bool group45 { get; set; }

        [Required]
        [Display(Name = "Группа 5-6 лет")]
        public bool group56 { get; set; }

        [Required]
        [Display(Name = "Группа 6-7 лет")]
        public bool group67 { get; set; }

        [Required]
        [Display(Name = "Распределить в течение года")]
        public bool during_year_offer { get; set; }

        public static void BdayRecalculate()//Перезапись возраста детей на время распределения
        {
            var entity = new DiplomEntities();
            var douconnect = entity.DouConnection;
            foreach (var k in douconnect)
            {
                var douconnectuser = entity.User.SingleOrDefault(i => i.id == k.userid);
                k.age_group = DouConnectionClass.GetNewAgeGroup(douconnectuser.date_birth);
            }
            entity.SaveChanges();
        }

        public static void Distribution(int age, bool during_year)
        {
            var entity = new DiplomEntities();
            var doulist = entity.Dou.ToList();
            var UserListOfDou = entity.DouConnection.ToList();//Получаем список всех заявок в ДОУ         
            foreach (var dou in doulist)
            {
                IEnumerable<DouConnection> result = UserListOfDou;
                int group;
                switch (age)
                {
                    case 1:
                        group = dou.dou_group01;
                        break;
                    case 2:
                        group = dou.dou_group12;
                        break;
                    case 3:
                        group = dou.dou_group23;
                        break;
                    case 4:
                        group = dou.dou_group34;
                        break;
                    case 5:
                        group = dou.dou_group45;
                        break;
                    case 6:
                        group = dou.dou_group56;
                        break;
                    case 7:
                        group = dou.dou_group67;
                        break;
                    default:
                        group = 0;
                        break;
                }
                if (group > 0)
                {
                    var old_min_koef = 0.0;
                    for (int f = 0; f < 8; f++) //Пока есть свободные места в этой группе, делаем:
                    {
                        /*-------------------------------------------------------------------------*/
                        /*---------------------Выбор поступающих только в этот ДОУ-----------------*/

                        var trueList = UserListOfDou.Where(i => i.enrolled == true); //Ищем все распределённые заявки
                        foreach (var s in trueList)
                        {
                            result = UserListOfDou.Where(all => all.userid != s.userid);
                            //Выбираем заявки только тех детей, которые никуда не распределены
                        }
                        var DouConnectionList =
                            result.Where(i => i.douid == dou.id && i.age_group < age && i.enrolled == false);
                        //Все поступающие в это ДОУ

                        /*-------------------------------------------------------------------------*/


                        /*-------------------------------------------------------------------------*/
                        /*---------------------Если есть заявки------------------------------------*/

                        if (DouConnectionList.Count() != 0) //Если есть хоть один поступающий
                        {

                            /*----Поиск записей с минимальным коэффициентом, большим предыдущего---*/
                            var oldminkoefDouConnection = DouConnectionList.Where(i => i.dou_user_rate > old_min_koef);

                            if (oldminkoefDouConnection.Count() == 0)//Если нет таких записей
                            {
                                break;//Выход из цикла for
                            }
                            var minkoeff = oldminkoefDouConnection.Min(i => i.dou_user_rate); //Минимальный коэффициент
                            old_min_koef = minkoeff;
                            var MinUsers = DouConnectionList.ToList().Where(i => i.dou_user_rate == minkoeff);
                            //Enrollment(MinUsers, dou);
                            //var users = MinUsers.ToList();
                            //bool is_users = true; //Есть ли активные заявки
                            foreach (var k in MinUsers)
                            {
                                IEnumerable<User> this_year_users;
                                if (during_year == true)
                                {
                                    this_year_users =
                                        entity.User.Where(
                                            i => i.year_enter == DateTime.Today.Year && i.during_year_offer == true);
                                }
                                else
                                {
                                    this_year_users =
                                        entity.User.Where(
                                            i => i.year_enter == DateTime.Today.Year);
                                }
                                var douuser = this_year_users.SingleOrDefault(i => i.id == k.userid);
                                if (douuser != null)
                                {
                                    if (group > 0)
                                    {
                                        //is_users = true;
                                        douuser.status = 1;
                                        group--;
                                        k.enrolled = true;
                                    }
                                }
                                /*else
                                {
                                    is_users = false; //Если нет заявок
                                }*/
                            }
                            /*if (is_users == false)
                        {
                            break;
                        }*/
                            entity.SaveChanges();
                        }
                        /*----------если есть заявки--------------*/

                        else
                        {
                            switch (age)
                            {
                                case 1:
                                    dou.dou_group01 = group;
                                    break;
                                case 2:
                                    dou.dou_group12 = group;
                                    break;
                                case 3:
                                    dou.dou_group23 = group;
                                    break;
                                case 4:
                                    dou.dou_group34 = group;
                                    break;
                                case 5:
                                    dou.dou_group45 = group;
                                    break;
                                case 6:
                                    dou.dou_group56 = group;
                                    break;
                                case 7:
                                    dou.dou_group67 = group;
                                    break;

                            }
                            break;
                        }
                        switch (age)
                        {
                            case 1:
                                dou.dou_group01 = group;
                                break;
                            case 2:
                                dou.dou_group12 = group;
                                break;
                            case 3:
                                dou.dou_group23 = group;
                                break;
                            case 4:
                                dou.dou_group34 = group;
                                break;
                            case 5:
                                dou.dou_group45 = group;
                                break;
                            case 6:
                                dou.dou_group56 = group;
                                break;
                            case 7:
                                dou.dou_group67 = group;
                                break;
                        }
                        entity.SaveChanges();
                    }
                }
            }

        }
        /*
        public static void Distribution12()
        {
            var entity = new DiplomEntities();
            foreach (var dou in entity.Dou)
            {
                while (dou.dou_group12 > 0)
                {
                    var UserListOfDou = entity.DouConnection.ToList().Where(i => i.douid == dou.id).Where(i => i.age_group < 2);
                    //Все поступающие в это ДОУ
                    if (UserListOfDou != null)
                    {
                        var minkoeff = UserListOfDou.Min(i => i.dou_user_rate); //Минимальный коэффициент
                        var MinUsers = UserListOfDou.ToList().Where(i => i.dou_user_rate == minkoeff);
                        Enrollment(MinUsers, dou);
                    }
                }
            }

        }
        public static void Distribution23()
        {
            var entity = new DiplomEntities();
            foreach (var dou in entity.Dou)
            {
                while (dou.dou_group23 > 0)
                {
                    var UserListOfDou = entity.DouConnection.ToList().Where(i => i.douid == dou.id).Where(i => i.age_group < 3);
                    //Все поступающие в это ДОУ
                    if (UserListOfDou != null)
                    {
                        var minkoeff = UserListOfDou.Min(i => i.dou_user_rate); //Минимальный коэффициент
                        var MinUsers = UserListOfDou.ToList().Where(i => i.dou_user_rate == minkoeff);
                        Enrollment(MinUsers, dou);
                    }
                }
            }

        }
        public static void Distribution34()
        {
            var entity = new DiplomEntities();
            foreach (var dou in entity.Dou)
            {
                while (dou.dou_group34 > 0)
                {
                    var UserListOfDou = entity.DouConnection.ToList().Where(i => i.douid == dou.id).Where(i => i.age_group < 4);
                    //Все поступающие в это ДОУ
                    if (UserListOfDou != null)
                    {
                        var minkoeff = UserListOfDou.Min(i => i.dou_user_rate); //Минимальный коэффициент
                        var MinUsers = UserListOfDou.ToList().Where(i => i.dou_user_rate == minkoeff);
                        Enrollment(MinUsers, dou);
                    }
                }
            }

        }
        public static void Distribution45()
        {
            var entity = new DiplomEntities();
            foreach (var dou in entity.Dou)
            {
                while (dou.dou_group45 > 0)
                {
                    var UserListOfDou = entity.DouConnection.ToList().Where(i => i.douid == dou.id).Where(i => i.age_group < 5);
                    //Все поступающие в это ДОУ
                    if (UserListOfDou != null)
                    {
                        var minkoeff = UserListOfDou.Min(i => i.dou_user_rate); //Минимальный коэффициент
                        var MinUsers = UserListOfDou.ToList().Where(i => i.dou_user_rate == minkoeff);
                        Enrollment(MinUsers, dou);
                    }
                }
            }

        }
        public static void Distribution56()
        {
            var entity = new DiplomEntities();
            foreach (var dou in entity.Dou)
            {
                while (dou.dou_group56 > 0)
                {
                    var UserListOfDou = entity.DouConnection.ToList().Where(i => i.douid == dou.id).Where(i => i.age_group < 6);
                    //Все поступающие в это ДОУ
                    if (UserListOfDou != null)
                    {
                        var minkoeff = UserListOfDou.Min(i => i.dou_user_rate); //Минимальный коэффициент
                        var MinUsers = UserListOfDou.ToList().Where(i => i.dou_user_rate == minkoeff);
                        Enrollment(MinUsers, dou);
                    }
                }
            }

        }
        public static void Distribution67()
        {
            var entity = new DiplomEntities();
            foreach (var dou in entity.Dou)
            {
                while (dou.dou_group67 > 0)
                {
                    var UserListOfDou = entity.DouConnection.ToList().Where(i => i.douid == dou.id).Where(i => i.age_group < 7);
                    //Все поступающие в это ДОУ
                    if (UserListOfDou != null)
                    {
                        var minkoeff = UserListOfDou.Min(i => i.dou_user_rate); //Минимальный коэффициент
                        var MinUsers = UserListOfDou.ToList().Where(i => i.dou_user_rate == minkoeff);
                        Enrollment(MinUsers, dou);
                    }
                }
            }

        }

        static void Enrollment(IEnumerable<DouConnection> users, Dou dou)
        {
            foreach (var k in users)
            {
                var entity = new DiplomEntities();
                var douuser = entity.User.SingleOrDefault(i => i.id == k.userid);
                if (douuser.status != 1)
                {
                    douuser.status = 1;
                    dou.dou_group01--;
                    k.enrolled = true;
                    entity.SaveChanges();
                }
            }
        }*/
    }
}