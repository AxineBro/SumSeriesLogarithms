using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Series_Logarithms
{
    /*
       ln(x + sqrt(x^2 + 1)) = x - 1/2 * x^3/3 + 1*3 / (2 * 4) * x^5/5 ... R = 1

    */
    class Program
    {
        static void Main(string[] args)

        {
            double X;
            double Eps;
            int N;

            
            do
            {
                Console.Write("x (от: -1, до: 1) -> ");
                X = Convert.ToDouble(Console.ReadLine());
            } while (X > 1 || X < -1);
            Console.Write("Число членов ряда ->  ");
            N = Convert.ToInt16(Console.ReadLine());
            do
            {
                Console.Write("Точность ->  ");
                Eps = Convert.ToDouble(Console.ReadLine());
            } while (Eps > 1);
            

            Sum(X, Eps, N);

            Console.Write("Результат формулы: " + Math.Log(X + Math.Sqrt(Math.Pow(X, 2) + 1)));
            Console.ReadKey();

        } 

        static void Sum(double x, double eps, int n)
        {
            double currentElement;
            double sum;

            bool stopN = true;
            bool stopEps = true;
            bool stop2 = true;
            int counter = 1;
            sum = 0;
            double x2 = x * x;
            currentElement = x;
            do
            {
                sum += currentElement;
                currentElement = -currentElement * x2 * counter * counter / ((counter + 1) * (counter + 2));
                counter++;

                if (counter == n)
                {
                    Console.WriteLine("sum=" + sum + " N=" + counter);
                    stopN = false;
                }
                if (stopEps)
                {
                    if (Math.Abs(currentElement) < eps)
                    {
                        Console.WriteLine("sum= " + sum + " K=" + counter);
                        if (stop2)
                        {
                            eps = eps / 10;
                            stop2 = false;
                        }
                        else stopEps = false;
                    }
                }

            } while (stopN || stopEps || stop2);
        }
    }
}
