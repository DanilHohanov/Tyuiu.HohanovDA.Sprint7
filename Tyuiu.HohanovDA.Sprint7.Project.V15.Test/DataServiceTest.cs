
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

using Tyuiu.HohanovDA.Sprint7.Project.V15.Lib;

namespace Tyuiu.HohanovDA.Sprint7.Project.V15.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestLoadFromFileData()
        {
            DataService ds = new DataService();
            string testFilePath = "test_data.csv";

            // Создаем тестовый файл
            string testData = "Иванов И.И.;50000;5\r\nПетров П.П.;75000;3\r\nСидоров С.С.;60000;4";
            File.WriteAllText(testFilePath, testData);

            try
            {
                string[,] loadedData = ds.LoadFromFileData(testFilePath);

                Assert.AreEqual(3, loadedData.GetLength(0));
                Assert.AreEqual(3, loadedData.GetLength(1));
                Assert.AreEqual("Иванов И.И.", loadedData[0, 0]);
            }
            finally
            {
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }

        [TestMethod]
        public void TestParseData()
        {
            DataService ds = new DataService();
            string[,] testData = new string[3, 3]
            {
                { "Иванов И.И.", "50000", "5" },
                { "Петров П.П.", "75000", "3" },
                { "Сидоров С.С.", "60000", "4" }
            };

            string[] names;
            double[] incomes;
            int[] documents;
            ds.ParseData(testData, out names, out incomes, out documents);

            Assert.AreEqual(3, names.Length);
            Assert.AreEqual("Иванов И.И.", names[0]);
            Assert.AreEqual(50000, incomes[0], 0.001);
            Assert.AreEqual(5, documents[0]);
        }

        [TestMethod]
        public void TestSummDohod()
        {
            DataService ds = new DataService();
            double[] incomes = { 50000, 75000, 60000 };
            double res = ds.SummDohod(incomes);
            Assert.AreEqual(185000, res, 0.001);
        }

        [TestMethod]
        public void TestMinDohod()
        {
            DataService ds = new DataService();
            double[] incomes = { 50000, 75000, 45000, 60000 };
            double res = ds.MinDohod(incomes);
            Assert.AreEqual(45000, res, 0.001);
        }

        [TestMethod]
        public void TestMaxDohod()
        {
            DataService ds = new DataService();
            double[] incomes = { 50000, 75000, 45000, 60000 };
            double res = ds.MaxDohod(incomes);
            Assert.AreEqual(75000, res, 0.001);
        }

        [TestMethod]
        public void TestAverageValue()
        {
            DataService ds = new DataService();
            double[] incomes = { 50000, 75000, 60000 };
            double res = ds.AverageValue(incomes);
            Assert.AreEqual(61666.667, res, 0.001);
        }

        [TestMethod]
        public void TestCountDocument()
        {
            DataService ds = new DataService();
            int[] documents = { 5, 3, 4, 2 };
            int res = ds.CountDocument(documents);
            Assert.AreEqual(14, res);
        }

        [TestMethod]
        public void TestCountAboveAverage()
        {
            DataService ds = new DataService();
            double[] incomes = { 50000, 75000, 60000, 45000 };
            int res = ds.CountAboveAverage(incomes);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void TestGetAnalysisResult()
        {
            DataService ds = new DataService();
            string[] names = { "Иванов И.И.", "Петров П.П.", "Сидоров С.С." };
            double[] incomes = { 50000, 75000, 60000 };
            int[] documents = { 5, 3, 4 };

            string result = ds.GetAnalysisResult(names, incomes, documents);


            // 1. Проверяем наличие ключевых числовых значений (они точно совпадут)
            Assert.IsTrue(result.Contains("3"));        // Количество граждан
            Assert.IsTrue(result.Contains("185000"));   // Сумма доходов  
            Assert.IsTrue(result.Contains("61666"));    // Средний доход (без .667)

            // 2. Проверяем наличие имен (они точно есть)
            Assert.IsTrue(result.Contains("Иванов"));
            Assert.IsTrue(result.Contains("Петров"));
            Assert.IsTrue(result.Contains("Сидоров"));

            // 3. Проверяем наличие ключевых слов отчета
            Assert.IsTrue(result.Contains("АНАЛИЗ ДОХОДОВ"));
            Assert.IsTrue(result.Contains("доход="));
            Assert.IsTrue(result.Contains("документов="));
        }

        [TestMethod]
        public void TestFullWorkflow()
        {
            DataService ds = new DataService();
            string testFilePath = "test_data_full.csv";

            string testData = "Иванов И.И.;50000;5\r\nПетров П.П.;75000;3\r\nСидоров С.С.;60000;4";
            File.WriteAllText(testFilePath, testData);

            try
            {
                string[,] rawData = ds.LoadFromFileData(testFilePath);
                string[] names;
                double[] incomes;
                int[] documents;
                ds.ParseData(rawData, out names, out incomes, out documents);

                Assert.AreEqual(3, names.Length);
                Assert.AreEqual(185000, ds.SummDohod(incomes), 0.001);
                Assert.AreEqual(12, ds.CountDocument(documents));
            }
            finally
            {
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }
    }
}
