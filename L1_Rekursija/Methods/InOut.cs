using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace L1_Rekursija.Methods
{
    public class InOut
    {
        /// <summary>
        /// Prints data into file
        /// </summary>
        /// <param name="fileName">file</param>
        /// <param name="data">Matrix data</param>
        /// <param name="radius">Circle radius</param>
        public static void PrintToFile(string fileName, Matrix data, int radius)
        {
            string writingText = "";

            writingText += radius + "\n";
            if(data != null)
            {
                int arraySize = data.GetArraySize();

                for (int i = 0; i < arraySize; i++)
                {
                    for(int j = 0; j < arraySize; j++)
                    {
                        writingText += data[i, j];
                        if (j != arraySize-1)
                            writingText += " ";
                    }
                    writingText += "\n";
                }
            }


            File.WriteAllText(fileName, writingText);
        }
        /// <summary>
        /// Reads data from file
        /// </summary>
        /// <param name="fileName">file</param>
        /// <returns>Matrix with data from file</returns>
        public static Matrix ReadFile(string fileName)
        {
            bool exists = File.Exists(fileName);

            if (exists)
            {
                string[] lines = File.ReadAllLines(fileName);
                Matrix matrx = new Matrix(int.Parse(lines[0]));
                for (int i = 0; i < matrx.GetArraySize(); i++)
                {
                    string[] parts = lines[i + 1].Split(' ');
                    for (int j = 0; j < matrx.GetArraySize(); j++)
                    {
                        matrx.Add(i, j, int.Parse(parts[j]));
                    }
                }
                return matrx;
            }
            return null;
        }        /// <summary>
        /// Deletes file
        /// </summary>
        /// <param name="fileName">file</param>        public static void DeleteFile(string fileName) => File.Delete(fileName);
    }
}