// Задача 50. Напишите программу, которая на вход принимает значение элемента в двумерном массиве, и возвращает позицию этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

void msgStyle (string message, string status = "Green", int newLine = 1) {
    //Black, DarkBlue, DarkGreen, DarkCyan, 
    //DarkRed, DarkMagenta, DarkYellow, Gray, 
    //DarkGray, Blue, Green, Cyan, 
    //Red, Magenta, Yellow, White

    var cons_color = new Dictionary<string, int>();
    for (int i = 0; i < 16; i++) cons_color.Add(((ConsoleColor)i).ToString(), i);

    Console.ForegroundColor = (ConsoleColor)cons_color[status];
    if(newLine == 1) Console.WriteLine(message);
    else Console.Write(message);
    Console.ForegroundColor = ConsoleColor.Gray;
}

string consoleRead(int len, string charList = "1234567890-") {  //Ограничение ввода с клавиатуры
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
            if(ch == '-' && str.Length > 0) continue;
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
            msgStyle($"{arr[i,j]}\t", "DarkCyan", 0);
        }
        Console.WriteLine();
    }
}

string findValue (double[,] arr, double value) {
    for(int i = 0; i < arr.GetLength(0); i++) {
        for(int j = 0; j < arr.GetLength(1); j++) {
            if(arr[i,j] == value) return $"[{i}, {j}]";
        }
    }
    return "такого числа в массиве нет";
}

Console.Clear();

double[,] arr = create_array(3,4, len: 0);
string keyEnter = string.Empty;
print_array(arr);

while(true) {
    msgStyle("Введите число для поиска (для выхода введите 'q'): ", "Blue", 0);
    keyEnter = consoleRead(3);
    Console.WriteLine();
    msgStyle(keyEnter + " -> " + findValue(arr, Convert.ToInt32(keyEnter)));
}

