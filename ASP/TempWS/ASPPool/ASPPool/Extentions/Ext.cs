using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPPool.Extentions
{
    public static class Ext
    {
        public static string Between(this string s, string start, string end, int shift = 0)
        {
            var startPos = s.IndexOf(start);
            var endPos = s.IndexOf(end);
            while (shift > 0)
            {
                shift--;
                startPos = s.IndexOf(start, startPos + 1);
                endPos = s.IndexOf(end, endPos + 1);

            }
            var tmp = s.Substring(startPos + 1, endPos - startPos - 1);
            return tmp;
        }
    }
}