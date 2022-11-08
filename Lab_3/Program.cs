
namespace task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cw1
            int[] arr = { 1, 2, 6, 9, 4, 3 };
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0));
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6));
            Console.WriteLine(IsInArrayRecursive(new int[] { }, 0, arr.Length - 1, 5));

        }


        public static bool IsInArray(int[] arr, int value)
            {

                return IsInArrayRecursive(arr, 0, arr.Length, value);

            }
            /**
             * REKURENCJA
             */
            //Zaimplementuj funkcję, która strategią dziel i zwyciężaj zwróci prawdę jeśli w tablicy
            //'arr' znajduje się wartość parametru 'value'.
            //Przykład
            //int[] arr = { 1, 2, 6 ,9 ,4, 3};
            //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0);          //false
            //Console.Wr iteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6);          //true
            //Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5);          //false
            public static bool IsInArrayRecursive(int[] arr, int left, int right, int value)
            {
                if(left < right && arr.Length != 0 )
                {
                    if(arr[left] == value)
                        {
                        return true;
                    
                    }
                    return IsInArrayRecursive(arr, left + 1, right, value); 
                }


                return false;


            }
      


            //Zdefiniuj funkcję rekurecyjną, która oblicza sumę elementów tablicy podzielnych przez 3
            //Nie można używać instrukcji iteracyjnych!!! Wartość funkcja dla pustej tablicy wynosi 0.
            //Można założyć, że tablica nie będzie równa null. Zdefiniuj funkcję pomocniczą która będzie wywoływana
            //rekurencyjnie wewnątrz SumMod3.
            public static long SumMod3(int[] arr, int begin, int value)
            {
            int arrsum = 0;

            if (arr[begin]% 3 == 0)
            {
                arrsum =  arr[begin];
            }
            throw new NotImplementedException();
        }

        //Zdefiniuj funkcję rekurencyjną, która oblicza silnię liczby.
        public static long Factorial(int n)
            {
                throw new NotImplementedException();
            }

            /**
             * ALGORYTMY I ZŁOŻONOŚĆ
             */
            //Zdefiniuj funkcję, która zwróci indeks liczby, która jest równa sumie pozostałych elementów tablicy
            //Przykład
            //int[] arr = {1, 3, 2, 8, 2};
            //int index = IndexOfSumOfOthers(arr);
            //funkcja w `index` powinna zwrócić 3, gdyż pod tym indeksem jest 8 równe sumie 1 + 3 + 2 + 2.
            //Jeśli w tablicy nie ma takiej liczby lub tablica jest pusta to funkcja pownna zwrócić -1.
            public static int IndexOfSumOfOthers(int[] arr)
            {
                throw new NotImplementedException();
            }
        

    }
}
