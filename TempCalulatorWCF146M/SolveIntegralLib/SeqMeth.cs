namespace SolveIntegralLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SeqMeth
    {
        /// <summary>
        /// Solution of the integral by the method of medium rectangles.
        /// </summary>
        /// <param name="a">Left border</param>
        /// <param name="b">Right border</param>
        /// <param name="N">Number of partitions</param>
        /// <param name="F">Integrand</param>
        /// <returns>The numerical solution</returns>
        public double RectangleMedium(double a, double b, int N, Func<double, double> F)//метод средних прямоугольников
        {
            if (b < a)
            {
                throw new ArgumentException("Введены неправильные пределы! ");
            }

            if (N < 0)
            {
                throw new ArgumentException("N не может быть отрицательным! ");
            }

            double h = (b - a) / N;
            double Newa = a + 0.5 * h;
            double s = 0;
            double d = 0;
            for (int i = 0; i < N; i++)
            {
                d += F(Newa + h * i);
            }

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
            if (b < a)
            {
                throw new ArgumentException("Введены неправильные пределы! ");
            }

            if (N < 0)
            {
                throw new ArgumentException("N не может быть отрицательным! ");
            }

            double h = (b - a) / N;
            double s = 0;
            double d = 0;
            for (int i = 0; i < N; i++)
            {
                d += F(a + h * i);
            }

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
        public double Simpson(double a, double b, int N, Func<double, double> F)//метод Симпсона
        {
            if (b < a)
            {
                throw new ArgumentException("Введены неправильные пределы! ");
            }

            if (N < 0)
            {
                throw new ArgumentException("N не может быть отрицательным! ");
            }

            double h = (b - a) / N;
            double newa = a + 0.5 * h;
            double s = 0;
            double d = 0;
            for (int i = 0; i < N; i++)
            {
                d += 4 * F(newa + h * i) + 2 * F(a + h * (i + 1));
            }

            s = (h / 6) * (d + F(a) - F(b));
            return s;
        }
    }
}
