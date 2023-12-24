using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Tyuiu.PoznyakIA.Sprint7.Project.V2.Lib
{
    public class DataService
    {
        public string[,] LoadFromDataFile(string path)
        {
            string[] str = File.ReadAllLines(path);

           
            int columns = str[0].Split(';').Length;
            int rows = str.Length;

            string[,] matrix = new string[rows, columns];

            for (int i = 0; i < str.Length; i++)
            {
                string strIndexI = str[i];
                string[] strArr = strIndexI.Split(';');
                for (int c = 0; c < strArr.Length; c++)
                {
                    matrix[i, c] = strArr[c];
                }
            }
            return matrix;
        }

        public int Summ(string path, int cost)
        {
            string data = File.ReadAllText(path);
            data = data.Replace('\n', '\r');
            string[] lines = data.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;
            int coll = lines[7].Split(';').Length;
            string[,] mtr = new string[rows, coll];
            for (int i = 0; i < rows; i++)
            {
                string[] strok = lines[i].Split(';');
                for (int j = 0; j < coll; j++)
                {
                    mtr[i, j] = strok[j];
                }
            }

            int[] ln1 = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < coll; j++)
                {
                    if ((j == cost) && (i > 0))
                    {
                        ln1[i] = Convert.ToInt32(mtr[i, j]);
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < ln1.Length; i++)
            {
                res += ln1[i];
            }
            return res;
        }

         
    }
}
