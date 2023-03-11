using System.Security.Cryptography.X509Certificates;
using System.Text;
using Матрица_Перерождение;

public class Programm
{
    public static void Main()
    {
        var arr = new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 5, 6, 7 } };
        var A = new Matrix();
        var B = new Matrix(4, 3);
        var C = new Matrix(3, 4);
        var D = new Matrix(2, 2);
        var E = new SquareMatrix(D);
        var F = new SquareMatrix(5);
        var G = new SquareMatrix(arr);

        Console.WriteLine("Проверка Конструкторов");
        Console.WriteLine(A);
        Console.WriteLine(B);
        Console.WriteLine(C);
        Console.WriteLine(D);
        Console.WriteLine(E);
        Console.WriteLine(F);
        Console.WriteLine(G);

        Console.WriteLine("Проверка операций");
        var C2 = new Matrix(3, 4);
        Console.WriteLine(C2.randomize());
        Console.WriteLine(C.randomize());
        Console.WriteLine(C + C2);
        Console.WriteLine(C - C2);
        Console.WriteLine(C * 2);
        Console.WriteLine(C / 2);
        Console.WriteLine(-C);
        Console.WriteLine("Умножение и транспонирование");
        Console.WriteLine(C);
        Console.WriteLine(B.randomize());
        Console.WriteLine(B * C);
        Console.WriteLine(C * B);
        Console.WriteLine(~B) ;
        Console.WriteLine(B.Transposed);
        Console.WriteLine("Проверка Квадратных Матриц");
        var H = new SquareMatrix(3).randomize();
        var I = new SquareMatrix(3).randomize();
        Console.WriteLine(H);
        Console.WriteLine(H.Det);
        var J = H.CreateInvertibleMatrix();
        Console.WriteLine(J);
        Console.WriteLine(J * H);
        

        Console.WriteLine("------------------------------------------------------------");
        var a = new SquareMatrix(3).randomize();
        var b = a.CreateInvertibleMatrix();
        Console.WriteLine(a.Det);
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(a * b);
    }
}
