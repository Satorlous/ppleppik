using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;

namespace Lab1.Controllers
{
    [Route("api")]
    [ApiController]
    public class LabController : ControllerBase
    {
        [HttpGet("num/{id}")]
        public ActionResult<string> PathParameter(int id)
        {
            return JsonConvert.SerializeObject(RusNumber.Str(id));
        }

        [HttpGet("equation")]
        public ActionResult<string> Equation(int a, int b, int c)
        {
            double d = b * b - 4 * a * c;
            if (d > 0)
                return JsonConvert.SerializeObject(new double[] { (-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a) });
            else if (d == 0)
                return JsonConvert.SerializeObject(-b / 2 / a);
            return JsonConvert.SerializeObject("");
        }

        [HttpGet("dotw")]
        public ActionResult<string> DayOfWeek(string date)
        {
            int[] nums = date.Split(new char[] { '.' }).Select(int.Parse).ToArray();
            DateTime dt;
            try
            {
                dt = new DateTime(nums[2], nums[1], nums[0]);
            }
            catch
            {
                return JsonConvert.SerializeObject("");
            }
            return JsonConvert.SerializeObject(dt.ToString("dddd", new CultureInfo("ru-RU")));
        }

        [HttpGet("region/{code}")]
        public string Regions(int code)
        {
            string[] regions = new string[] { "", "Республика Адыгея (Адыгея)", "Республика Башкортостан", "Республика Бурятия", "Республика Алтай", "Республика Дагестан", "Республика Ингушетия", "Кабардино-Балкарская Республика", "Республика Калмыкия", "Карачаево-Черкесская Республика", "Республика Карелия", "Республика Коми", "Республика Марий Эл", "Республика Мордовия", "Республика Саха (Якутия)", "Республика Северная Осетия - Алания", "Республика Татарстан (Татарстан)", "Республика Тыва", "Удмуртская Республика", "Республика Хакасия", "Чеченская Республика", "Чувашская Республика - Чувашия", "Алтайский край", "Краснодарский край", "Красноярский край", "Приморский край", "Ставропольский край", "Хабаровский край", "Амурская область", "Архангельская область", "Астраханская область", "Белгородская область", "Брянская область", "Владимирская область", "Волгоградская область", "Вологодская область", "Воронежская область", "Ивановская область", "Иркутская область", "Калининградская область", "Калужская область", "Камчатский край", "Кемеровская область", "Кировская область", "Костромская область", "Курганская область", "Курская область", "Ленинградская область", "Липецкая область", "Магаданская область", "Московская область", "Мурманская область", "Нижегородская область", "Новгородская область", "Новосибирская область", "Омская область", "Оренбургская область", "Орловская область", "Пензенская область", "Пермский край", "Псковская область", "Ростовская область", "Рязанская область", "Самарская область", "Саратовская область", "Сахалинская область", "Свердловская область", "Смоленская область", "Тамбовская область", "Тверская область", "Томская область", "Тульская область", "Тюменская область", "Ульяновская область", "Челябинская область", "Забайкальский край", "Ярославская область", "г. Москва", "Санкт-Петербург", "Еврейская автономная область", "Ненецкий автономный округ", "Ханты-Мансийский автономный округ - Югра", "Чукотский автономный округ", "Ямало-Ненецкий автономный округ", "Иные территории, включая город и космодром Байконур" };
            string region;
            try
            {
                region = regions[code];
            }
            catch
            {
                return JsonConvert.SerializeObject("");
            }
            return JsonConvert.SerializeObject(region);
        }

        [HttpGet("fib/{n}")]
        public ActionResult<string> Fibonacci(int n)
        {
            return JsonConvert.SerializeObject(Fib(n));
        }

        public int Fib(int n)
        {
            return n > 1 ? Fib(n - 1) + Fib(n - 2) : n == 1 ? 1 : 0;
        }
    }
}