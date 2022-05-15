using System;
using System.Collections.Generic;

namespace MatrixSorting
{
    public class Demonstration
    {
        static void Main(string[] args)
        {
            double[,] data = new double[,] { { 1, 3, 23 }, { 0, 2, 4 }, { 11, 22, 6 } };
            Matrix matrix = new Matrix(data);
            Console.WriteLine("Выберете тип сортировки:");
            Console.WriteLine("1 - В порядке возрастания (убывания) сумм элементов строк матрицы");
            Console.WriteLine("2 - По возрастанию (убыванию) максимального элемента в строке матрицы");
            Console.WriteLine("3 - В порядке возрастания (убывания) минимального элемента в строке матрицы;");
            Console.WriteLine("Нажмите любую клавишу, чтобы выбрать настройку по умолчанию");
            Console.WriteLine();
            ConsoleKeyInfo click = new ConsoleKeyInfo();
            click = Console.ReadKey(true);
            switch (click.KeyChar)
            {
                case '1':
                    matrix.SortingBubble = new SortSum();
                    break;
                case '2':
                    matrix.SortingBubble = new SortMax();
                    break;
                case '3':
                    matrix.SortingBubble = new SortMin();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Выберете: по возрастанию или убыванию?");
            Console.WriteLine("1 - В порядке возрастания");
            Console.WriteLine("2 - В порядке убывания");
            Console.WriteLine("Нажмите любую клавишу, чтобы выбрать настройку по умолчанию");
            Console.WriteLine();
            bool dir;
            click = Console.ReadKey(true);
            switch (click.KeyChar)
            {
                case '1':
                    dir = true;
                    break;
                case '2':
                    dir = false;
                    break;
                default:
                    dir = true;
                    break;
            }
            Console.WriteLine("Матрица до сортировки:");
            Console.WriteLine(matrix.ToString());
            matrix = matrix.Sort(dir);
            Console.WriteLine("Матрица после сортировки:");
            Console.WriteLine(matrix.ToString());
        }
    }
    public class Matrix
    {
        private int nRows;
        private int nCols;
        private double[][] data;

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            bool result = true;
            if (m1.Rows == m2.Rows && m1.Columns == m2.Columns)
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Columns; j++)
                    {
                        if (m1[i, j] != m2[i, j]) result = false;
                    }
                }
            }
            return result;
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            bool result = false;
            if (m1.Rows == m2.Rows && m1.Columns == m2.Columns)
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Columns; j++)
                    {
                        if (m1[i, j] != m2[i, j]) result = true;
                    }
                }
            }
            return result;
        }

        public ISortingBubble SortingBubble { get; set; }

        //конструктор
        public Matrix(double[,] initData)
        {
            nRows = initData.GetLength(0);
            nCols = initData.GetLength(1);
            data = new double[nRows][];
            for (int i = 0; i < nRows; i++)
            {
                data[i] = new double[nCols];
                for (int j = 0; j < nCols; j++)
                {
                    data[i][j] = initData[i, j];
                }
            }
            SortingBubble = new SortSum(); //по умолчанию
        }

        public Matrix Sort(bool dir) => SortingBubble.Sort(dir, this);

        //свойства
        public double this[int i, int j]
        {
            get
            {
                return data[i][j];
            }
            set
            {
                data[i][j] = value;
            }
        }
        public double[] this[int i]
        {
            get
            {
                double[] temp = new double[nCols];

                for (int j = 0; j < nCols; j++)
                {
                    temp[j] = data[i][j];
                }
                return temp;
            }
        }
        public int Rows
        {
            get { return nRows; }
        }
        public int Columns
        {
            get { return nCols; }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < nRows; i++)
            {
                s += "(";
                for (int j = 0; j < nCols; j++)
                {
                    s += data[i][j].ToString() + ", ";
                }
                s = s.TrimEnd();
                s = s.TrimEnd(',');
                s += ")\n";
            }
            return s;
        }
    }
    public interface ISortingBubble
    {
        Matrix Sort(bool dir, Matrix matrix);
    }

    public abstract class SortCommon : ISortingBubble
    {
        public Matrix Sort(bool dir, Matrix matrix)
        {
            int rows = matrix.Rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (SortType(dir, matrix, i, j))
                    {
                        Swap(matrix, i, j);
                    }
                }
            }
            return matrix;
        }
        public abstract bool SortType(bool dir, Matrix matrix, int i, int j);
        public void Swap(Matrix matrix, int i, int j)
        {
            double[] temp = new double[matrix.Columns];
            for (int k = 0; k < matrix.Rows; k++)
            {
                temp[k] = matrix[i, k];
                matrix[i, k] = matrix[j, k];
                matrix[j, k] = temp[k];
            }
        }

    }
    public class SortSum : SortCommon, ISortingBubble
    {//В порядке возрастания (убывания) сумм элементов строк матрицы
        public override bool SortType(bool dir, Matrix matrix, int i, int j)
        {
            if (dir)
                return matrix[i].Sum() > matrix[j].Sum();
            else
                return matrix[i].Sum() < matrix[j].Sum();
        }
    }

    public class SortMax : SortCommon, ISortingBubble
    {//В порядке возрастания (убывания) макс элемента в строке матрицы
        public override bool SortType(bool dir, Matrix matrix, int i, int j)
        {
            if (dir)
                return matrix[i].Max() > matrix[j].Max();
            else
                return matrix[i].Max() < matrix[j].Max();
        }
    }
    public class SortMin : SortCommon, ISortingBubble
    {//В порядке возрастания (убывания) мин элемента в строке матрицы
        public override bool SortType(bool dir, Matrix matrix, int i, int j)
        {
            if (dir)
                return matrix[i].Min() > matrix[j].Min();
            else
                return matrix[i].Min() < matrix[j].Min();
        }
    }
}