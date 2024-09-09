namespace Tasks
{
    internal class Program
    {
        private static void Main()
        {
            TestList();
        }

        private static void TestList()
        {
            Console.WriteLine(nameof(CustomList<int>));
            CustomList<int> intList = new(1);
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.Add));
            intList.Add(5);
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.Add));
            intList.Add(83);
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.Remove));
            intList.Remove();
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.Remove));
            intList.Remove();
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryInsert));
            Console.WriteLine(intList.TryInsert(62, 1));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryInsert));
            Console.WriteLine(intList.TryInsert(62, 0));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryInsert));
            Console.WriteLine(intList.TryInsert(14, 0));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryInsert));
            Console.WriteLine(intList.TryInsert(70, 1));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryErase));
            Console.WriteLine(intList.TryErase(5));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryErase));
            Console.WriteLine(intList.TryErase(1));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryGetAt));
            Console.WriteLine(intList.TryGetAt(5, out int res));
            Console.WriteLine(res);
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryGetAt));
            Console.WriteLine(intList.TryGetAt(0, out int res2));
            Console.WriteLine(res2);
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryForceCapacity));
            Console.WriteLine(intList.TryForceCapacity(int.MinValue));
            Console.WriteLine(intList.Capacity);
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.TryForceCapacity));
            Console.WriteLine(intList.TryForceCapacity(1));
            Console.WriteLine(intList.Capacity);
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.Find));
            Console.WriteLine(intList.Find(5));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.Find));
            Console.WriteLine(intList.Find(14));
            PrintAllElements(intList);

            Console.WriteLine(nameof(intList.Clear));
            intList.Clear();
            PrintAllElements(intList);
        }

        private static void PrintAllElements<T>(CustomList<T> customList)
        {
            Console.WriteLine("{");
            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine("  " + (customList[i] == null ? "null" : customList[i]!.ToString()) + ',');
            }
            Console.WriteLine("}");
            Console.WriteLine();
        }
    }
}