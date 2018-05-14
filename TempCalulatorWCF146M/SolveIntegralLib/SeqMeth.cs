using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveIntegralLib
{
    public class SeqMeth
    {
        public double RectangleMedium(double a, double b, double N, Func<double, double> F)//метод средних прямоугольников
        {
            if (b < a) throw new ArgumentException("Введены неправильные пределы! ");
            if (N < 0) throw new ArgumentException("N не может быть отрицательным! ");
            double h = (b - a) / N;
            double Newa = a + 0.5 * h;
            double s = 0, d = 0;
            for (int i = 0; i < N; i++)
            {
                d += F(Newa + h * i);
            }
            s = h * d;
            return s;
        }

        public double Trapeze(double a, double b, double N, Func<double, double> F)//метод трапеций
        {
            if (b < a) throw new ArgumentException("Введены неправильные пределы! ");
            if (N < 0) throw new ArgumentException("N не может быть отрицательным! ");
            double h = (b - a) / N;
            double s = 0;
            s = s + F(a);
            s = s + F(b);
            double x = a + h;
            while (x < b)
            {
                s = s + 2 * F(x);
                x = x + h;
            }
            s = s * h / 2;
            return s;
        }

        public double Simpson(double a, double b, double N, Func<double, double> F)//метод Симпсона
        {
            double h = (b - a) / N;
            double newa = a + 0.5 * h;
            double s = 0, d = 0;
                for (int i = 0; i < N; i++)
                {
                    d += 4 * F(newa + h * i) + 2 * F(a + h * (i + 1));
                }
            s = (h / 6) * (d + F(a) - F(b));
            return s;
        }
    }
}
