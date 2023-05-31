// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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

double[,] create_array (int x, int y, double diapazon_start = 1, double diapazon_end = 10, int len = 1) {
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

string average (double[,] arr) {
    string result = string.Empty;
    double columnSumm;
    for(int j = 0; j < arr.GetLength(1); j++) {
        columnSumm = 0;
        for(int i = 0; i < arr.GetLength(0); i++) {
            columnSumm += arr[i,j];
        }
        result += Math.Round(columnSumm/arr.GetLength(0), 1) + "; ";
    }

    return result.Substring(0, result.Length-2);
}

Console.Clear();

double[,] arr = create_array(3,4, len: 0);
string keyEnter = string.Empty;
print_array(arr);

msgStyle("Среднее арифметическое столбцов: ", "Blue", 0);
msgStyle(average(arr), "Blue", 0);


