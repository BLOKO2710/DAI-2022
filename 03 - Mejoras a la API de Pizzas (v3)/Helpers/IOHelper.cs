using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Pizzas.API.Helpers
{

    public static class IOHelper
    {
        public static bool AppendInFile(string fullFileName, string data)
        {

            try
            {
                using (StreamWriter sw = File.AppendText(fullFileName))
                {
                    sw.WriteLine(data);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}