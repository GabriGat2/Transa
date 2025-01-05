using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transa
{
    public static class ConvertAG
    {
        /// <summary>
        /// Sonverte una stringa in double.
        /// Se la stringa è vuota o cisono problemi rende 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble0(string value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return 0;
            }
        }
    }
}
