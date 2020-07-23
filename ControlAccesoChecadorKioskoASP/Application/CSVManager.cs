using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Application
{
    public class CSVManager
    {
        public static byte[] FromMatrixToCSVBytes(List<List<object>> keyValuePairs)
        {
            int columns = keyValuePairs[0].Count;

            string result = "";
            foreach (var values in keyValuePairs)
            {
                for (int i = 0; i < columns; i++)
                {
                    if (i != columns - 1)
                    {
                        result += $"{values[i]};";
                    } else
                        result += $"{values[i]}\n";
                }
            }


            return Encoding.UTF8.GetBytes(result);
        }
    }
}