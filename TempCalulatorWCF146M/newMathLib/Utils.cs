using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace newMathLib
{
    public class Utils
    {
        /// <summary>
        /// Получить массив массивов (jagged array) из обычного двухмерного массива
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="mArray">Двухмерный массив</param>
        /// <returns>Массив массивов (Jagged array)</returns>
        public static T[][] ToJagged<T>(T[,] mArray) // +
        {
            var rows = mArray.GetLength(0);
            var cols = mArray.GetLength(1);
            var jArray = new T[rows][];
            for (int i = 0; i < rows; i++)
            {
                jArray[i] = new T[cols];
                for (int j = 0; j < cols; j++)
                {
                    jArray[i][j] = mArray[i, j];
                }
            }
            return jArray;
        }

        /// <summary>
        /// Получить массив массивов (jagged array) из List вложенного в List
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="mList">объект типа List вложенного в List</param>
        /// <returns>Массив массивов (Jagged array)</returns>
        public static T[][] ToJagged<T>(List<List<T>> mList)
        {
            int rows = mList.Count;
            var jArray = new T[rows][];
            for (int i = 0; i < rows; i++)
            {
                var cols = mList[i].Count;
                jArray[i] = new T[cols];
                for (int j = 0; j < cols; j++)
                {
                    jArray[i][j] = mList[i][j];
                }
            }
            return jArray;
        }

        /// <summary>
        /// Получить двухмерный массив из масива массивом (Jagged array)
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="jArray">Массив массивов (Jagged array)</param>
        /// <returns></returns>
        public static T[,] ToMultiD<T>(T[][] jArray) // ++
        {
            int i = jArray.Count();
            int j = jArray.Select(x => x.Count()).Aggregate(0, (current, c) => (current > c) ? current : c);


            var mArray = new T[i, j];

            for (int ii = 0; ii < i; ii++)
            {
                for (int jj = 0; jj < j; jj++)
                {
                    mArray[ii, jj] = jArray[ii][jj];
                }
            }

            return mArray;
        }

        /// <summary>
        /// Получить двухмерный массив из списка списков (List<List<T>>)
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="list">Список списков (List<List<T>>)</param>
        /// <returns></returns>
        public static T[,] ToMultiD<T>(List<List<T>> list)
        {
            int i = list.Count();
            int j = list.Select(x => x.Count()).Aggregate(0, (current, c) => (current > c) ? current : c);


            var mArray = new T[i, j];

            for (int ii = 0; ii < i; ii++)
            {
                for (int jj = 0; jj < j; jj++)
                {
                    mArray[ii, jj] = list[ii][jj];
                }
            }

            return mArray;
        }





        /// <summary>
        /// Получить строку из матрицы (двухмерного массива)
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="matrix">Матрица (двухмерный массив)</param>
        /// <param name="row">Номер строки, нумерация с 0</param>
        /// <returns>Строка (одномерный массив)</returns>
        public static T[] GetRow<T>(T[,] matrix, int row)
        {
            var colNum = matrix.GetLength(1);
            var array = new T[colNum];
            for (int i = 0; i < colNum; i++)
                array[i] = matrix[row, i];
            return array;
        }

        /// <summary>
        /// Получить столбец из матрицы (двухмерного массива)
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="matrix">Матрица (двухмерный массив)</param>
        /// <param name="column">Номер столбца, нумерация с 0</param>
        /// <returns>Столбец (одномерный массив)</returns>
        public static T[] GetColumn<T>(T[,] matrix, int column)
        {
            var rowNum = matrix.GetLength(0);
            var array = new T[rowNum];
            for (int i = 0; i < rowNum; i++)
                array[i] = matrix[i, column];
            return array;
        }


        /// <summary>
        /// Получить обычную матрицу (двухмерный массив) из разреженной матрицы
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="rowIndex">Иддексы строк</param>
        /// <param name="columnIndex">Индексы стобцов</param>
        /// <param name="realData">Одномерный массив значений</param>
        /// <returns>Матрица (двухмерный массив)</returns>
        public static T[,] SparseToFull<T>(int[] rowIndex, int[] columnIndex, T[] realData)
        {

            int m = realData.Length;
            int rowsMax = 0;
            int colsMax = 0;
            for (int i = 0; i < m; i++)
            {
                int curRow = rowIndex[i];
                int curCol = columnIndex[i];
                if (rowsMax < curRow) rowsMax = curRow;
                if (colsMax < curCol) colsMax = curCol;
            }
            T[,] res = new T[rowsMax, colsMax];

            for (int i = 0; i < m; i++)
            {
                int curRow = rowIndex[i] - 1;
                int curCol = columnIndex[i] - 1;
                res[curRow, curCol] = realData[i];
            }

            return res;
        }

        /// <summary>
        /// Загрузить одномерный массив из csv файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="cultureInfo">Культура</param>
        /// <returns></returns>
        public static T[] Load1DArrayFromCsv<T>(string fileName, CultureInfo cultureInfo = null)
        {
            List<T> resultList = new List<T>();
            cultureInfo = (cultureInfo == null) ? CultureInfo.InvariantCulture : cultureInfo;
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                T val = (T)Convert.ChangeType(line, typeof(T), cultureInfo);
                resultList.Add(val);
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// Загрузить двухмерный массив из csv файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="separator">Разделитель</param>
        /// <param name="cultureInfo">Культура</param>
        /// <returns></returns>
        public static T[,] Load2DArrayFromCsv<T>(string fileName, string separator = ";", CultureInfo cultureInfo = null)
        {
            List<List<T>> resultList = new List<List<T>>();
            cultureInfo = (cultureInfo == null) ? CultureInfo.InvariantCulture : cultureInfo;
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string[] strs = sr.ReadLine().Split(new[] { separator }, StringSplitOptions.None);
                List<T> line = new List<T>();
                foreach (string str in strs)
                {
                    T val = (T)Convert.ChangeType(str, typeof(T), cultureInfo);
                    line.Add(val);
                }

                resultList.Add(line);
            }

            return ToMultiD(resultList);
        }

        /// <summary>
        /// Сохранить значение в файл.
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="valueToSave">Значение</param>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="cultureInfo">Культура</param>
        public static void SaveValue<T>(T valueToSave, string fileName, CultureInfo cultureInfo = null)
        {
            cultureInfo = (cultureInfo == null) ? CultureInfo.InvariantCulture : cultureInfo;
            using (StreamWriter file = new StreamWriter(fileName))
            {
                string strItem = Convert.ToString(valueToSave, cultureInfo);
                file.WriteLine(strItem);
            }
        }

        /// <summary>
        /// Сохранить разреженную матрицу в csv файл.
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="rowIndex">Индексы строк</param>
        /// <param name="columnIndex">Индексы столбцов</param>
        /// <param name="realData">Одномерный массив значений</param>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="separator">Раазделитель между значениями</param>
        /// <param name="cultureInfo">Культура</param>
        public static void Save2DArraySparseAsCsv<T>(int[] rowIndex, int[] columnIndex, T[] realData, string fileName, string separator = ";", CultureInfo cultureInfo = null)
        {
            if (rowIndex == null || columnIndex == null || realData == null) return;

            T[,] arrayToSave = SparseToFull(rowIndex, columnIndex, realData);
            SaveArrayAsCsv(arrayToSave, fileName, separator, cultureInfo);
        }


        /// <summary>
        /// Сохранить стобец (одномерный массив) в csv файл
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="arrayToSave">Столбец (одномерный массив)</param>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="separator">Разделитель значений</param>
        /// <param name="cultureInfo">Культура</param>
        public static void SaveArrayAsCsv<T>(T[] arrayToSave, string fileName, string separator = ";", CultureInfo cultureInfo = null)
        {
            if (arrayToSave == null) return;
            cultureInfo = (cultureInfo == null) ? CultureInfo.InvariantCulture : cultureInfo;
            using (StreamWriter file = new StreamWriter(fileName))
            {
                int m = arrayToSave.GetLength(0);
                for (int i = 0; i < m; i++)
                {
                    string strItem = Convert.ToString(arrayToSave[i], cultureInfo);
                    file.WriteLine(strItem);
                }
            }
        }

        /// <summary>
        /// Сохранить матрцу (двухмерный массив) в csv файл
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="arrayToSave">Матрица (двухмерный массив)</param>
        /// <param name="fileName">Пусть к файлу</param>
        /// <param name="separator">Разделитель значений</param>
        /// <param name="cultureInfo">Культура</param>
        public static void SaveArrayAsCsv<T>(T[,] arrayToSave, string fileName, string separator = ";", CultureInfo cultureInfo = null)
        {
            if (arrayToSave == null) return;
            cultureInfo = (cultureInfo == null) ? CultureInfo.InvariantCulture : cultureInfo;
            using (StreamWriter file = new StreamWriter(fileName))
            {
                int m = arrayToSave.GetLength(0);
                int n = arrayToSave.GetLength(1);
                for (int i = 0; i < m; i++)
                {
                    string line = String.Empty;
                    for (int j = 0; j < n; j++)
                    {
                        string strItem = Convert.ToString(arrayToSave[i, j], cultureInfo);
                        line += strItem + separator;
                    }
                    if (!String.IsNullOrEmpty(line))
                        line = line.Remove(line.Length - 1);
                    file.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Сохранить матрцу заданную ввиде массива массивом (Jagged array) в csv файл
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="arrayToSave">Матрица (двухмерный массив) заданная ввиде массива массивов (Jagged array)</param>
        /// <param name="fileName">Пусть к файлу</param>
        /// <param name="separator">Разделитель значений</param>
        /// <param name="cultureInfo">Культура</param>
        public static void SaveArrayAsCsv<T>(T[][] arrayToSave, string fileName, string separator = ";", CultureInfo cultureInfo = null)
        {
            try
            {
                if (arrayToSave == null) return;
                cultureInfo = (cultureInfo == null) ? CultureInfo.InvariantCulture : cultureInfo;
                using (StreamWriter file = new StreamWriter(fileName))
                {
                    int m = arrayToSave.GetLength(0);
                    for (int i = 0; i < m; i++)
                    {
                        string line = String.Empty;
                        T[] innerArray = arrayToSave[i];
                        int n = innerArray.GetLength(0);
                        for (int j = 0; j < n; j++)
                        {
                            string strItem = Convert.ToString(innerArray[j], cultureInfo);
                            line += strItem + separator;
                        }
                        if (!String.IsNullOrEmpty(line))
                            line = line.Remove(line.Length - 1);
                        file.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Подготовить каталог для сохранения расширенных логов и вернуть его путь
        /// </summary>
        /// <param name="extraEnding">Дополнение к имени каталога</param>
        /// <returns></returns>
        public static string PrepareLogsDir(string logDirPath, string extraEnding = "")
        {
            string dirPath = String.Empty;
            try
            {
                dirPath = Path.Combine(logDirPath, String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}{7}", DateTime.Now.Day, DateTime.Now.Month,
                DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, extraEnding));
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dirPath;
        }


    }


}

