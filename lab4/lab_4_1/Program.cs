//using System;
//using System.Runtime.InteropServices;

//namespace lab_4_1
//{
//    class Program
//    {
//        public const string dll = @"/Users/slavick.snegirevicloud.com/Projects/lab_4/lab_4_1/main.dll";
//        [DllImport(dll, EntryPoint ="input_array", CallingConvention = CallingConvention.StdCall)]
//        public static extern void input_array(IntPtr intPtr);
//        [DllImport(dll, EntryPoint ="output_array", CallingConvention = CallingConvention.StdCall)]
//        public static extern void output_array(IntPtr intPtr);
//        [DllImport(dll, EntryPoint ="processing_array", CallingConvention = CallingConvention.StdCall)]
//        public static extern int processing_array(IntPtr intPtr);

//        static void Main(string[] args)
//        {
//            int[] array = new int[25];
//            double result;
//            unsafe
//            {
//                fixed (int* pArray = array)
//                {
//                    IntPtr intPtr = new IntPtr(pArray);
//                    Console.WriteLine("Массив будет заполнен случайными числами.");
//                    input_array(intPtr);
//                    Console.WriteLine("Вывод массива.\n========================================================");
//                    output_array(intPtr);
//                    result = processing_array(intPtr);
//                    Console.WriteLine("========================================================\nКвадрат суммы всех элементов с нечётными индексами: " + result);
//                }
//            }
//            Console.ReadKey();
//        }
//    }
//}
using System;

namespace test0
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            
            fixed (char* value = "sam")
            {
                char* ptr = value;
                while (*ptr != '\0')
                {
                    Console.WriteLine(*ptr);
                    ptr++;
                }

            }
            Console.ReadKey();
        }
    }
}
