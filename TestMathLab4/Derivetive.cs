using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMathLab4
{



    internal class Derivetive
    {
        float step = (float)Math.Pow(10, -4);
        int counter = 0;
        //Console.WriteLine(finalResult);
        public Derivetive() { }

        public float derevetive(int count, float step, float x, Func<float, float> myfunc)
        {
            float final_result = 0;
            if (count == 0)
            {
                return 0;
            }
            Func<float, float> anotherFunc = delegate (float x) { return (myfunc(x + step) - myfunc(x - step)) / (2 * step); };
            counter++;
            if (counter == count)
            {
                counter = 0;
                return anotherFunc(x);
            }
            else
            {
                final_result  =derevetive(count, step, x, anotherFunc);
            }
            return final_result;
        }
       
    }

}
