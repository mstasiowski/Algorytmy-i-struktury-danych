
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AlgorytmyLab1
{
    public class Lab1
    {
        public static void Main(string[] args)
        {
            int[] arr1 = { 23, 1, 56, 345, 1, 5, 67, 11 };
            int index = FindTwoDigitMin(arr1);
            if(index ==7)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            int[] arr2 = { };
            index = FindTwoDigitMin(arr2);

            if (index == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            int[] arr3 = { 1, 3, 4, 123, 1234 };
            index = FindTwoDigitMin(arr3);

            if (index == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Fail");
            }

        }

        /// <summary>
        /// Funkacja szuka indeksu najmniejszej liczby dwucyfrowej.
        /// </summary>
        /// <param name="arr">tablica liczb dodatnich</param>
        /// <returns>indeks znaleznionj liczby lub -1, gdy brak takiej liczby</returns>



        public static int FindTwoDigitMin(int[] arr)
        {
            /*
            int result = -1;
           List<int> resultList = new List<int>();

            if(arr.Length> 0 )
            {
               for(int i=0; i<arr.Length; i++)
            }
            


            int result = 0;

            if (arr == null || arr.Length == 0)
            {
                result = -1;
            }
            else
            {


                for (int i = 0; i < arr.Length; i++)
                {
                    // Console.WriteLine(arr[i]);
                    if(arr[i] >=10 && arr[i] <=99)
                    {
                        arr.Min();
                        result = arr[i];
                    }
                   
                }


            }
            

           return result;
            */
            //  return 0;

            int result = -1;
            int min = 99;

            if(arr.Length >0)
            {
                for(int i =0; i < arr.Length; i++)
                {
                    if ((arr[i]<min)&& (arr[i]>=10))
                    {
                        min = arr[i];
                        result = Array.IndexOf(arr, min);
                        
                    }
                }


            }

            return result;



        }
    }
}