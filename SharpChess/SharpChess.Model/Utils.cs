using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpChess.Model
{
    public static class Utils
    {
        private static Random r = new Random();

        public static string Implement960(string s)
        {
            char[] array = s.ToCharArray();
            string retVal = "";
            bool valid960 = false;
            while (!valid960)
            {
                retVal = "";
                int i = array.Length;
                while (i > 1)
                {
                    i--;
                    int j = r.Next(i + 1);
                    var value = array[j];
                    array[j] = array[i];
                    array[i] = value;
                }
                retVal = new string(array);
                if ((retVal.IndexOf('b') % 2 != retVal.LastIndexOf('b') % 2) && (retVal.IndexOf('r') < retVal.IndexOf('k') && retVal.LastIndexOf('r') > retVal.IndexOf('k')))
                {
                    if (retVal != "rnbqkbnr")
                    valid960 = true;
                }
            }
            return retVal;
        }
    }
}
