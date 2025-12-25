using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyuiu.HohanovDA.Sprint7.Project.V15.Lib


{
    public class DataService
    {
        /// <summary>
        /// Загружает данные из файла data.csv в двумерный массив строк
        /// Формат файла: каждая строка - ФИО;доход;количество_документов
        /// </summary>
        public string[,] LoadFromFileData(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileData = reader.ReadToEnd();
                fileData = fileData.Replace("\n", "\r");
                string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length == 0) return new string[0, 0];

                string[] firstLineParts = lines[0].Split(';');
                int rows = lines.Length;
                int cols = firstLineParts.Length;

                string[,] arrayValues = new string[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    string[] lineParts = lines[i].Split(';');
                    for (int j = 0; j < cols && j < lineParts.Length; j++)
                    {
                        arrayValues[i, j] = lineParts[j].Trim();
                    }
                }
                return arrayValues;
            }
        }

        /// <summary>
        /// Парсит двумерный массив данных в массивы: имена и доходы
        /// </summary>
        public void ParseData(string[,] dataArray, out string[] names, out double[] incomes, out int[] documents)
        {
            int rows = dataArray.GetLength(0);

            // первая строка – заголовок, поэтому данных на 1 меньше
            int dataRows = rows - 1;

            names = new string[dataRows];
            incomes = new double[dataRows];
            documents = new int[dataRows];

            // начинаем с i = 1 (вторая строка в dataArray), 
            // а в целевых массивах сдвигаем индекс на -1
            for (int i = 1; i < rows; i++)
            {
                int targetIndex = i - 1;

                names[targetIndex] = dataArray[i, 0];                 // ФИО
                incomes[targetIndex] = double.Parse(dataArray[i, 1]); // Доход
                documents[targetIndex] = int.Parse(dataArray[i, 2]);  // Кол-во документов
            }
        }

        /// <summary>
        /// Общая сумма доходов всех граждан
        /// </summary>
        public double SummDohod(double[] incomes)
        {
            double sum = incomes.Sum();
            return Math.Round(sum, 3);
        }

        /// <summary>
        /// Минимальный доход среди всех граждан
        /// </summary>
        public double MinDohod(double[] incomes)
        {
            return Math.Round(incomes.Min(), 3);
        }

        /// <summary>
        /// Максимальный доход среди всех граждан
        /// </summary>
        public double MaxDohod(double[] incomes)
        {
            return Math.Round(incomes.Max(), 3);
        }

        /// <summary>
        /// Средний доход всех граждан
        /// </summary>
        public double AverageValue(double[] incomes)
        {
            double average = incomes.Average();
            return Math.Round(average, 3);
        }

        /// <summary>
        /// Общее количество документов у всех граждан
        /// </summary>
        public int CountDocument(int[] documents)
        {
            return documents.Sum();
        }

        /// <summary>
        /// Количество граждан с доходом выше среднего
        /// </summary>
        public int CountAboveAverage(double[] incomes)
        {
            double avg = incomes.Average();
            return incomes.Count(x => x > avg);
        }

        /// <summary>
        /// Возвращает отформатированный текст с результатами анализа
        /// </summary>
        public string GetAnalysisResult(string[] names, double[] incomes, int[] documents)
        {
            double avgIncome = AverageValue(incomes);
            int aboveAvgCount = CountAboveAverage(incomes);

            string result = $"АНАЛИЗ ДОХОДОВ ГРАЖДАН\n" +
                          $"======================\n" +
                          $"Общее количество граждан: {names.Length}\n" +
                          $"Общая сумма доходов: {SummDohod(incomes):F3}\n" +
                          $"Минимальный доход: {MinDohod(incomes):F3}\n" +
                          $"Максимальный доход: {MaxDohod(incomes):F3}\n" +
                          $"Средний доход: {avgIncome:F3}\n" +
                          $"Граждан с доходом выше среднего: {aboveAvgCount}\n" +
                          $"Общее количество документов: {CountDocument(documents)}\n\n";

            result += "ДЕТАЛИЗАЦИЯ ПО ГРАЖДАНАМ:\n";
            result += "------------------------\n";

            for (int i = 0; i < names.Length; i++)
            {
                bool isAboveAvg = incomes[i] > avgIncome;
                result += $"{names[i]}: доход={incomes[i]:F3}, документов={documents[i]}, ";
                result += isAboveAvg ? "ВЫШЕ СРЕДНЕГО" : "ниже среднего\n";
            }

            return result;
        }
    }
}
