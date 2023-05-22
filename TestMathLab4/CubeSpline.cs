using MathLab2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMathLab4
{


    internal class CubeSpline
    {
        float[] a;
        float[] b;
        float[] c;
        float[] d;
        float[] numsX, numsY;
        public CubeSpline(float[] numsX, float[] numsY)
        {
            a = new float[numsX.Length];
            b = new float[numsX.Length];
            c = new float[numsX.Length + 1];
            d = new float[numsX.Length];
            this.numsX = numsX;
            this.numsY = numsY;
        }

        public float[,] GetCoefficients()
        {

            float[,] matrix = new float[numsX.Length - 2, numsX.Length - 1];
            float temp = 0;
            for (int i = 1; i < numsX.Length - 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if ((i - j) < 0)
                    {

                        break;
                    }

                    if (j != 1)
                    {
                        matrix[i - 1, i - j] = 1;
                    }
                    else
                    {
                        matrix[i - 1, i - j] = 4;
                    }
                }
                temp = 3 * (numsY[i + 1] - 2 * numsY[i] + numsY[i - 1]);
                matrix[i - 1, matrix.GetLength(1) - 1] = temp;
            }
            Matrixes solver = new Matrixes();
            solver.Run_Through_Method(matrix).CopyTo(c, 0);
            for (int i = numsX.Length - 1; i > 0; i--)
            {
                c[i] = c[i - 1];
            }
            c[0] = 0;
            float[,] matrix2 = new float[numsX.Length - 1, numsX.Length - 1];
            for (int i = 1; i < numsX.Length; i++)
            {
                a[i] = numsY[i - 1];
                b[i] = ((numsY[i] - numsY[i - 1]) / (numsX[i - 1] - numsX[i])) - ((c[i + 1] + 2 * c[i]) * (numsX[i - 1] - numsX[i])) / 3;
                d[i] = (c[i + 1] - c[i]) / (3 * (numsX[i - 1] - numsX[i]));

                matrix2[i - 1, 0] = d[i];
                matrix2[i - 1, 1] = c[i];
                matrix2[i - 1, 2] = b[i];
                matrix2[i - 1, 3] = a[i];

            }
            return matrix2;
        }

    }
}
