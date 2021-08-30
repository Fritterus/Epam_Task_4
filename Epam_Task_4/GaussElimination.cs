using Epam_Task_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_4
{
    public class GaussElimination : IGaussElimination
    {

        public double[] GetAnswer(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            var additionalMatrix = new double[n, n + 1];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n + 1; j++)
                    additionalMatrix[i, j] = matrix[i, j];

            ForwardElimination(n, additionalMatrix, matrix);
            BackSubstitution(n, additionalMatrix, matrix);

            double[] answer = new double[n];

            for (int i = 0; i < n; i++)
                answer[i] = additionalMatrix[i, n];

            return answer;
        }

        public void ForwardElimination(int n, double[,] additionalMatrix, double[,] matrix)
        {
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n + 1; i++)
                    additionalMatrix[k, i] = additionalMatrix[k, i] / matrix[k, k];

                for (int i = k + 1; i < n; i++)
                {
                    double K = additionalMatrix[i, k] / additionalMatrix[k, k];
                    for (int j = 0; j < n + 1; j++)
                        additionalMatrix[i, j] = additionalMatrix[i, j] - additionalMatrix[k, j] * K;
                }

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n + 1; j++)
                        matrix[i, j] = additionalMatrix[i, j];
            }
        }

        public void BackSubstitution(int n, double[,] additionalMatrix, double[,] matrix)
        {
            for (int k = n - 1; k > -1; k--)
            {

                for (int i = n; i > -1; i--)
                    additionalMatrix[k, i] = additionalMatrix[k, i] / matrix[k, k];
                for (int i = k - 1; i > -1; i--)
                {
                    double K = additionalMatrix[i, k] / additionalMatrix[k, k];
                    for (int j = n; j > -1; j--)
                        additionalMatrix[i, j] = additionalMatrix[i, j] - additionalMatrix[k, j] * K;
                }
            }
        }
    }
}
