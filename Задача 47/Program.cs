// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

void msgStyle (string message, string status = "Green") {
    //Black, DarkBlue, DarkGreen, DarkCyan, 
    //DarkRed, DarkMagenta, DarkYellow, Gray, 
    //DarkGray, Blue, Green, Cyan, 
    //Red, Magenta, Yellow, White

    var cons_color = new Dictionary<string, int>();
    for (int i = 0; i < 16; i++) cons_color.Add(((ConsoleColor)i).ToString(), i);

    Console.ForegroundColor = (ConsoleColor)cons_color[status];
    Console.WriteLine(message);
    Console.ForegroundColor = ConsoleColor.Gray;
}

string consoleRead(int len, string charList = "1234567890") {  //Ограничение ввода с клавиатуры
    string str = string.Empty;
    while (true)
    {
        char ch = Console.ReadKey(true).KeyChar;
        if (ch == '\r' && str.Length > 0) break;
        if (ch == 'q' || ch == 'Q') System.Environment.Exit(0);
        if (ch == '\b' && str.Length > 0) {
                str = str.Substring(0, str.Length - 1);
                Console.Write("\b \b");
        }
        else if (str.Length < len && charList.IndexOf(ch) != -1)
        {
            Console.Write(ch);
            str += ch;
        }
    }
    return str;
}

double[,] create_array (int x, int y, double diapazon_start = -10, double diapazon_end = 10, int len = 1) {
    double[,] result_array = new double[x, y];
    Random rnd = new Random();
    for(int i = 0; i < x; i++) {
        for(int j = 0; j < y; j++) {
            result_array[i,j] = Math.Round(rnd.NextDouble() * (diapazon_start - diapazon_end) + diapazon_end, len);
        }
    }
    return result_array;
}

void print_array (double[,] arr) {
    for(int i = 0; i < arr.GetLength(0); i++) {
        for(int j = 0; j < arr.GetLength(1); j++) {
            Console.Write(arr[i,j] + "\t");
        }
        Console.WriteLine();
    }
}

Console.Clear();
msgStyle("Введите размер массива (для выхода введите 'q')", "Blue");
Console.Write("Число строк: ");
int m = Convert.ToInt32(consoleRead(2));
Console.WriteLine();
Console.Write("Число колонок: ");
int n = Convert.ToInt32(consoleRead(2));
Console.WriteLine();

print_array(create_array(m,n));