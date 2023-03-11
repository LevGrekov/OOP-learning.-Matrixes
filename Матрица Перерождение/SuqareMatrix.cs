using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Матрица_Перерождение
{
    internal class SquareMatrix : Matrix
    {
        public double Det => CalculateDeterminant();

        public SquareMatrix InverseMatrix => CreateInvertibleMatrix();
        public SquareMatrix() { }
        public SquareMatrix(int n) : base(n,n) { }
        public SquareMatrix(SquareMatrix other)
        {
            Data = (double[,])other.Data.Clone();
        }
        public SquareMatrix(Matrix other)
        {
            if (other.R != other.C) throw new Exception("Матрица не квадратная");
            Data = (double[,])other.Data.Clone();
        }
        public SquareMatrix(double[,] arr) : base(arr)
        {
            if (arr.GetLength(0) != arr.GetLength(1)) throw new Exception("Матрица не квадратная");
        }
        public override SquareMatrix randomize(int x, int y) => new SquareMatrix(base.randomize(x, y));
        public override SquareMatrix randomize() => randomize(0, 9);
        public SquareMatrix CreateMinor(int i, int j)
        {
            return new SquareMatrix(CreateMatrixWithoutColumn(i).CreateMatrixWithoutRow(j));
        }
        public double CalculateDeterminant()
        {
            if (this.R == 2)
            {
                return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
            }
            double result = 0;
            for (var j = 0; j < this.R; j++)
            {
                result += (j % 2 == 1 ? 1 : -1) * this[1, j] * CreateMinor(j,1).CalculateDeterminant();
            }
            return result;
        }
        //Операторы
        public static SquareMatrix operator *(SquareMatrix a, double x) => new SquareMatrix((a as Matrix) * x);
        public static SquareMatrix operator *(double x, SquareMatrix a) => a * x;
        public static SquareMatrix operator /(SquareMatrix a, double x)
        {
            if (x == 0) throw new DivideByZeroException();
            return a * (1 / x);
        }
        public static SquareMatrix operator /(double x, SquareMatrix a) => a / x;

        public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b) => new SquareMatrix((a as Matrix) + b);
        public static SquareMatrix operator -(SquareMatrix a, SquareMatrix b) => a + (b * -1);
        public static SquareMatrix operator -(SquareMatrix a) => (a * -1);
        public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b) => new SquareMatrix((a as Matrix) * b);
        public static SquareMatrix operator ~(SquareMatrix a)
        {
            var res = new SquareMatrix(a);
            res.transpose();
            return res;
        }

        public virtual SquareMatrix CreateInvertibleMatrix()
        {
            if (Det == 0) throw new Exception("Матрица с Определителем = 0 необратима");
            var result = new SquareMatrix(R);
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    result[i, j] = ((i + j) % 2 == 1 ? -1 : 1) * CreateMinor(j, i).CalculateDeterminant() / Det;
                }
            }
            return ~result;
        }
    }
}
