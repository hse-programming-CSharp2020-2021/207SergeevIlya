using System;

namespace Task_02
{
    /// <summary>
    /// Класс для представления робота.
    /// </summary>
    class Robot
    {
        public int x, 
                   y;

        public int maxX,
                   maxY;

        /// <summary>
        /// Ссылка на поле, по которому перемещается робот.
        /// </summary>
        public char[,] area;

        /// <summary>
        /// Выходил ли робот за границы поля.
        /// </summary>
        public bool leftArea = false;

        /// <summary>
        /// Метод, проверяющий, не вышел ли робот за границы поля.
        /// </summary>
        private void Check ()
        {
            leftArea = leftArea || (x < 0) || (y < 0) || (x >= maxX) || (y >= maxY);
        }

        /// <summary>
        /// Метод, передвигающий робота направо.
        /// </summary>
        public void Right()
        {
            if (leftArea)
                return;

            x++;
            Check();

            if (!leftArea)
            {
                area[y + 1, x] = '+';
                area[y + 1, x + 1] = '*';
            }
                
        }

        /// <summary>
        /// Метод, передвигающий робота налево.
        /// </summary>
        public void Left()
        {
            if (leftArea)
                return;

            x--;
            Check();

            if (!leftArea)
            {
                area[y + 1, x + 2] = '+';
                area[y + 1, x + 1] = '*';
            }
                
        }

        /// <summary>
        /// Метод, передвигающий робота вперед.
        /// </summary>
        public void Forward()
        {
            if (leftArea)
                return;

            y++;
            Check();

            if (!leftArea)
            {
                area[y, x + 1] = '+';
                area[y + 1, x + 1] = '*';
            }
                
        }

        /// <summary>
        /// Метод, передвигающий робота назад.
        /// </summary>
        public void Backward()
        {
            if (leftArea)
                return;

            y--;
            Check();

            if (!leftArea)
            {
                area[y + 2, x + 1] = '+';
                area[y + 1, x + 1] = '*';
            }
                
        }

        /// <summary>
        /// Метод, позволяющий роботу отдохнуть слегка.
        /// </summary>
        public void Stay ()
        {

        }

        /// <summary>
        /// Метод, возвращающий информацию о координатах робота.
        /// </summary>
        public string Position()
        {
            return String.Format("Позиция робота: x = {0}, y = {1}", x, y);
        }

    }

    public class Program
    {
        delegate void Steps();

        /// <summary>
        /// Валидатор для ввода ограничений на перемещение робота.
        /// </summary>
        /// <param name="inp">
        /// Входная строка.
        /// </param>
        /// <param name="maxX">
        /// Максимальное значение x.
        /// </param>
        /// <param name="maxY">
        /// Максимальное значение y.
        /// </param>
        /// <returns>
        /// Если ввод корректен, возвращает true.
        /// Иначе - false.
        /// </returns>
        /// <remarks>
        /// Если пользователь решил отменить ввод, maxX и maxY приравниваются к -2.
        /// </remarks>
        static bool ValidateInp(string inp, out int maxX, out int maxY)
        {
            inp = inp.Trim(new char[2] { ' ', '\t' });

            if (inp == "-")
            {
                maxX = -2;
                maxY = -2;
                return true;
            }
            else
            {
                // Сплиттим.
                string[] inpSplitted = inp.Split(' ');

                maxX = -1;
                maxY = -1;

                // Проверяем корректность введённых данных.
                if (inpSplitted.Length != 2)
                    return false;
                else if (!int.TryParse(inpSplitted[0], out maxX) || maxX <= 0 || !int.TryParse(inpSplitted[1], out maxY)  || maxY <= 0)
                    return false;  
                else
                    return true;
            }
        }

        /// <summary>
        /// Метод, обрабатывающий команду роботу.
        /// </summary>
        /// <param name="command">
        /// Строка, содержащая команду.
        /// </param>
        /// <param name="area"> Поле, на котором перемещается робот.</param>
        /// <param name="rob"> Сам робот. </param>
        static void HandleComand (string comand, char[,] area, Robot rob)
        {
            Steps way = rob.Stay;

            // Просматриваем все символы введённой команды.
            for (int i = 0; i < comand.Length; ++i)
                switch (comand[i])
                {
                    case 'R':
                        way += rob.Right;
                        break;

                    case 'L':
                        way += rob.Left;
                        break;

                    case 'F':
                        way += rob.Forward;
                        break;

                    case 'B':
                        way += rob.Backward;
                        break;

                    case ' ':
                    case '\t':
                        break;

                    default:
                        Console.WriteLine("Ошибка: во введённой команде присутсвует какой-то символ кроме R, L, F и B." +
                            "\n Попробуйте ещё раз.");
                        return;
                }

            way();

            // Проверяем, вышел ли робот за границы поля.
            if (rob.leftArea)
                Console.WriteLine("Робот чуть было не вышел за границы поля. Ход комманды был прерван.");

            if (rob.x < 0)
                rob.x++;
            else if (rob.x >= rob.maxX)
                rob.x--;
            else if (rob.y < 0)
                rob.y++;
            else if (rob.y >= rob.maxY)
                rob.y--;

            Console.WriteLine(rob.Position());
            rob.leftArea = false;
        }

        static void Main()
        {
            Console.WriteLine("Добро пожаловать в программу управления роботом-снежинкой 69000!");
            // Создаём робота.
            Robot rob = new Robot();
            rob.x = 0;
            rob.y = 0;

            Console.WriteLine("Введите максимальные допустимые x и y робота через пробел или -, чтобы завершить работу.");
            while (!ValidateInp(Console.ReadLine(), out rob.maxX, out rob.maxY))
                Console.WriteLine("Введены некорректные данные, попробуйте ещё раз или введите -, чтобы завершить работу.");

            // Если пользователь решил отменить ввод.
            if (rob.maxX == -2)
                return;

            Console.Clear();

            // Поле.
            char[,] area = new char[rob.maxY + 2, rob.maxX + 2];
            rob.area = area;

            for (int i = 0; i < rob.maxY + 2; ++i)
            {
                for (int j = 0; j < rob.maxX + 2; ++j)
                    if (i == 0 || j == 0 || i == rob.maxY + 1 || j == rob.maxX + 1)
                        area[i, j] = '6';
                    else if (i == rob.y + 1 && j == rob.x + 1)
                        area[i, j] = '*';
                    else
                        area[i, j] = ' ';
            }

            do
            {
                // Выводим подсказки.
                Console.WriteLine("Робот-снежинка активирован.");
                Console.WriteLine("Для управления им введите в строку произвольный набор символов R, L, F, B.");
                Console.WriteLine("Каждая: ");
                Console.WriteLine(" - Команда R перемещает робота вправо на одну клетку");
                Console.WriteLine(" - Команда L перемещает робота влево на одну клетку");
                Console.WriteLine(" - Команда F перемещает робота вперёд на одну клетку");
                Console.WriteLine(" - Команда B перемещает робот назад на одну клетку");
                Console.WriteLine($"Поле {rob.maxX}x{rob.maxY}: (здесь цифрами 6 отображаются границы поля)");

                // Выводим поле.
                for (int i = 0; i < rob.maxY + 2; ++i)
                {
                    for (int j = 0; j < rob.maxX + 2; ++j)
                    {
                        if (area[i, j] == '*')
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (area[i, j] == '+')
                            Console.ForegroundColor = ConsoleColor.DarkGray;


                        Console.Write(area[i, j]);

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                        

                    Console.WriteLine();
                }

                // Получаем от пользователя команду и выполняем её, если она корректна.
                Console.WriteLine("Введите команду, которую должен будет исполнить робот или '-', чтобы завершить работу.");
                string comand = Console.ReadLine().Trim(new char[2] {' ', '\t'});

                // Если пользователь захотел завершить работу программы.
                if (comand == "-")
                    return;
                else
                {
                    HandleComand(comand, area, rob);
                    Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                    Console.ReadLine();

                    // Чистим консоль.
                    Console.Clear();
                }
            }
            while (true);
        }
    }
}