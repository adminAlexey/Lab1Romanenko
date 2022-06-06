namespace Lab1Romanenko//{E,a,b,aa,ab,ba,bb,aaa,aab
{
    class Program
    {
        public static void Eng(int [] mas)
        {        
            char c;
            Console.WriteLine("Введите 2 буквы Английского алфавита");

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Введите букву Английского алфавита");
                c = Console.ReadKey().KeyChar;
                if ((int)c < 97 || (int)c > 122)//если символ не из верного диапазона (97-122) то уменьшаем счетчик чтобы вернуться к началу итерации
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы ввели неверный символ");
                    i--;
                }
                else//cимвол из верного диапазона
                {   
                    if (i == 0) { mas[i] = (int)c; }
                    for (int j = 0; j < i; j++)//проверка добавлен ли этот символ или нет
                    {
                        if (c != mas[j])//если не использовался то добавляем наш символ в массив
                        {
                            mas[i] = (int)c;
                            
                        }
                        else//если использовался выдаем ошибку, уменьшаем счетчик итераций и выходим из цикла проверки 
                        {
                            Console.WriteLine("Введите символ, который не использовался ранее");
                            i--;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine();
            for (int i = 0; i < 2; i++)//проверка
            {
                Console.WriteLine(mas[i]);
            }
        }

        public static void Rus(int[]mas)
        {           
            char c;
            Console.WriteLine("Введите 2 буквы Русского алфавита");

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Введите букву Русского алфавита");
                c = Console.ReadKey().KeyChar;
                if ((int)c < 1072 || (int)c > 1103)//если символ не из верного диапазона (1072-1103) то уменьшаем счетчик чтобы вернуться к началу итерации
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы ввели неверный символ");
                    i--;
                }
                else//cимвол из верного диапазона
                {
                    if (i == 0) { mas[i] = (int)c; }
                    for (int j = 0; j < i; j++)//проверка добавлен ли этот символ или нет
                    {
                        if (c != mas[j])//если не использовался то добавляем наш символ в массив
                        {
                            mas[i] = (int)c;

                        }
                        else//если использовался выдаем ошибку, уменьшаем счетчик итераций и выходим из цикла проверки 
                        {
                            Console.WriteLine();
                            Console.WriteLine("Введите символ, который не использовался ранее");
                            i--;
                            break;
                        }
                    }
                }
            }
        }

        public static void WordIn(int [] mas,ref string s)
        {
            bool b = true;
            do//проверка на принадлежность слова языку
            {
                Console.WriteLine("Введите слово лексикографический номер которого необходимо найти");
                s = Console.ReadLine();
                int count = 0;//счетчик кол-ва правильных букв
                foreach (char c in s)
                {
                    int cc = 0;//счетчик который показывает есть ли буква из слова в нашем алфавите
                    for (int i = 0; i < 2; i++)
                    {

                        if ((int)c == mas[i])
                        {
                            cc++;
                        }
                    }
                    if (cc == 1)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Введенное слово не принадлежит языку");
                    }
                    if (count == s.Length)//если есть необходимое кол-во совпадений букв, то слово верное
                    {
                        Console.WriteLine("Введено верное слово");
                        b = false;//выход из цикла
                    }
                }
            } while (b);
        }

        public static double NumberOut(int[] mas, string s)
        {
            double sum = 0;
            for (int i = 1; i < s.Length + 1; i++)//цикл нахождения номера по слову
            {
                int num = 0;
                
                for (int j = 0; j < mas.Length; j++)
                {
                    if (mas[j] == s[i - 1])
                    {
                        num = j + 1;                        
                    }                    
                }
                Console.WriteLine(i + "-ая итерация");
                Console.WriteLine(Math.Pow(mas.Length, (s.Length - i)) * num);
                sum += Math.Pow(mas.Length, (s.Length - i)) * num;
            }
            return sum;
        }

        public static double WordOut(int [] mas,int num)
        {
            double i = 1;
            int num3 = 0;//переменная порядкового номера среди одинаковой длинны
            int sum = 0;
            while (num>sum)
            {
                sum +=(int)Math.Pow(2,i);
                i++;
            }
            //Console.WriteLine("левая граница");
            //Console.WriteLine(sum-(int)Math.Pow(2, i - 1)+1);
            //Console.WriteLine("правая граница");
            //Console.WriteLine(sum); //код для проверки

            for (int j= sum - (int)Math.Pow(2, i - 1) + 1; j<= sum; j++)
            {
                num3++;
                if (num == j)
                {
                    break;
                }
            }
            //Console.WriteLine("порядковый номер "+num3);

            string s=(Convert.ToString(num3-1,2));
            //Console.WriteLine("s равно "+s);
            char[] chars= new char[(int)i-1];

            for(int j = 0; j<chars.Length ; j++)
            {
                chars[j] = '0';
            }
            for (int j= chars.Length-(chars.Length-s.Length)-1; j >= 0; j--)
            {
                chars[j+ chars.Length - s.Length] =s[j];
            }
            Console.WriteLine("Результат");
            for (int j=0; j < chars.Length; j++)
            { 
                if (chars[j] == '0')
                {
                    chars[j]='a';
                }
                if (chars[j] == '1')
                {
                    chars[j]='b';
                }
                Console.Write(chars[j]);
            }
            return i;
        }

        public static void Output(int num,double d)
        {
            string str=null;
            string last =null;
            int count=0;
            while (num > 2)
            {
                if (count == 0)
                {
                    str = "(";
                }                
                count++;
                if (num % 2 == 0)
                {                    
                    num = (num - 2) / 2;
                    str += Convert.ToString(num);
                    if (count>0) { last = ")*2+2"+ last; }
                }
                else
                {   
                    num = (num - 1) / 2;
                    str += Convert.ToString(num);
                    if (count > 0) { last = ")*2+1"+ last; }
                }
                Console.WriteLine(str+last);
                str = "(";
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        str += "(";
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] mas = new int[2];
            string s = "";
            double d = 1;
            //int[] mas = new int[2] { 97, 98 };//для упрощения проверки работоспособности кода

            Console.WriteLine("Выберите язык алфавита, 1 - английский, 2 - русский");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                Eng(mas);
            }
            else if (a == 2)
            {
                Rus(mas);
            }
            else { Console.WriteLine("Вы ввели неверное значение"); }

            Console.Clear();

            Console.WriteLine("Наш алфавит");
            for (int i = 0; i < 2; i++)
            {
                Console.Write((char)mas[i] + " ");
            }//вывели для наглядности

            Console.Clear();
            WordIn(mas, ref s);//со всеми проверками вписываем слово
            double number = NumberOut(mas, s);//находим номер, скромно выводим все
            Console.WriteLine("Лексикографический номер слова " + s + " = " + number);

            Console.WriteLine("Введите лексикографический номер слова, которое необходимо найти");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            d = WordOut(mas, num);

            Output(num,d);
        }
    }
}