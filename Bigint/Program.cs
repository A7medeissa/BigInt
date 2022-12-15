using System;
using System.Collections.Generic;
using System.Numerics;

namespace Bigint
{
    class Program
    {
        static int Main()
        {
            Bigint num1=new Bigint("909999");
            Bigint num2=new Bigint("999099");
            bool x = num1 == num2;
            if (x == true)
            {
                Console.WriteLine("EQUAL");
            }
            else
            {
                Console.WriteLine("NOT EQUAL");


            }


            Console.WriteLine(num1-num2);
           
            return 0;
        }
    }
}
