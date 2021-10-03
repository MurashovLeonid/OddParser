using System;
using System.Collections.Generic;
using System.Linq;



namespace ArrayUniqueAnalisysProgram
{
    class ArrayAnalyser
    {
        public static int AnalysisMeth(int[] array)
        {
            int[] testArray = array;
            int methResult;
            Dictionary<string, int> dic = new Dictionary<string, int>();

            List<int> listOrdered = new List<int>();
            List<int> listDistincted = new List<int>();
            var a = from i in testArray orderby i select i;
            var b = (from i in testArray orderby i select i).Distinct();

            foreach (var val in a)
            {
                listOrdered.Add(val);
            }
            foreach (var val in b)
            {
                listDistincted.Add(val);
            }

            for (int i = 0; i <= listDistincted.Count - 1; i++)
            {
                int count = 0;
                for (int j = 0; j <= listOrdered.Count - 1; j++)
                {
                    if (listDistincted[i] == listOrdered[j])
                    {
                        count += 1;
                        if (dic.ContainsKey(listDistincted[i].ToString()))
                        {
                            dic[listDistincted[i].ToString()] += 1;
                        }
                        else
                        {
                            dic.Add(listDistincted[i].ToString(), count);
                        }
                    }
                }
            }

            foreach (var val in dic)
            {
                Console.WriteLine($"Key {val.Key} meets in Dictionary {val.Value} times");
            }

            //Нахождение числа, которое встречается в массиве нечетное число раз
            var h = (from val in dic where val.Value % 2 != 0 select val.Key);

            methResult = Int32.Parse(h.First());
            return methResult;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 5, 5, 5, 2, 2, 3, 3, 3, 3 };
            Console.WriteLine(ArrayAnalyser.AnalysisMeth(testArray));

        }
    }
}
