using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveIntegralLib
{
    class ParallelMets
    {
        public double RectangleMedium(double a, double b, int N, Func<double, double> F)
        {
            double h = (b - a) / N;
            double newa = a + 0.5 * h;
            double s = 0, d = 0;
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

        public double Trapeze(double a, double b, int N, Func<double, double> F)//метод трапеций
        {
            double h = (b - a) / N;
            double s = 0, d = 0;
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

        public double Simpson(double a, double b, int N, Func<double, double> F)
        {
            double h = (b - a) / N;
            double newa = a + 0.5 * h;
            double s = 0, d = 0;
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


            s = (h / 6) * (d + F(a) - F(a));
            return s;
        }
    }
}
