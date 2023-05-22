using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestLab3Math_Sem4;

namespace TestMathLab4
{
    internal class Numerical_Integration
    {
        int order_Of_Precision;
        int r = 2;
        public Numerical_Integration() { }
        public float Left_Rectangles(float a, float b, float e, float step)
        {
            order_Of_Precision = 1;
            float first_result = 0;
            float second_result = 0;
            do
            {
                first_result = second_result;
                second_result = 0;
                for (float i = a; i <= b; i += step)
                {
                    second_result += func2(i);
                }
                second_result *= step;
                step /= r;
            }
            while ((second_result - first_result) / ((float)Math.Pow(r, order_Of_Precision) - 1) >= e);

            return second_result;
        }
        public float Median_Rectangles(float a, float b, float e, float step)
        {
            order_Of_Precision = 2;
            float first_result = 0;
            float second_result = 0;
            do
            {
                first_result = second_result;
                second_result = 0;
                for (float i = a; i <= b; i += step)
                {
                    second_result += func2((i + i + step) / 2);
                }
                second_result *= step;
                step /= r;
            }
            while ((second_result - first_result) / ((float)Math.Pow(r, order_Of_Precision) - 1) >= e);

            return second_result;
        }
        public float Trapezes(float a, float b, float e, float step)
        {
            order_Of_Precision = 2;
            float first_result = 0;
            float second_result = 0;
            do
            {
                first_result = second_result;
                second_result = 0;
                second_result += func2(a);
                for (float i = a + step; i <= b; i += step)
                {
                    if (i + step > b)
                    {
                        second_result += func2(b);
                        break;
                    }
                    second_result += 2 * func2(i);

                }
                second_result *= step / 2;
                step /= r;
            }
            while ((second_result - first_result) / ((float)Math.Pow(r, order_Of_Precision) - 1) >= e);

            return second_result;
        }
        public double Simpson(double a, double b, double e, double step)
        {
            order_Of_Precision = 4;
            double first_result = 0;
            double second_result = 0;
            double temp_b = b;
            int counter = 0;
            do
            {
                if (((Math.Abs(b - a) / step)-1) % 2 != 0)
                {
                    temp_b -= step;
                }
                first_result = second_result;
                second_result= 0;
                second_result += func2(a);
                second_result += func2(temp_b);
                for (double i = a + step; i < temp_b; i += 2*step)
                {
                    if(counter == 1)
                    {
                        second_result += 4 * func2(i);
                        counter = 0;
                    }
                    if(counter == 0)
                    {
                        second_result += 2 * func2(i);
                        counter = 1;
                    }
                    

                }
                second_result *= step / 3;
                step /= r;
                temp_b = b;
                counter = 0;
            }
            while ((second_result - first_result) / ((float)Math.Pow(r, order_Of_Precision) - 1) >= e);
            return second_result;
        }
        double func2(double x)
        {
            return (1 + Math.Sqrt(x)) / (1 + 4 * x + 3 * Math.Pow(x, 2));
        }
        float func2(float x)
        {
            return (1 + (float)Math.Sqrt(x)) / (1 + 4 * x + 3 * (float)Math.Pow(x, 2));
        }
    }
}
