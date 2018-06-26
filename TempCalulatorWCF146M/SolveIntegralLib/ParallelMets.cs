namespace SolveIntegralLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ParallelMets
    {
        /// <summary>
        /// Solution of the integral by the method of medium rectangles.
        /// </summary>
        /// <param name="a">Left border</param>
        /// <param name="b">Right border</param>
        /// <param name="N">Number of partitions</param>
        /// <param name="F">Integrand</param>
        /// <returns>The numerical solution</returns>
        public double RectangleMedium(double a, double b, int N, Func<double, double> F) // метод средних прямоугольников
        {
            double h = (b - a) / N;
            double newa = a + 0.5 * h;
            double s = 0;
            double d = 0;
            object obj = new object();
            Parallel.For(0, N, () => 0.0, (i, state, local) =>
            {
                local += F(newa + h * i);
                return local;
            }, local =>
            {
                lock (obj)
                {
                    d += local;
                }
            });
            s = h * d;
            return s;
        }

        /// <summary>
        /// Solution of the integral by the method of trapeze.
        /// </summary>
        /// <param name="a">Left border</param>
        /// <param name="b">Right border</param>
        /// <param name="N">Number of partitions</param>
        /// <param name="F">Integrand</param>
        /// <returns>The numerical solution</returns>
        public double Trapeze(double a, double b, int N, Func<double, double> F)//метод трапеций
        {
            double h = (b - a) / N;
            double s = 0;
            double d = 0;
            object obj = new object();

            Parallel.For(0, N, () => 0.0, (i, state, local) =>
            {

                local += F(a + h * i);
                return local;
            }, local =>
            {
                lock (obj)
                {
                    d += local;
                }
            });

            s = (F(a) + F(b)) / 2;
            s = (s + d) * h;
            return s;
        }

        /// <summary>
        /// Solution of the integral by the method of Simpson.
        /// </summary>
        /// <param name="a">Left border</param>
        /// <param name="b">Right border</param>
        /// <param name="N">Number of partitions</param>
        /// <param name="F">Integrand</param>
        /// <returns>The numerical solution</returns>
        public double Simpson(double a, double b, int N, Func<double, double> F) // метод Симпсона
        {
            double h = (b - a) / N;
            double newa = a + 0.5 * h;
            double s = 0;
            double d = 0;
            object obj = new object();
            Parallel.For(0, N, () => 0.0, (i, state, local) =>
            {
                local += 4 * F(newa + h * i) + 2 * F(a + h * (i + 1));
                return local;
            }, local =>
            {
                lock (obj)
                {
                    d += local;
                }
            });

            s = (h / 6) * (d + F(a) - F(b));
            return s;
        }
    }
}
