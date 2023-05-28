using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ValidationManager
    {
        public static bool IsValidString(string value)
        {
            if (value != null && value != string.Empty && value.Trim().Length > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidTypeSize(char type,char size)
        {
            if (type == 'p' || type == 'g' || type == 'c')
            {
                if (size == 's' || size == 'b' || size == 'l')
                {
                    if (type == 'p' && size == 'l')
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
     
        public static bool IsValidBoxTypeSize(char type, char size)
        {
            if (type == 'c' || type == 'w' || type == 'p')
            {
                if (size == 's' || size == 'm' || size == 'b' || size =='h')
                {
                    return true;
                }
            }
            return false;
        }


    }
}
