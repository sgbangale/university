using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Common.Utilities
{
    public class StringHelper
    {
        public static string ReplaceFirstChar(string target, char c)
        {
            if (target == null) throw new ArgumentNullException();
            if (target.Length == 0) throw new ArgumentOutOfRangeException();
            return c + target.Substring(1);
        }
    }
}
