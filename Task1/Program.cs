using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var isText = Clipboard.ContainsText();//Проверяем есть ли текст в буфере обмена
            
            Console.WriteLine("Первое задание");
            Console.WriteLine(String.Format("Содержится текст: {0}", (isText) ? "Да" : "Нет"));//Вывод значения в консоль
            if (isText)
            {
                var cmp = StringComparer.CurrentCultureIgnoreCase; //Сравнение слов без учета регистра
                var CollectionWord = CreateCollection();

                CollectionWord.Sort(cmp);//Сортируем с учетом компоратора
                Display(CollectionWord);//Вызов метода для вывода слов в консоль
            }
            Console.ReadKey();//Ожидаем нажатия кнопки
        }

        /// <summary>
        /// Метод для вывода слов в консоль
        /// </summary>
        /// <param name="list">Коллекция для вывода</param>
        private static void Display(List<string> list)
        {
            Console.WriteLine();
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Смотрим что находится в буфере обмена, выбираем текст и режим его по пробельно
        /// </summary>
        /// <returns></returns>
        private static List<string> CreateCollection()
        {
            var res = new List<string>();//Выделяем память для коллекции слов, которую будем выводитьв консоль.

            var Text = Clipboard.GetText();//Выбираем весь текст из буфера обмена
            var array = Text.Split(' ').ToList();//Делим по пробелам
            foreach (var item in array)
            {
                var str = item.Replace(".", "")
                              .Replace(",", "")
                              .Replace("?", "")
                              .Replace("!", "")
                              .Replace(":", "")
                              .Replace(";", "")
                              .Replace(" ", "")
                              .Replace("\t", "")
                              .Replace("\n", "");//Вырезаем не нужные символы
                if (!res.Contains(str))
                {
                    res.Add(str);
                    if (res.Count == 1000)
                    {
                        break;
                    }
                }
            }

            return res;
        }

    }
}
