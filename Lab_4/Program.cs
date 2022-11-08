
namespace Task2
{
    internal class Program
    {
    



        public class Task2
        {

            static void Main(string[] args)
            {
                Console.WriteLine("CW2");
                int[] arr = { 0, 2, 4, 6 };
                Console.WriteLine(MinProduct(arr));

                int[] arr2 =  { -2, -1, 10, 10000, -1 };
                Console.WriteLine(MinProduct(arr2));


                Console.WriteLine("");
                Console.WriteLine("CW1");

                int[,] gold = new int[,] { 
                                       { 10, 33, 13, 15 },
                                       { 22, 21, 04, 1 },
                                       { 5, 0, 2, 3 },
                                       { 0, 6, 14, 2 }  };
                Console.WriteLine(CollectGold(gold));


            }

            /// <summary>
            /// W tablicy gold znajdują się dodatnie liczby reprezetujące złoto. 
            /// Górnik zbiera złoto z komórek, zaczyna od dowolnej komórki górnego wiersza (n) i 
            /// i porusza się w dół do dolnego wiersza (0). Może przejść tylko do komórki po prawej lub
            /// do komórki na przekątnej: w prawo w górę lub w prawo w dół, ale ostatecznie musi znaleźć się w dolnym wierszu (0).
            /// Zaimplementuj algorytm, który wyznaczy największa liczbę złota zebraną przez górnika.
            /// </summary>
            /// <param name="gold">Dwuwymiarowa tablica liczb dodatnich</param>
            /// <returns>Liczba zebranego złota</returns>
            /// <exception cref="NotImplementedException"></exception>
            /// <summary>
            // Przykłady
            // Wejście: gold[][] = {{1, 3, 3},
            //     {2, 1, 4},
            //     {0, 6, 4}};
            // Wyjście: 12
            // {(1,0)->(2,1)->(1,2)}
            //
            // Wejście: gold[][] = { {1, 3, 1, 5},
            //     {2, 2, 4, 1},
            //     {5, 0, 2, 3},
            //     {0, 6, 1, 2}};
            // Wyjście: 16
            //     (2,0) -> (1,1) -> (1,2) -> (0,3) LUB
            //     (2,0) -> (3,1) -> (2,2) -> (2,3)
            //
            // Wejście : gold[][] = {{10, 33, 13, 15},
            //     {22, 21, 04, 1},
            //     {5, 0, 2, 3},
            //     {0, 6, 14, 2}};
            // Wyjście: 83 
            // Uwaga!!!
            // Najłatwiej zrealizować algorytm w postaci rekurencyjnej.
            // Memoizacja zmniejszy złożoność czasową.
            static public int CollectGold(int[,] gold)
            {
                int arr_width = gold.GetLength(0);
                int arr_height = gold.GetLength(1);
                int[,] cord_arr = new int[arr_width, arr_height];
                for (int i = 0; i < arr_width; i++)
                {

                    for (int j = 0; j < arr_height; j++)
                    {
                        cord_arr[i, j] = -1;
                    }

                }

                int collectedgold = 0;


                for (int i = 0; i < arr_width; i++)
                {
                  collectedgold   = Math.Max(collectedgold, MaxCollectedGold(gold, i, arr_height - 1, cord_arr));
                }

                return collectedgold;
            }

            static public int MaxCollectedGold(int[,] gold, int row, int column, int[,] cord_arr)
            {
                if (column == 0)
                {
                    return gold[row, column];
                }

                if (cord_arr[row, column] != -1)
                {
                    return cord_arr[row, column];
                }

                int collectedgold = 0;


                for (int i = row - 1; i <= row + 1; i++)
                {

                    if (i >= 0 && i < gold.GetLength(0))
                    {
                        collectedgold = Math.Max(collectedgold, MaxCollectedGold(gold, i, column - 1, cord_arr));
                    }

                }

                cord_arr[row, column] = collectedgold + gold[row, column];

                return cord_arr[row, column];
            }

            /// <summary>
            /// Zaimplementuj funkcję, która wyznaczy najmniejszy ilocz wybranych liczb z tablicy arr.
            /// Iloczyn może składać się z jednej liczby.
            /// Przykład 1
            /// Wejscie: int[] arr = [0, 2, 4, 6]
            /// Wyjście: 0
            /// 
            /// Przykład 2
            /// Wejscie: int[] arr = [-2, -1, 10, 10_000, -1]
            /// Wyjście: -200_000
            /// 
            /// Przykład 3
            /// Wejscie: int[] arr = [2, 1, 10, 10_000, 1]
            /// Wyjście: 1
            /// </summary>
            /// <param name="arr">tablica liczb całkowitych</param>
            /// <returns>najmniejszy iloczyn tablicy wejściowej arr</returns>
            static public int MinProduct(int[] arr)
            {
                int dl = arr.Length;

                if (dl == 1)
                    return arr[0];

                int nmax = int.MinValue;
                int pmin = int.MinValue;
                int count_neg = 0, count_zero = 0;
                int wynik = 1;

                for (int i = 0; i < dl; i++)
                {
                    if (arr[i] == 0)
                    {
                        count_zero++;
                        continue;
                    }

                    if (arr[i] < 0)
                    {
                        count_neg++;
                        nmax = Math.Max(nmax, arr[i]);
                    }

                    if (arr[i] > 0 && arr[i] < pmin)
                    {
                        pmin = arr[i];
                    }

                    wynik = wynik * arr[i];
                }

                if (count_zero == dl || (count_neg == 0 && count_zero > 0))
                    return 0;


                if (count_neg == 0)
                    return pmin;


                if (count_neg % 2 == 0 && count_neg != 0)
                {

                    wynik = wynik / nmax;
                }

                return wynik;
            }

        

        }


    }
}
