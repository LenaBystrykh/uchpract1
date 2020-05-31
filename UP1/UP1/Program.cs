using System;

namespace UP1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPointX, firstPointY, secondPointX, secondPointY, thirdPointX, thirdPointY, pointX, pointY;
            bool point = false;

            point = GetPoints(out firstPointX, out firstPointY, out secondPointX, out secondPointY,
            out thirdPointX, out thirdPointY, out pointX, out pointY, point);

            if (point == true) Console.WriteLine("In");
            else Console.WriteLine("Out");
        }

        public static bool GetPoints(out int firstPointX, out int firstPointY, out int secondPointX, out int secondPointY, 
            out int thirdPointX, out int thirdPointY, out int pointX, out int pointY, bool point)
        {
           
            string[] point1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool check1X = int.TryParse(point1[0], out firstPointX);
            bool check1Y = int.TryParse(point1[1], out firstPointY);
            //Console.WriteLine("Введите координаты второй точки через пробел");
            string[] point2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool check2X = int.TryParse(point2[0], out secondPointX);
            bool check2Y = int.TryParse(point2[1], out secondPointY);
            //Console.WriteLine("Введите координаты третьей точки через пробел");
            string[] point3 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool check3X = int.TryParse(point3[0], out thirdPointX);
            bool check3Y = int.TryParse(point3[1], out thirdPointY);
            //Console.WriteLine("Введите координаты проверяемой точки через пробел");
            string[] newPoint = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool checkX = int.TryParse(newPoint[0], out pointX);
            bool checkY = int.TryParse(newPoint[1], out pointY);
            if (check1X == false || check1Y == false || check2X == false || check2Y == false
                || check3X == false || check3Y == false || checkX == false || checkY == false)
            {
                //Console.WriteLine("Координаты введены неверно. Пожалуйста, проверьте правильность ввода и повторите попытку.");
            }
            else
            {
                point = CheckTriangle(firstPointX, firstPointY, secondPointX, secondPointY, thirdPointX, thirdPointY, pointX, pointY, point);
            }
            return point;
        }

        public static bool CheckTriangle(int firstPointX, int firstPointY, int secondPointX, int secondPointY, int thirdPointX, int thirdPointY, int pointX, int pointY, bool point)
        {
            double a = Math.Sqrt(Math.Pow((firstPointX - secondPointX), 2) + Math.Pow((firstPointY - secondPointY), 2));
            double b = Math.Sqrt(Math.Pow((secondPointX - thirdPointX), 2) + Math.Pow((secondPointY - thirdPointY), 2));
            double c = Math.Sqrt(Math.Pow((firstPointX - thirdPointX), 2) + Math.Pow((firstPointY - thirdPointY), 2));
            if ((a >= b + c) || (b >= a + c) || (c >= a + b))
            {
                //Console.WriteLine("Указанный треугольник не существует");            
            }
            else
            {
                point = CheckPoint(firstPointX, firstPointY, secondPointX, secondPointY, thirdPointX, thirdPointY, pointX, pointY);
            }
            return point;
        }

        public static bool CheckPoint(int firstPointX, int firstPointY, int secondPointX, int secondPointY, int thirdPointX, int thirdPointY, int pointX, int pointY)
        {
            bool point;

            double posAB = pointX * (secondPointY - firstPointY) + pointY * (firstPointX - secondPointX) + firstPointY * secondPointX - firstPointX * secondPointY;
            double posBC = pointX * (thirdPointY - secondPointY) + pointY * (secondPointX - thirdPointX) + secondPointY * thirdPointX - secondPointX * thirdPointY;
            double posAC = pointX * (firstPointY - thirdPointY) + pointY * (thirdPointX - firstPointX) + thirdPointY * firstPointX - thirdPointX * firstPointY;

            if (((posAB >= 0) && (posAC >= 0) && (posBC >= 0)) || ((posAB <= 0) && (posAC <= 0) && (posBC <= 0))) point = true;
            else point = false;

            return point;
        }
    }
}
