using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigint
{
    internal class Bigint
    {
       private char [] internalnumber=new char[2000];
       public Bigint()
        {
            internalnumber = "".ToCharArray(); 
        }
        public Bigint(string num)
        {
            
            internalnumber = num.ToCharArray();
        }
        public static int  addtwonumberswithreminder(int c1,int c2, ref int reminder ) {

            int result = c1 + c2 + reminder;
            reminder = 0;
            if (result >= 10)
            {
                result -= 10;
                reminder = 1;
            }
            return result;
        }
        public static char[] AddTwoNumbers(char[] num1,char[] num2)
        {
            int reminder = 0;
            char[] finalresult=new char[2000];
            char[] tempresult=new char[2000];
            int index = 0;
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int result = 0;
            int c1=0,c2=0;
            for (; i >= 0 && j >= 0; i-- , j--)
            {
                 c1 = num1[i] - '0';
                 c2= num2[j]-'0';
                result = addtwonumberswithreminder(c1,c2,ref reminder);
                result += '0';

                tempresult[index] = (char)result;
                index++;
            }
            while (i >= 0)
            {
                 c1 = num1[i] - '0';
                result = addtwonumberswithreminder(c1, 0, ref reminder);
                result += '0';
                tempresult[index] = (char)result;
                index++;

                i--;

            }
            while (j >= 0)
            {
                c2 = num2[j] - '0';
                result = addtwonumberswithreminder(0, c2, ref reminder);
                result += '0';
                tempresult[index] = (char)result;
                index++;

                j--;

            }
            if (reminder == 1)
            {
                tempresult[index] = '1';
                index++;
            }

            tempresult[index] = '\0';
            int y=0;
            for (int x =tempresult.Length - 1; x >= 0; y++, x--)
            {
                finalresult[y] = tempresult[x];
            }
            finalresult[index] = '\0';
          
            return finalresult;
        }
        public static char[] operator +(Bigint n1,Bigint n2)
        {
            return AddTwoNumbers(n1.internalnumber, n2.internalnumber);
        }
        public static char[] operator -(Bigint n1, Bigint n2)
        {
            return Subtwonumbers(n1.internalnumber, n2.internalnumber);
        }
       public static bool  operator ==(Bigint n1, Bigint n2)
        {
            int i = n1.internalnumber.Length -1;
            int j =n2.internalnumber.Length -1;
            if (i != j)
            {
                return false;
            }
            else
            {
                for(; i >= 0; i--)
                {
                    if (n1.internalnumber[i] != n2.internalnumber[i])
                    {
                        return false;
                    }
                }
                return true;
            }

          //  return true;
        }
        public static bool operator !=(Bigint n1, Bigint n2)
        {
            char[] x = Subtwonumbers(n1.internalnumber, n2.internalnumber);
            return true;
        }

        ///////////////////////////////////////////////////////////
        static void   propagatesubborrow(char[] n ,int index)
        {
            index--;
            while (n[index] == 0)
            {
                n[index] = '9';
                index--;
            }
            n[index]= (char)((int)n[index]-1);
        }

        public static char[] Subtwonumbers(char[] num1, char[] num2)
        {
            int index = 0;
            int c1=0, c2=0;
            int result = 0;
            int len1 = num1.Length;
            int len2 = num2.Length;
            char[]n1= new char[2000];
            char[] n2 = new char[2000];
            char[] tempresult = new char[2000];
            char[] finalresult = new char[2000];
            char sign='+' ;
            if (len1 > len2)
            {
                sign = '+';
                n1 = num1;
                n2= num2;

            }
            else if(len1 < len2) 
            {
                sign = '-';
                n1 = num2;
                n2 = num1;
            }else
            {
                for(int y = 0; y < len1; y++)
                {
                    if (num1[y] > num2[y]) {
                        break;
                    }else if(num1[y] == num2[y]) { }
                    else
                    {
                        sign = '-';
                        

                    }
                }
                if (sign == '-')
                {
                    n1 = num2;
                    n2 = num1;
                }
                else
                {
                    //sign = '+';
                    n1 = num1;
                    n2 = num2;
                }

            }

            int i = n1.Length-1;
            int j= n2.Length-1;
            for (; i >= 0 && j >= 0; i--, j--)
            {
                c1 = n1[i]-'0';
                c2= n2[j]-'0';
                if(c1>=c2)
                {

                }
                else
                {
                    c1 += 10;
                    n1[i] = (char)((int) n1[i] + 10);
                    //
                    propagatesubborrow(n1, i);
                    
                }
                result = c1 - c2 + '0';
                tempresult[index] = (char)result;
                index++;
            }
            while (i >= 0)
            {
                tempresult[index] = n1[i];
                index++;
                i--;
            }
            if (sign == '-')
            {
                tempresult[index] = sign;
                index++;
            }
            tempresult[index] = '\0';
            int k = 0;
            for(int y = index-1; y >= 0; y--)
            {
                finalresult[k]= tempresult[y];
                k++;
            }
            finalresult[index] = '\0';
            return finalresult;
        }
        

        
    }
}
