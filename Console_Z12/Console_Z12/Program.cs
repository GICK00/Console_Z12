using System;
using System.Text.RegularExpressions;

namespace Console_Z12
{
    class Regular
    {
        private Regex r;
        private string text;

        public void Math()
        {
            bool match = r.IsMatch(text);
            if (match == true)
                Console.WriteLine("| Текст содержит шаблон.");
            else
                Console.WriteLine("| Текст не содержит шаблон.");
        }

        public void MathView()
        {
            Console.Write("| ");
            MatchCollection match = r.Matches(text);
            foreach (Match m in match)
                Console.Write("{0} ", m);
            Console.WriteLine();
        }

        public void MatchDelet()
        {
            string replaced = r.Replace(text, "");
            Console.WriteLine("| {0}", replaced);
        }

        public static string Transform(Regex r)
        {
            return r.ToString();
        }

        public static Regex Transform(string r)
        {
            Regex reg = new(r);
            return reg;
        }

        public static string operator -(Regular regular)
        {
            return regular.r.Replace(regular.text, "");
        }

        public static string operator +(Regular regular, string str)
        {
            return regular.text + " " + str;
        }

        public static bool operator true(Regular regular)
        {
            if (regular.text.Length != 0)
                return true;
            return false;
        }

        public static bool operator false(Regular regular)
        {
            if (regular.text.Length == 0)
                return true;
            return false;
        }

        public Regex R
        {
            get { return r; }
            set { r = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index > 1)
                    throw new Exception("Индекс может быть только 0 или 1!");
                if (index == 0)
                    return r;
                else
                    return text;
            }
            set
            {
                if (index < 0 || index > 1)
                    throw new Exception("Индекс может быть только 0 или 1!");
                if (index == 0)
                    r = (Regex)value;
                else
                    text = value.ToString();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("| Классы в C#.");
            bool repit = true;
            while (repit == true)
            {
                try
                {
                    Regular reg = new Regular();
                    Console.WriteLine("| Введите текст.");
                    Console.Write("| : ");
                    reg.Text = Convert.ToString(Console.ReadLine());
                    if (reg.Text.Length <= 0)
                        throw new Exception("Введите текст!");
                    Console.WriteLine("| Введите шаблон.");
                    Console.Write("| : ");
                    reg.R = new Regex($@"{Convert.ToString(Console.ReadLine())}");
                    if (reg.R.ToString().Length <= 0)
                        throw new Exception("Введите строку для поиска!");
                    Console.WriteLine("|-------------------------------------------------");

                    reg.Math();
                    reg.MathView();
                    reg.MatchDelet();

                    Console.WriteLine("|-------------------------------------------------");
                    Console.WriteLine("| Значения R - {0}, Text - {1}", reg.R, reg.Text);

                    Console.WriteLine("| Какой индекс вывести?");
                    Console.Write("| : ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"|  #{index} = {reg[index]}");

                    Console.WriteLine("|-------------------------------------------------");
                    Console.WriteLine("| Ввежите текст который нужно дописать в конец.");
                    Console.Write("| : ");
                    string str = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("|-------------------------------------------------");

                    reg.Text = (reg + str);
                    Console.WriteLine("| Перегруженный + :\r\n| " + reg.Text);

                    reg.Text = (-reg);
                    Console.WriteLine("| Перегруженный - :\r\n| " + reg.Text);
                    
                    Console.WriteLine("| Перегруженный метод преобразования типов данных.");
                    Console.WriteLine($"| {Regular.Transform(reg.R)} = {Regular.Transform(reg.R).GetType()}, {Regular.Transform(reg.R.ToString())} = {Regular.Transform(reg.R.ToString()).GetType()}");
                    Console.WriteLine("|-------------------------------------------------");

                    if (reg)
                        Console.WriteLine("| Строка не пустая");
                    else
                        Console.WriteLine("| Строка пустая");

                    rep(out repit);
                }
                catch (FormatException)
                {
                    Console.WriteLine("| Введите индекс!");
                    rep(out repit);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"| {e.Message}");
                    rep(out repit);
                }
            }
        }

        static void rep(out bool repit)
        {
            Console.WriteLine("| Попробовать снова? Да / Нет");
            Console.Write("| : ");
            string repitTxT = Convert.ToString(Console.ReadLine());

            if (repitTxT == "Да")
            {
                repit = true;
                Console.WriteLine("|-------------------------------------------------");
            }
            else if (repitTxT == "Нет")
                repit = false;
            else
            {
                Console.WriteLine("|-------------------------------------------------");
                Console.WriteLine("| Некорректный ввод данных!");
                repit = false;
            }
        }
    }
}
