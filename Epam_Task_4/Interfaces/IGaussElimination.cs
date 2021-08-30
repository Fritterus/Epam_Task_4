using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_4.Interfaces
{
    internal interface IGaussElimination
    {
        public double[] GetAnswer(double[,] matrix);
    }
}
