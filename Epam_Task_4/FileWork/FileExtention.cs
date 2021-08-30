using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam_Task_4.FileWork
{
    internal class FileExtention
    {
        public double[,] GetJoinedMatrix(string pathToFileA, string pathToFileB)
        {
            double[,] systemMatrix = GetSystemMatrix(pathToFileA);
            double[] arrayCoeffs = GetFreeMembersCoeffs(pathToFileB);

            for (int i = 0; i < arrayCoeffs.Length; i++)
            {
                systemMatrix[i, arrayCoeffs.Length] = arrayCoeffs[i];
            }

            return systemMatrix;
        }

        public double[] GetAnswer(string filePath)
        {
            var answer = new List<double>();
            using StreamReader sr = new StreamReader(filePath);
            int i = 0;
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                var tmp = double.Parse(line.Trim());
                answer.Add(tmp);
                i++;
            }

            return answer.ToArray();
        }

        public double[,] GetSystemMatrix(string filePath)
        {
            var listA = new List<List<double>>();
            using StreamReader sr = new StreamReader(filePath);
            int i = 0;
            string line;
            int row;
            int col;

            while ((line = sr.ReadLine()) != null)
            {
                var internalList = line.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(obj => double.Parse(obj)).ToList();
                internalList.Add(0);
                listA.Add(internalList);
                i++;
            }

            row = listA.Count();
            col = listA[0].Count();

            var matrixA = new double[row, col];

            for (int k = 0; k < row; k++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrixA[k, j] = listA[k][j];
                }
            }

            return matrixA;
        }

        public double[] GetFreeMembersCoeffs(string filePath)
        {
            var listB = new List<double>();
            using StreamReader sr = new StreamReader(filePath);
            int i = 0;
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                var tmp = double.Parse(line.Trim());
                listB.Add(tmp);
                i++;
            }

            return listB.ToArray();
        }
    }
}
