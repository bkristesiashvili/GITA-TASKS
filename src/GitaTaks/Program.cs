using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text;
using static System.Console;


namespace GitaTaks
{
    static class Program
    {
        static void Main(string[] args)
        {
            #region MODULE 1

            #region DATA TYPES TASKS

            PrintMinMaxValues<int>();
            PrintMinMaxValues<long>();
            PrintMinMaxValues<float>();
            PrintMinMaxValues<double>();
            PrintMinMaxValues<char>();
            PrintMinMaxValues<decimal>();
            PrintMinMaxValues<bool>();
            PrintMinMaxValues<DateTime>();

            WriteLine("#------------------------------------------------------------------------------#");

            #endregion

            #region TYPE CASTING TASKS

            sbyte fromSbyte = -100;

            char c = 'a';

            byte a = (byte)fromSbyte; //explicit cast

            short b = fromSbyte; // implicit cast

            int d = c; //implicit cast

            char e = (char)b; //explicit cast

            #endregion

            #region CONVERSION TASKS

            string @bool = bool.TrueString;

            bool fromStr = Convert.ToBoolean(@bool);

            int boolToInt = Convert.ToInt32(fromStr);

            #endregion

            #region STRING BUILDER TASKS

            StringBuilder address = new StringBuilder();

            address.Append("Tbilis");
            address.Append(",Georgia - ");
            address.Append("Lilo Settlement, Quarter 2, Building 1a, Flat #27");

            Print("Besik Kristesiashvili", address.ToString(), ConsoleColor.Green);

            #endregion

            #region LOOP TASKS

            string[] strsArray = new string[10];

            for (int i = 0; i < strsArray.Length; i++)
            {
                strsArray[i] = $"NUMBER: { i + 1 }";
            }

            foreach (var item in strsArray)
            {
                WriteLine(item);
            }

            WriteLine();

            var enumerator = strsArray.GetEnumerator();

            while (enumerator.MoveNext())
            {
                WriteLine(enumerator.Current);
            }

            WriteLine();

            enumerator.Reset();
            var checkNext = enumerator.MoveNext();

            do
            {
                if (checkNext)
                    WriteLine(enumerator.Current);
            } while (checkNext = enumerator.MoveNext());

            #endregion

            #region ARRAYS TASKS

            int[] singleD = new int[5];

            int[,] twoD = new int[5, 6];

            int[,,] threeD = new int[5, 5, 5];

            int[][] jagged = new int[5][];

            for (int i = 0; i < singleD.Length; i++)
            {
                singleD[i] = i + 1;
            }

            var len = Math.Floor(Math.Sqrt(twoD.Length));

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    twoD[i, j] = j + 1;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        threeD[i, j, z] = z + 1;
                    }
                }
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[new Random().Next(10)];

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = j + 1;
                }
            }

            #endregion

            #endregion

            #region MODULE 2

            #region RETURN TWO STRING METHOD

            WriteLine($"{Environment.NewLine}" +
                      $"{ nameof(TwoStringReturn) }({TwoStringReturn(1, true, out var second)}" +
                      $", {second}, out var { nameof(second) });");

            WriteLine($"{Environment.NewLine}" +
                      $"{ nameof(TwoStringReturn) }{TwoStringReturn(1, true)};");


            #endregion

            #endregion

            ReadKey();
        }

        #region DATA TYPES TASK

        static void PrintMinMaxValues<TSource>()
            where TSource : struct
        {
            TypeCode code = Type.GetTypeCode(typeof(TSource));

            /**
             *  IF-ELSE & SWITCH - CASE Statements example 
             *  TASK 5 of the module 1 may used for
             */

            switch (code)
            {
                case TypeCode.Int32:
                    Print("int", $"SIZE: { SizeOf<int>() } | MIN: { int.MinValue } | MAX: { int.MaxValue }", ConsoleColor.Cyan);
                    break;
                case TypeCode.Int64:
                    Print("long", $"SIZE: { SizeOf<long>() } | MIN: { long.MinValue } | MAX: { long.MaxValue }", ConsoleColor.Magenta);
                    break;
                case TypeCode.Single:
                    Print("float", $"SIZE: { SizeOf<float>() } | MIN: { float.MinValue } | MAX: { float.MaxValue }", ConsoleColor.Yellow);
                    break;
                case TypeCode.Double:
                    Print("double", $"SIZE: { SizeOf<double>() } | MIN: { double.MinValue } | MAX: { double.MaxValue }", ConsoleColor.Blue);
                    break;
                case TypeCode.Char:
                    Print("char", $"SIZE: { SizeOf<char>() } | MIN: { (int)char.MinValue } | MAX: { (int)char.MaxValue }", ConsoleColor.Cyan);
                    break;
                case TypeCode.Decimal:
                    Print("decimal", $"SIZE: { SizeOf<decimal>() } | MIN: { decimal.MinValue } | MAX: { decimal.MaxValue }", ConsoleColor.Magenta);
                    break;
                case TypeCode.Boolean:
                    Print("bool", $"SIZE: { SizeOf<bool>() } | MIN: { bool.FalseString } | MAX: { bool.TrueString }", ConsoleColor.Yellow);
                    break;
                case TypeCode.DateTime:
                    Print("datetime", $"SIZE: { SizeOf<DateTime>() } | MIN: { DateTime.MinValue } | MAX: { DateTime.MaxValue }", ConsoleColor.Blue);
                    break;
            }

            int SizeOf<SourceType>() where SourceType : struct
            {
                try
                {
                    return Marshal.SizeOf(typeof(SourceType));
                }
                catch
                {
                    return Marshal.SizeOf(new TypeSizeProxy<SourceType>());
                }
            }
        }

        static void Print(string message, string printOtherMessage, ConsoleColor color = ConsoleColor.White)
        {
            InputEncoding = Encoding.UTF8;
            OutputEncoding = Encoding.UTF8;

            ForegroundColor = color;
            Write($"{ Environment.NewLine }{ message.ToUpper(),10 }");
            ResetColor();
            WriteLine($" { printOtherMessage }");
        }

        #region TYPE SIZE PROXY STRUCT

        internal struct TypeSizeProxy<TSource> where TSource : struct
        {
            internal TSource Source;
        }

        #endregion

        #endregion

        #region MODULE 2 METHOD

        /**
         *  first way of returning two string result
         */
        static string TwoStringReturn(int @int, bool @bool, out string secondResturn)
        {
            secondResturn = @bool.ToString();
            return @int.ToString();
        }

        /**
         *  Second way of return two string result
         */
        static (string, string) TwoStringReturn(int @int, bool @bool)
        {
            return (@int.ToString(), @bool.ToString());
        }

        #endregion
    }
}
