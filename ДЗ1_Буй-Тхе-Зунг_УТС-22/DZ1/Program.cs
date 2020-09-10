// ДЗ 1 - Буй Тхе Зунг - УТС12
using System;

namespace DZ1
{
    class Program
    {
        /*******************************************/
        /*    Functions showText(), inputData()    */
        /*******************************************/
        //<===>  showText() : This function will show the command enter data for Users can easy to know what are they doing.
        //                    By the way, this function can be called again when user enterd a character or symbol instead of a number
        static void showText(int PositionIndex)
        {
            if (PositionIndex % 2 == 0)
            {
                Console.Write("Enter x{0} : ", (PositionIndex / 2) + 1);
            }
            else
            {
                Console.Write("Enter y{0} : ", (PositionIndex / 2) + 1);
            }
            //When PositionIndex=0,2,4 : The Data input will be stored in x[0],x[1],x[2] arranged in order x1,x2,x3
            //When PositionIndex=1,3,5 : The Data input will be stored in y[0],y[1],y[2] arranged in order y1,y2,y3
        }


        //<===>  inputData() : This function will check the data from user is the right or wrong form.
        //                     This function will accept the numbers and deny the characters or symbols
        //                     try ... catch ... function can ignore system errors when you enter a character instead of a number
        //                     This function will ask the user re-enter a right forms (numbers), also call function showText() to show command for user
        static double inputData(int PositionIndex)
        {
            double Input; 
            inputProcess:
            try
            {
                Input = Convert.ToDouble(Console.ReadLine());
                return Input;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Sorry ! \n The Number Format Exception : {0}.\n Please enter a number\n", e.Message);
                showText(PositionIndex);
                goto inputProcess; 
            }
        }


        /****************************************************************/
        /* Functions countLength(), countCircumference(), countSquare() */
        /****************************************************************/
        //<===>countLength() : This function will calculate and returrn the length of each side of the triangle according to its coordinates
        static double countLength(double x1,double y1,double x2,double y2)
        {
            double L = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return L;
        }

        //<===>countCircumference() : This function will calculate the Circumference of the figure based on the return value(the length of sides) of the function countLength()
        static double countCircumference(double[] x, double[] y)
        {
            double L1,L2,L3;
            double Circumference;
            L1 = countLength(x[0], y[0], x[1], y[1]);
            L2 = countLength(x[1], y[1], x[2], y[2]);
            L3 = countLength(x[0], y[0], x[2], y[2]);
            Circumference = L1 + L2 + L3;
            //Clear the memories of 2 arrays 
            x = null;
            y = null;
            GC.Collect();
            return Circumference;

        }

        //<===>countSquare() : This function will calculate and return the Square of the figure based on Formula Heron and Values(the length of sides) return from function countLength()
        static double countSquare(double[] x, double[] y)
        {
            double p,S;
            p = countCircumference(x, y) / 2;
            double a, b, c; // a,b,c : lengths of 3 sides 
            a = countLength(x[0], y[0], x[1], y[1]);
            b = countLength(x[1], y[1], x[2], y[2]);
            c = countLength(x[0], y[0], x[2], y[2]);
            S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            //Clear the memories of 2 arrays 
            x = null;
            y = null;
            GC.Collect();
            return S;
        }


        /************************************/
        /*         Function Main()          */
        /************************************/
        //In Main Function
        //  +)Declare Arrays x[3] and y[3] for storing DATA of (x1,y1); (x2,y2); (x3,y3) Which were entered from User's Keyboard          
        //  +)Declare Circumference, Square follow requierments
        //  +)Call Functions showText() and inputData() to enter from keyboard
        //  +)Call functions countCircumference() and countSquare() for take result after counting of these functions and show on screen
        //  +)Clear the memories of 2 arrays x[3] and y[3] before finishing of program
        //  +)Pause the Console app in 1 minute when user run in .exe file 
        static void Main(string[] args)
        {
            Console.WriteLine("DZ 1 - Bui The Zung - UTS 12!\n");
            double[] x = new double[3];
            double[] y = new double[3];
            double Circumference, Square;
            for (int i=0;i<6;i++)
            {
                showText(i);
                if (i % 2 == 0)
                {
                    x[i / 2] = inputData(i);
                }
                else if (i % 2 == 1)
                {
                    y[i / 2] = inputData(i);
                }
                //When i=0,2,4 : The Data input will be stored in x[0],x[1],x[2]
                //When i=1,3,5 : The Data input will be stored in y[0],y[1],y[2]
                //Process storing: x[0] -> y[0] -> x[1] -> y[1] -> x[2] -> y[2]
            }

            Circumference = countCircumference(x, y);
            Console.WriteLine("Circumference = {0} \n",Math.Round(Circumference,3));//Math.round(V,a) will set showing a digits after comma of V

            Square = countSquare(x, y);
            Console.WriteLine("Square = {0} \n", Math.Round(Square, 3));

            x = null;
            y = null;
            GC.Collect();

            //Pause the console app in 1 minute
            Console.WriteLine("Pausing 1 Minute");
            System.Threading.Thread.Sleep(60000);
        }
    }
}
