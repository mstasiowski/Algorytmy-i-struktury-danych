using System.ComponentModel.Design.Serialization;

namespace lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 6, 9, 11, 15, 20 };
            Console.WriteLine(InterpolationSearch(arr, 1));

            BSTTree<int> tree = new BSTTree<int>() { Root = new TreeNode<int>() { value = 15 } };
            tree.Root.Left = new TreeNode<int>() { value = 7, Left = new TreeNode<int> { value = 3, Right = new TreeNode<int>() { value = 10 } } };
            tree.Root.Right = new TreeNode<int>() { value = 20, Left = new TreeNode<int> { value = 19, Right = new TreeNode<int>() { value = 40 } } };
            tree.print();
            Console.WriteLine(tree.Contains(20));
            Console.WriteLine(tree.Contains(45));
            SortedSet<int> ints = new SortedSet<int>();
            ints.Add(5);
            ints.Add(1);
            ints.Add(8);
            ints.Add(10);
            ints.Add(12);

            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
            ints.Remove(12);
            Console.WriteLine(ints.Contains(12));
            Console.WriteLine(ints.Contains(10));
            SortedSet<int> range = ints.GetViewBetween(6, 11);
            Console.WriteLine(String.Join(" ", range));
            ints.UnionWith(Enumerable.Range(3, 9));
            Console.WriteLine(String.Join(" ", ints));

            SortedSet<Student> students = new SortedSet<Student>(new StudentComparer());
            students.Add(new Student("Adam", 20));
            students.Add(new Student("Adam", 21));
            students.Add(new Student("Ewa", 13));
            students.Add(new Student("Karol", 26));
            Console.WriteLine(String.Join(" ", students));

            Console.WriteLine(students.Contains(new Student("Adam", 34)));
            Console.WriteLine(students.Contains(new Student("Adam", 21)));

            //Utworz i przetestuj działanie SortedSet dla imion: Adam, Karol, Ewa, Ola, Robert
            //przetestować metody: Contains, kolejnosc w foreach, getRangeView

            SortedSet<string> strings = new SortedSet<string>();
            strings.Add("Adam");
            strings.Add("Karol");
            strings.Add("Ewa");
            strings.Add("Ola");
            strings.Add("Robert");

            Console.WriteLine("contains");
            Console.WriteLine(strings.Contains("Robert"));


            Console.WriteLine("foreach");
            foreach (string name in strings)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("getRangeView");
            SortedSet<string> StringsRange = strings.GetViewBetween("Karol", "Ola");
            Console.WriteLine(String.Join(" ", StringsRange));


        }


        class StudentComparer : IComparer<Student>
        {
            public int Compare(Student? x, Student? y)
            {
                if (x is null)
                {
                    throw new NullReferenceException();
                }
                int r = x.Name.CompareTo(y.Name);
                return r == 0 ? x.Ects.CompareTo(y.Ects) : r;
            }
        }
        record Student(string Name, int Ects);

        class TreeNode<T>
        {
            public T value { get; set; }
            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }
        }

        class BSTTree<T> where T : IComparable<T>
        {
            public TreeNode<T> Root { get; set; }
            public bool Contains(T value)
            {
                return recursiveContains(Root, value);
            }

            private bool recursiveContains(TreeNode<T> node, T value)
            {
                if (node is null)
                {
                    return false;
                }
                int r = node.value.CompareTo(value);
                if (r == 0) //równe
                {
                    return true;

                }
                else
                {
                    return recursiveContains(r < 0 ? node.Right : node.Left, value);
                }
            }

            public void print()
            {
                recurisivePrint(Root, 0);
            }

            private void recurisivePrint(TreeNode<T> node, int level)
            {
                if (node is null)
                {
                    return;
                }

                string ident = string.Concat(Enumerable.Repeat("-", level));
                Console.WriteLine(ident + node.value);
                Console.WriteLine(node.value);
                recurisivePrint(node.Left, level + 1);
                recurisivePrint(node.Right, level + 1);
            }
        }





        public static bool InterpolationSearch(int[] arr, int value)
        {
            int min = arr[0];
            int max = arr[arr.Length - 1];
            int i = 0 + ((value - min) * (arr.Length - 1) / (max - min));
            if (i > arr.Length - 1)
            {
                return false;
            }
            if (arr[i] == value)
            {
                return true;
            }

            //lewa strona tablicy
            if (value < arr[i])
            {
                while (i > 0 && arr[i] < value)
                {
                    if (arr[--i] == value)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {

                while (i < arr.Length - 1 && arr[i] < value)
                {
                    if (arr[++i] == value)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}