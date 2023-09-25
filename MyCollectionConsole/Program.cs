namespace MyCollection
{
    public static class Program
    {
        private static void Main()
        {
            var list = new DynamicArray<int>(5) { 1, 2, 3, 4, 5 };
            
            Console.WriteLine("Iterate using foreach loop:");
            PrintList(list);

            Console.WriteLine("Indexers:");
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);
            Console.WriteLine(list[3]);
            Console.WriteLine(list[4]);

            Console.WriteLine("Remove at index 1:");
            list.RemoveAt(1);
            PrintList(list);

            Console.WriteLine("Remove element 3");
            list.Remove(3);
            PrintList(list);

            Console.WriteLine("Add 6, 7, 8");
            list.Add(6);
            list.Add(7);
            list.Add(8);
            PrintList(list);

            Console.WriteLine("Insert 9 to the index of 2");
            list.Insert(2, 9);
            PrintList(list);

            Console.WriteLine("Check if 9 contains in list");
            Console.WriteLine(list.Contains(9) ? "Yes" : "No");

            Console.WriteLine("Find an index of 9");
            Console.WriteLine(list.IndexOf(9));

            var list2 = new DynamicArray<int>(new List<int> { 1, 2, 3, 4, 5, 6 });
            foreach (var i in list2)
            {
                Console.WriteLine(i);   
            }
        }
        
        private static void PrintList(DynamicArray<int> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}