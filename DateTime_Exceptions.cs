/******************************************************************* 
 *             Forever Persian Gulf , Forever Persia               *
 *                                                                 *
 *                 ----> Singonet.ir <----                         *
 *                                                                 *
 * C# Singnet.ir.Core                                              *
 *                                                                 *
 * By Shayan Firoozi 2017 Bandar Abbas - Iran                      *
 * EMail : Singonet.ir@gmail.com                                   *
 * Phone : +98 936 517 5800                                        *
 *                                                                 *
 *******************************************************************/

using System;


namespace Singonet.ir.Core
{

#if (CORE_INT)

    internal static class DateTime_Exceptions
#else
        public static class DateTime_Exceptions
#endif



    {

        /// <summary>
        /// Persian date is not on a valid format
        /// </summary>
        public class NotValidPersianDate : Exception
        {
            public NotValidPersianDate()
                : base("Not a valid Persian Date.")
            {
            }

        }




    } // End of DateTime_Exceptions class

}// End of Singonet.ir.Core namespace
