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
        /// Converte una stringa in double.
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
        /// <summary>
        /// Verifica se la stringa può essere convertita in double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDouble(string value)
        {
            try
            {
                double tmp = Convert.ToDouble(value);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
        }
        /// <summary>
        /// Rende true se i valore è in prossimità di 0
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool IsZero(double valore)
        {
            return ((valore > -0.001) && (valore < 0.001));
        }


    }
}
