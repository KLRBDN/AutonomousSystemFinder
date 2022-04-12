using System;
using System.Collections.Generic;

namespace Internet_Protocols._Task_1
{
    public static class TableBuilder
    {
        public static void Build(List<string[]> resultCollection)
        {
            foreach (var result in resultCollection)
            {
                foreach (var entry in result)
                {
                    Console.Write(entry + '\t');
                }

                Console.WriteLine();
            }
        }
    }
}