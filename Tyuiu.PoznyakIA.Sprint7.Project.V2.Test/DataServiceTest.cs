using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.IO;
using Tyuiu.PoznyakIA.Sprint7.Project.V2.Lib;
namespace Tyuiu.PoznyakIA.Sprint7.Project.V2.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataService ds = new DataService();

            string filePath = @"C:\Users\shauk\Desktop\DataBase.csv";

            AddDataToCSV(filePath);
        }

        private void AddDataToCSV(string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, true)) // открытие файла для записи
                {
                    // Пример добавления строки 
                    writer.WriteLine("Артикул; Название");
                }
            }
            catch (Exception ex)
            {
                // Проверка на ошибки
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
