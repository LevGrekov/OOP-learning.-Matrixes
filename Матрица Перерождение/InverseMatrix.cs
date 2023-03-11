using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Матрица_Перерождение
{

    //Этот класс писался в контексте домашнего Михаила Юрьевича Першагина.
    //Поэтому общая композиция дерева наследования может показаться нелогичной.
    //Оставил как оно есть 
    internal class InverseMatrix : SquareMatrix
    {
        public InverseMatrix() { }
        public InverseMatrix(int n)
        {
            if (n <= 0) throw new Exception("incorrect value of dim");
            Data = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Data[i, j] = i==j ? 1 : 0;
                }
            }
        }
        public InverseMatrix(SquareMatrix other)
        {
            if (other.Det == 0) throw new Exception("Матрица необратима");
            Data = (double[,])other.Data.Clone();
        }
        public InverseMatrix(InverseMatrix other)
        {
            Data = (double[,])other.Data.Clone();
        }
        public InverseMatrix(double[,] arr) : base(arr)
        {
            if (arr.GetLength(0) != arr.GetLength(1)) throw new Exception("Матрица не квадратная");
            if (Det == 0) throw new Exception("Матрица необратима");
        }
        public override InverseMatrix CreateInvertibleMatrix() => new InverseMatrix(base.CreateInvertibleMatrix());
        public override InverseMatrix randomize(int x, int y) => new InverseMatrix(base.randomize(x, y));
        public override InverseMatrix randomize() => randomize(0, 9);
        public static InverseMatrix operator *(InverseMatrix a, double x) => new InverseMatrix((a as SquareMatrix) * x);
        public static InverseMatrix operator /(InverseMatrix a, double x)
        {
            if (x == 0) throw new DivideByZeroException();
            return a * (1 / x);
        }
        public static InverseMatrix operator +(InverseMatrix a, InverseMatrix b) => new InverseMatrix((a as SquareMatrix) + b);
        public static InverseMatrix operator -(InverseMatrix a, InverseMatrix b) => a + (b * -1);
        public static InverseMatrix operator -(InverseMatrix a) => (a * -1);
        public static InverseMatrix operator *(InverseMatrix a, InverseMatrix b) => new InverseMatrix((a as SquareMatrix) * b);
        public static InverseMatrix operator ~(InverseMatrix a)
        {
            var res = new InverseMatrix(a);
            res.transpose();
            return res;
        }
    }
}
