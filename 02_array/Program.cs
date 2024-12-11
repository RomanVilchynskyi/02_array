internal class Program
{
    static void BadSwap(int x, int y)
    {
        var tmp = x;
        x = y; 
        y = tmp;
    }
    static void Swap(ref int x, ref int y)
    {
        var tmp = x;
        x = y;
        y = tmp;
    }
    static void SumTwo(int a, int b, out int res)
    {
        res = a + b;
    }
    static void Print<T>(T[] arr, string prompt = "")
    {
        Console.WriteLine(prompt);
        /*for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"{arr[i], -10}");
        }*/
        foreach(var item in arr)
        {
            Console.Write($"{item, -10}");
        }
        Console.WriteLine();
    }
    static void Fill(int[] arr, int min = 0, int max = 50)
    {
        Random rnd = new Random();
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(min, max);
        }
    }
    static void PushBack(ref int[] arr, int value)
    {
        /*int[] tmp = new int[arr.Length + 1];
        *//*for (int i = 0; i < arr.Length; i++)
        {
            tmp[i] = arr[i];
        }*//*
        arr.CopyTo(tmp, 0);
        tmp[tmp.Length - 1] = value;
        arr = tmp;*/

        Array.Resize(ref arr, arr.Length + 1);
        arr[arr.Length - 1] = value;
    }
    private static void Main(string[] args)
    {
        /*Console.WriteLine(@"test/ /n \t\t
            saavv \v\bv\\");*/

        //value type(int, double, float, long, bool, enum, struct) -> Stack
        //reference type(class, interface, string, BuilderString, delegate)->Heap

        /*int a = 5, b = 10;
        Console.WriteLine($"a = {a,-10} b = {b}");
        //BadSwap(a, b);
        Swap(ref a, ref b);
        Console.WriteLine($"a = {a,-10} b = {b}");
        int res;
        SumTwo(a, b, out res);
        Console.WriteLine(res);*/

        int[] arr = new int[5] {1,2,3,4,5};
        int[] arr2 = { 10, 20, 30, 40 };
        //int[] arr3;//null

        Print(arr, "Print array1 :: ");
        Print(arr2, "Print array1 :: ");
        Console.Write("Enter number of elements:: ");
        int size = 10;/*int.Parse(Console.ReadLine());*/
        int[] arr3 = new int[size];
        Fill(arr3,-5,10);
        
        Console.WriteLine();
        Print(arr3, "Print rand array :: ");
        PushBack(ref arr3, 222);
        Print(arr3, "Print array after pushBack :: ");

        int value = 222 /*int.Parse(Console.ReadLine())*/;
        if(arr3.Contains(value))
        {
            Console.WriteLine($"value {value} was found");
        }
        else
        {
            Console.WriteLine($"value {value} not found");
        }
        Console.WriteLine($"Number of elements is positive :: {arr3.Count(IsPos)}");
        int index = Array.IndexOf(arr3, value);
        if(index != -1)
        {
            Console.WriteLine($"Value {value} = index {index}");
            int lastIndex = Array.LastIndexOf(arr3, value);
            Console.WriteLine($"Value {value} = last index {index}");
        }

        int FirstPositive = Array.FindIndex(arr3, IsPos);
        if (FirstPositive != -1)
        {
            Console.WriteLine($"Value positive = index {FirstPositive}");
            int LastPositive = Array.FindLastIndex(arr3, IsPos);
            Console.WriteLine($"Value positive = last index {LastPositive}");
        }
        //(formal params list) => {return ...;};
        index = Array.FindIndex(arr3, (int e) => { return e % 3 == 0; });
        Console.WriteLine($"Position first number % 3 --> {index}");
        int[] events = Array.FindAll(arr3, e => e % 2 == 0);
        Print(events, "Print even elements :: ");   
        Console.WriteLine(Array.TrueForAll(arr3, IsPos));
        Console.WriteLine(Array.Exists(arr3, IsPos));

        Print(arr3, "Print unsorted array :: ");
        Array.Sort(arr3);
        Print(arr3, "Print sorted array :: ");
        Array.Reverse(arr3);
        Print(arr3, "Print reversed array :: ");
        Console.WriteLine(arr3.Sum());
        Console.WriteLine(arr3.Min());
        Console.WriteLine(arr3.Max());
        Console.WriteLine(arr3.Average());

        string[] colors = { "red", "yellow", "Gold", "blue", "aqua" };
        Print(colors, "Print colors :: ");
        Array.Sort(colors);
        Print(colors, "Print colors :: ");
        Array.Sort(colors,(s1,s2)=> s1.Length.CompareTo(s2.Length));
        Print(colors, "Print colors :: ");

        Console.WriteLine();

        int[] positive = Array.FindAll(arr3, IsPos);
        Print(positive, "Print positive elements :: ");
        int[] negative = Array.FindAll(arr3, a => { return a < 0; });
        Print(negative, "Print negative elements :: ");
        Unique(arr3);
        Print(arr3, "Print unique elements :: ");
        
    }
    static int Unique(int[] arr3)
    {
        for (int i = 0; i < arr3.Length; i++)
        {
            bool isUnique = true;
            for (int j = 0; j < arr3.Length; j++)
            {
                if (i != j && arr3[i] == arr3[j])
                {
                    isUnique = false;
                    break;  
                }
            }

            if (isUnique)
            {
                return arr3[i];  
            }
        }
        return -1;
    }

    static bool IsPos(int a)
    {
        return a > 0;
    }
}
