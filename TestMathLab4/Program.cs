
using TestMathLab4;

Numerical_Integration numerical_Integration = new Numerical_Integration();
Console.WriteLine(numerical_Integration.Trapezes((float)0.5, (float)4.5, (float)0.0000001, (float)0.001));




//Derivetive der = new Derivetive();
//Func<float, float> myfunc = delegate (float x) { return func(x); };
//Console.WriteLine(der.derevetive(4, (float)Math.Pow(10, -1), 2, myfunc));

//float func(float x)
//{
//    return 8 * (float)Math.Pow(x, 4);
//}
//float func2(float x)
//{
//    return (1 + (float)Math.Sqrt(x)) / (1 + 4 * x + 3 * (float)Math.Pow(x, 2));
//}





//float[] numsX = new float[] { 0,1,2,3,4 };
//float[] numsY = new float[] { 1,3,1,4,2 };
//CubeSpline spline = new CubeSpline(numsX,numsY);
//float[,] coefficients = spline.GetCoefficients();
//for(int i = 0;i < coefficients.GetLength(0);i++)
//{
//    for(int j = 0;j < coefficients.GetLength(1);j++)
//    {
//        Console.WriteLine(coefficients[i,j]);
//    }
//    Console.WriteLine();
//}