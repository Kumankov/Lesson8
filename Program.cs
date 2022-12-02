int [,] FillArray (int rows, int cols)
{
    int[,] Array = new int[rows,cols];  
    Console.WriteLine();
    Console.WriteLine("Массив: "); 
    for(int i=0;i<rows;i++)
    {
        for (int j=0;j<cols;j++)
        {
            Array[i,j] = new Random().Next(0,100);
            Console.Write($"{Array[i,j]}   ");
        }
        Console.WriteLine();
    }
    return Array;
}
// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
int [,] ArraySort(int[,] MassiveInt)
{
    for (int i=0;i<MassiveInt.GetLength(0);i++)
    {
        for(int j=0;j<MassiveInt.GetLength(1)-1;j++)
        {        
            for (int k=j+1;k<MassiveInt.GetLength(1);k++)
            {
                if (MassiveInt[i,j]<MassiveInt[i,k])
                {   
                    int temp = MassiveInt[i,j];
                    MassiveInt[i,j] = MassiveInt[i,k];
                    MassiveInt[i,k] = temp;
                }
            }
        }  
    }
    return MassiveInt;
}
// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
int ArrayMinSumRow(int[,] MassiveInt)
{
    int [] sumArray = new int [MassiveInt.GetLength(0)];
        for (int i=0;i<MassiveInt.GetLength(0);i++)
        {
            for(int j=0;j<MassiveInt.GetLength(1);j++)             
                sumArray [i]= sumArray [i] + MassiveInt[i,j];   
        }
    int sum=sumArray[0];
    int sumNumber = 0;

        for (int k=0; k<MassiveInt.GetLength(0);k++)
        {   
            if (sumArray [k]<sum) 
            {
                sum = sumArray [k];
                sumNumber = k;
            }
        }
    return sumNumber;
}
// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
int [,] MatrixMultiplication (int[,] MassiveInt1, int[,] MassiveInt2)
{   
    int [,] MatrixMulti = new int [MassiveInt1.GetLength(0),MassiveInt2.GetLength(1)];
    for(int i=0;i<MassiveInt1.GetLength(0);i++)
    {
        for (int j=0;j<MassiveInt2.GetLength(1);j++)
        {
            MatrixMulti[i,j] = 0;
            for (int k=0;k<MassiveInt1.GetLength(1);k++)
            MatrixMulti[i,j] = MatrixMulti[i,j] + MassiveInt1[i,k] * MassiveInt2[k,j];
        }        
    }
    return MatrixMulti;
}
// Задача 60. ...Сформируйте трёхмерный массив из 
// неповторяющихся двузначных чисел. Напишите программу, 
// которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
int [,,] FillTriArray (int m, int n, int o )
{
    int[,,] Array = new int[m,n,o];  
    int [] Array2 = new int [m*n*o];
    int temp =0;
    Console.WriteLine();
    Console.WriteLine("Массив: "); 
    for (int p =0; p<m*n*o; p++)
    {
        Array2 [p] = p ;
    }
    for (int r =Array2.Length-1;r>0;r--) // Тасуем по алгоритму Фишера-Йетса (современный алгоритм)
    {
        int s = new Random().Next(0,r+1);
        temp = Array2 [s];
        Array2 [s] = Array2 [r];
        Array2 [r] = temp;
    }
    int count=0;
    for(int i=0;i<m;i++)
    {
        for (int j=0;j<n;j++)
        {
            for (int k=0;k<o;k++)
            {
                Array[i,j,k] = Array2 [count];
                count++;
                Console.Write($"{Array[i,j,k]} ({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
    return Array;
}
// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
int [,] SpiralFill(int str, int col) // Возможно слишком мудрено, но работает.
{
    int[,] Massive = new int[str,col];
    int iMin=0;
    int jMin=1;
    int iMax=str;
    int jMax=col;
    int i =0;
    Found:
    Console.WriteLine();
    for (int j=iMin; j< jMax; j++)
        {        
        if (j==0) Massive[i,j] = 1;
        else
            {
            Massive[i,j] = Massive[i,j-1]+1; 
            if (j==jMax-1) 
                {
                jMax--;
                for (i=jMin;i<iMax;i++)
                    {
                    Massive[i,j] = Massive[i-1,j]+1;
                    if (i==iMax-1) 
                        {
                        iMax--;
                        for (int k=jMax-1;k>=iMin;k--)
                            {
                            Massive[i,k] = Massive[i,k+1]+1;                              
                            if (k==iMin) 
                                {
                                iMin++;
                                for (int l=iMax-1;l>=jMin;l--)
                                    {
                                    Massive[l,k] = Massive[l+1,k]+1;                                                   
                                    if (l==jMin)
                                        {
                                        jMin++; 
                                        i=iMin;
                                        goto Found;
                                        }
                                   }                                                            
                                }                            
                            }
                        }        
                    }
                }
            }    
        }       
    return Massive;
}
Console.WriteLine("Введите номер решаемой задачи (54,56,58,60,62)");
int taskNumber = int.Parse(Console.ReadLine());
if (taskNumber==54)
{
    Console.WriteLine("Задача 54");
    Console.WriteLine("Введите количество строк массива для задачи 54");
    int rows54 = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов массива для задачи 54");
    int cols54 = int.Parse(Console.ReadLine());
    int [,] Massive54 = ArraySort(FillArray(rows54,cols54));
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Отсортированный построчно массив:");
    for(int i=0;i<rows54;i++)
    {
        Console.WriteLine();
        for (int j=0;j<cols54;j++)
        Console.Write($"{Massive54[i,j]}   ");
    }
}
else if (taskNumber==56)
{
    Console.WriteLine("Задача 56");
    Console.WriteLine("Введите количество строк массива для задачи 56");
    int rows56 = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов массива для задачи 56");
    int cols56 = int.Parse(Console.ReadLine());
    Console.WriteLine($"Наименьшая сумма элементов в строке: {ArrayMinSumRow(FillArray(rows56,cols56))}");
}
else if (taskNumber==58)
{
    Console.WriteLine("Задача 58");
    Console.WriteLine("Введите количество строк первой матрицы для задачи 58");
    int rows58 = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов первой матрицы для задачи 58 (оно же количество количество строк второй матрицы)");
    int cols58 = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов второй матрицы для задачи 58");
    int cols258 = int.Parse(Console.ReadLine());
    int [,] Matrix58 = MatrixMultiplication(FillArray(rows58,cols58), FillArray(cols58, cols258));
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Результат произведения матриц:");
    for(int i=0;i<rows58;i++)
    {
        Console.WriteLine();
        for (int j=0;j<cols258;j++)
        Console.Write($"{Matrix58[i,j]}   ");
    }
}
else if (taskNumber==60)
{
    Console.WriteLine("Задача 60");
    Console.WriteLine("Введите количество m для задачи 60");
    int m = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество n для задачи 60");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество o для задачи 60");
    int o = int.Parse(Console.ReadLine());
    int [,,] Matrix58 = FillTriArray(m,n,o);
    Console.WriteLine();
}
else if (taskNumber==62)
{
    Console.WriteLine("Задача 62");
    Console.WriteLine("Введите количество строк массива для задачи 62 (не менее 2)");
    int m = int.Parse(Console.ReadLine());
    if (m<2) Console.WriteLine("Некорректное количество строк");
    else 
    {        
        Console.WriteLine("Введите количество столбцов массива для задачи 62 (не менее 2)");
        int n = int.Parse(Console.ReadLine());
        if (n<2) Console.WriteLine("Некорректное количество столбцов");
        else 
        {            
            int [,] Massive = SpiralFill(m,n);
            Console.WriteLine("Спирально заполненный массив:");
            for(int i=0;i<m;i++)
            {
                Console.WriteLine();
                for (int j=0;j<n;j++)
                Console.Write($"{ Convert.ToString(Massive[i,j]).PadLeft(2, '0')}   ");
            }
        }
    }
}
else
Console.WriteLine("Не был введён корректный номер задачи.");
