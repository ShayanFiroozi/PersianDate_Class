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
using System.Globalization;

/// <summary>
/// Singonet Global Functions
/// </summary>
namespace Singonet.ir.Core
{

    /// <summary>
    /// Class about Dates and Times ( including Persian(Jalali) Calendar useful functions )
    /// </summary>

#if (CORE_INT)

    internal static class CoreDateTime
#else
        public static class CoreDateTime
#endif


  
    {
       
       
        /// <summary>
        /// Type of difference between tow dates
        /// </summary>
        public enum Date_Diff_Type
        {
            In_MilliSeonds = 0,
            In_Seconds = 1,
            In_Minutes = 2,
            In_Hours = 3,
            In_Days = 4
        }




        /// <summary>
        /// Returns Persian(Jalali) current date in 0000/00/00 or 0000-00-00 format
        /// </summary>
        /// <param name="file_name_mode">if set true : replcaces "/" with "-" for filename usage</param>
        /// <returns>persian current date in String<returns>
        public static String PersianDate(bool file_name_mode = false)
        {
            try
            {
                DateTime today = DateTime.Now;
                PersianCalendar pc = new PersianCalendar();

                if (file_name_mode == false)
                {
                    return String.Format("{0:0000}", pc.GetYear(today)) + "/" +
                             String.Format("{0:00}", pc.GetMonth(today)) + "/" + String.Format("{0:00}", pc.GetDayOfMonth(today));
                }
                else
                {

                    return (String.Format("{0:0000}", pc.GetYear(today)) + "/" +
                             String.Format("{0:00}", pc.GetMonth(today)) + "/" + String.Format("{0:00}", pc.GetDayOfMonth(today))).Replace("/", "-");

                    
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static String PersianDate_Full_Date()
        {
            try
            {
                DateTime today = DateTime.Now;
                PersianCalendar pc = new PersianCalendar();

                // return pc.GetDayOfWeek(today).ToString();

                String _today_name = String.Empty;
                String _current_month = String.Empty;


                int _month_id = -1;

                DayOfWeek _day_of_week = pc.GetDayOfWeek(today);

                

               

                 if(_day_of_week == DayOfWeek.Sunday)
                {
                    _today_name = "یکشنبه";
                }

                if (_day_of_week == DayOfWeek.Monday)
                {
                    _today_name = "دو شنبه";
                }

                if (_day_of_week == DayOfWeek.Tuesday)
                {
                    _today_name = "سه شنبه";
                }

                if (_day_of_week == DayOfWeek.Wednesday)
                {
                    _today_name = "چهار شنبه";
                }

                if (_day_of_week == DayOfWeek.Thursday)
                {
                    _today_name = "پنجشنبه";
                }


                if (_day_of_week == DayOfWeek.Friday)
                {
                    _today_name = "جمعه";
                }

                if (_day_of_week == DayOfWeek.Saturday)
                {
                    _today_name = "شنبه";
                }



                _month_id = pc.GetMonth(today);


                if(_month_id == 1)
                {
                    _current_month = "فروردین";
                }


                if (_month_id == 2)
                {
                    _current_month = "اردیبهشت";
                }

                if (_month_id == 3)
                {
                    _current_month = "خرداد";
                }

                if (_month_id == 4)
                {
                    _current_month = "تیر";
                }
                if (_month_id == 5)
                {
                    _current_month = "مرداد";
                }

                if (_month_id == 6)
                {
                    _current_month = "شهریور";
                }

                if (_month_id == 7)
                {
                    _current_month = "مهر";
                }

                if (_month_id == 8)
                {
                    _current_month = "آبان";
                }

                if (_month_id == 9)
                {
                    _current_month = "آذر";
                }

                if (_month_id == 10)
                {
                    _current_month = "دی";
                }

                if (_month_id == 11)
                {
                    _current_month = "بهمن";
                }

                if (_month_id == 12)
                {
                    _current_month = "اسفند";
                }


                return _today_name + " " + pc.GetDayOfMonth(today).ToString() + " " + _current_month + " ماه ";// + pc.GetYear(today);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Returns Gregorian current date in 0000/00/00
        /// </summary>
        /// <param name="file_name_mode">if set true : replcaces "/" with "-" for filename usage</param>
        /// <returns>Gregorian current date in String</returns>
        public static String Gregorian_Date(bool file_name_mode = false)
        {

            try
            {
                DateTime today = DateTime.Now;


                if (file_name_mode == false)
                {
                    return String.Format("{0:0000}", today.Year) + "/" +
                             String.Format("{0:00}", today.Month) + "/" + String.Format("{0:00}", today.Day);
                }
                else
                {

                    return (String.Format("{0:0000}", today.Year) + "/" +
                             String.Format("{0:00}", today.Month) + "/" + String.Format("{0:00}", today.Day)).Replace("/", "-");


                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }





        /// <summary>
        /// Normalize Persian date from 0000\00\00 or 0000/00/00 to 0000/00/00 or 0000-00-00 format
        /// </summary>
        /// <param name="PDate">Persian Date</param>
        /// <exception cref="DateTime_Exceptions.NotValidPersianDate">ocuures when input String is not a valid persian date</exception>
        /// <returns>Normalized persian date</returns>
        public static String normalize_Persian_Date(String persianDate,bool file_mode = false)
        {

            try
            {

                String P_year; String P_month; String P_day;

                char[] delimiterChars = { '\\', '/','-' };

                String[] parts = persianDate.Split(delimiterChars);

                P_year = parts[0];
                P_month = parts[1];
                P_day = parts[2];

                P_year = String.Format("{0:0000}", Convert.ToInt32(P_year)).ToString();
                P_month = String.Format("{0:00}", Convert.ToInt32(P_month)).ToString();
                P_day = String.Format("{0:00}", Convert.ToInt32(P_day));

                if (file_mode == true) { return P_year + "-" + P_month + "-" + P_day; }
                if (file_mode == false) { return P_year + "/" + P_month + "/" + P_day; }

                // unreachable return code ! just for ignore compiler error
                return "";

            }
            catch
            {
                throw new DateTime_Exceptions.NotValidPersianDate();
            }
        }






        /// <summary>
        /// Validate Persian Date , Legal formats are 0000/00/00 , 0000\00\00 , 0000-00-00 , 0000/0/0 , 0000\0\0 , 0000-0-0
        /// </summary>
        /// <param name="PDate">Persian Date String</param>
        /// <returns>Boolean(true or false)</returns>
        public static bool validate_Persian_Date_format(String persianDate)
        {

            try
            {

                int P_year; int P_month; int P_day;


                if (persianDate.Length <8) { return false; } // standard persian date's length is 10

                char[] delimiterChars = { '-', '\\', '/' };

                String[] parts = persianDate.Split(delimiterChars);

                P_year = Convert.ToInt32(parts[0]);
                P_month = Convert.ToInt32(parts[1]);
                P_day = Convert.ToInt32(parts[2]);

                if ((P_year < 1000) || (P_month < 1 || P_month > 12) || (P_day < 1 || P_day > 31))
                {
                    return false;
                }


                return true;
            }

            catch
            {
                return false;
            }

        }






        /// <summary>
        /// Get year part of a Persan Date String
        /// </summary>
        /// <param name="persianDate">input Persian Date in String</param>
        /// <exception cref="DateTime_Exceptions.NotValidPersianDate">ocuures when input String is not a valid persian date</exception>
        /// <returns>String</returns>
        public static String Persian_date_get_year(String persianDate)
        {

            try
            {
                persianDate = normalize_Persian_Date(persianDate);

                if (validate_Persian_Date_format(persianDate) == false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }

                char[] delimiterChars = { '/' };

                String[] parts = persianDate.Split(delimiterChars);

                int P_year = Convert.ToInt32(parts[0]);


                if ((P_year > 1000))
                {
                    return P_year.ToString();
                }

                return "";

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }







        /// <summary>
        /// Get month part of a Persan Date String
        /// </summary>
        /// <param name="persianDate">input Persian Date in String</param>
        /// /// <exception cref="DateTime_Exceptions.NotValidPersianDate">ocuures when input String is not a valid persian date</exception>
        /// <returns>String</returns>
        public static String Persian_date_get_month(String persianDate)
        {

            try
            {
                persianDate = normalize_Persian_Date(persianDate);

                if (validate_Persian_Date_format(persianDate) == false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }

                char[] delimiterChars = { '/' };

                String[] parts = persianDate.Split(delimiterChars);

                int P_month = Convert.ToInt32(parts[1]);




                if ((P_month >= 1 || P_month <= 12))
                {
                    return string.Format("{0:00}", P_month);
                }

                return "";

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }






        /// <summary>
        /// Get day part of a Persan Date String
        /// </summary>
        /// <param name="persianDate">input Persian Date in String</param>
        /// /// <exception cref="DateTime_Exceptions.NotValidPersianDate">ocuures when input String is not a valid persian date</exception>
        /// <returns>String</returns>
        public static String Persian_date_get_day(String persianDate)
        {

            try
            {
                persianDate = normalize_Persian_Date(persianDate);

                if (validate_Persian_Date_format(persianDate) == false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }

                char[] delimiterChars = { '/' };

                String[] parts = persianDate.Split(delimiterChars);

                int P_day = Convert.ToInt32(parts[2]);


                if ((P_day >= 1 || P_day >= 31))
                {
                    return  string.Format("{0:00}", P_day);
                }

                return "";
            }

            catch (Exception ex)

            {
                throw ex;
            }
        }




        

        /// <summary>
        /// Add specific day(s) to a Persian date
        /// </summary>
        /// <param name="persianDate">Persian date in String format</param>
        /// <param name="days_to_add">Day(s) to add</param>
        /// /// <exception cref="DateTime_Exceptions.NotValidPersianDate">ocuures when input String is not a valid persian date</exception>
        /// <returns>String</returns>
        public static String Add_Day_To_Persian_Date(String persianDate, int days_to_add)
        {




            try
            {
                persianDate = normalize_Persian_Date(persianDate);

                if (validate_Persian_Date_format(persianDate) == false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }

                // convert Persian date to Gregorian calendar
                DateTime dt = new DateTime(Convert.ToInt32(Persian_date_get_year(persianDate)),
                                Convert.ToInt32(Persian_date_get_month(persianDate)), Convert.ToInt32(Persian_date_get_day(persianDate)), new PersianCalendar());

                dt = dt.AddDays(days_to_add); // add day(s) to calendar

                PersianCalendar pc = new PersianCalendar();

                return String.Format("{0:0000}", pc.GetYear(dt)) + "/" +
                             String.Format("{0:00}", pc.GetMonth(dt)) + "/" + String.Format("{0:00}", pc.GetDayOfMonth(dt));

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }






        /// <summary>
        /// Add specific month(s) to a Persian date
        /// </summary>
        /// <param name="persianDate">Persian date in String format</param>
        /// <param name="days_to_add">Month(s) to add</param>
        /// /// <exception cref="DateTime_Exceptions.NotValidPersianDate">ocuures when input String is not a valid persian date</exception>
        /// <returns>String</returns>
        public static String Add_Month_To_Persian_Date(String persianDate, int month_to_add)
        {



            try
            {
                persianDate = normalize_Persian_Date(persianDate);

                if (validate_Persian_Date_format(persianDate) == false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }

                // convert Persian date to Gregorian calendar
                DateTime dt = new DateTime(Convert.ToInt32(Persian_date_get_year(persianDate)),
                                Convert.ToInt32(Persian_date_get_month(persianDate)), Convert.ToInt32(Persian_date_get_day(persianDate)), new PersianCalendar());

                dt = dt.AddMonths(month_to_add); // add month(s) to calendar

                PersianCalendar pc = new PersianCalendar();

                return String.Format("{0:0000}", pc.GetYear(dt)) + "/" +
                             String.Format("{0:00}", pc.GetMonth(dt)) + "/" + String.Format("{0:00}", pc.GetDayOfMonth(dt));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        /// <summary>
        /// Add specific year(s) to a Persian date
        /// </summary>
        /// <param name="persianDate">Persian date in String format</param>
        /// <param name="days_to_add">Year(s) to add</param>
        /// /// <exception cref="DateTime_Exceptions.NotValidPersianDate">ocuures when input String is not a valid persian date</exception>
        /// <returns>String</returns>
        public static String Add_Year_To_Persian_Date(String persianDate, int year_to_add)
        {



            try
            {
                persianDate = normalize_Persian_Date(persianDate);

                if (validate_Persian_Date_format(persianDate) == false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }

                // convert Persian date to Gregorian calendar
                DateTime dt = new DateTime(Convert.ToInt32(Persian_date_get_year(persianDate)),
                                Convert.ToInt32(Persian_date_get_month(persianDate)), Convert.ToInt32(Persian_date_get_day(persianDate)), new PersianCalendar());

                dt = dt.AddYears(year_to_add); // add Year(s) to calendar

                PersianCalendar pc = new PersianCalendar();

                return String.Format("{0:0000}", pc.GetYear(dt)) + "/" +
                             String.Format("{0:00}", pc.GetMonth(dt)) + "/" + String.Format("{0:00}", pc.GetDayOfMonth(dt));

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }






        /// <summary>
        /// Returns current time in 00:00:00 format
        /// </summary>
        /// <param name="file_name_mode">if set true : replcaces ":" with "-" for filename usage</param>
        /// <returns>Returns current time in String</returns>
        public static String Get_Current_Time(bool file_name_mode = false)
        {

            try
            {
                if (file_name_mode == false)
                {
                    return String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute) + ":" +
                                                                                     String.Format("{0:00}", DateTime.Now.Second);
                }
                else
                {
                    return (String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute) +
                                                                       ":" + String.Format("{0:00}", DateTime.Now.Second)).Replace(":", "-");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        /// <summary>
        /// Returns current time in 00:00:00.00 format
        /// </summary>
        /// <returns>Returns current time with milliseconds in String</returns>
        public static String Current_Time_With_MilliSecond()
        {

            try
            {
                DateTime CurrentDateTime = DateTime.Now;

                // get current time
                return String.Format("{0:00}", CurrentDateTime.Hour) + ":" +
                                  String.Format("{0:00}", CurrentDateTime.Minute) + ":" +
                                  String.Format("{0:00}", CurrentDateTime.Second) + "." +
                                  String.Format("{0:000}", CurrentDateTime.Millisecond); // should be .(Dot) for millisecond

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }





        /// <summary>
        /// Convert Gregorian Date to the Persian(Jalali) Calendar
        /// </summary>
        /// <param name="_Gregorian_date">DateTime object , Gregrian Date to convert</param>
        /// <returns>String : Persian Date</returns>
        public static String Gregorian_To_Persian(DateTime _Gregorian_date)
        {
            PersianCalendar pc = new PersianCalendar();
            

            return String.Format("{0:0000}", pc.GetYear(_Gregorian_date)) + "/" +
                            String.Format("{0:00}", pc.GetMonth(_Gregorian_date)) + "/" + String.Format("{0:00}", pc.GetDayOfMonth(_Gregorian_date));
        }




        /// <summary>
        /// Convert Gregorian Date to the Persian(Jalali) Calendar
        /// </summary>
        /// <param name="_Gregorian_date">String  , Gregrian Date to convert</param>
        /// <returns>String : Persian Date</returns>
        public static String Gregorian_To_Persian(String _Gregorian_date)
        {



            PersianCalendar pc = new PersianCalendar();

            


            return String.Format("{0:0000}", pc.GetYear(Convert.ToDateTime(_Gregorian_date))) + "/" +

                            String.Format("{0:00}", pc.GetMonth(Convert.ToDateTime(_Gregorian_date))) + "/" +

                                       String.Format("{0:00}", pc.GetDayOfMonth(Convert.ToDateTime(_Gregorian_date)));
        }




        /// <summary>
        /// Convert Gregorian Date and Time to the Persian(Jalali) Calendar
        /// </summary>
        /// <param name="_Gregorian_date">Gregrian Date to convert</param>
        /// <returns>String : Persian Date and Time</returns>
        public static String Gregorian_To_Persian_With_Time(DateTime _Gregorian_date)
        {

        

            PersianCalendar pc = new PersianCalendar();

            return String.Format("{0:0000}", pc.GetYear(_Gregorian_date)) + "/" +

                            String.Format("{0:00}", pc.GetMonth(_Gregorian_date)) + 
  
                                "/" + String.Format("{0:00}", pc.GetDayOfMonth(_Gregorian_date) + " " +

                                                             pc.GetHour(_Gregorian_date).ToString() + ":" + 

                                                               pc.GetMinute(_Gregorian_date).ToString() + ":" + 

                                                                           pc.GetSecond(_Gregorian_date).ToString());
        }




        /// <summary>
        /// Convert Persian Date to gregorian date
        /// </summary>
        /// <param name="_PersianDate"></param>
        /// <returns>DateTime object , Gregorian calendar</returns>
        public static DateTime Persian_To_Greagorian(String _PersianDate)
        {

        

            try
            {
                if (validate_Persian_Date_format(_PersianDate) == false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }


                return new DateTime(Convert.ToInt32(Persian_date_get_year(_PersianDate)),
                                                      Convert.ToInt32(Persian_date_get_month(_PersianDate)),
                                                               Convert.ToInt32(Persian_date_get_day(_PersianDate)), new PersianCalendar());

            }

            catch(Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// Return 2 Dates difference
        /// </summary>
        /// <param name="date1">First Date (DateTime Format)</param>
        /// <param name="date2">Second Date (DateTime Format)</param>
        /// <returns>Double , difference between two dates</returns>
        public static double Get_Dates_Different(DateTime date1,DateTime date2,Date_Diff_Type diff_type)
        {

          

            try
            {
                // calculate difference between two dates
                TimeSpan diff = (date1 - date2);


                // then convert the difference in desire format

                if (diff_type == Date_Diff_Type.In_MilliSeonds)
                {
                    return diff.TotalMilliseconds;
                }


                if (diff_type == Date_Diff_Type.In_Seconds)
                {
                    return diff.TotalSeconds;
                }



                if (diff_type == Date_Diff_Type.In_Minutes)
                {
                    return diff.TotalMinutes;
                }


                if (diff_type == Date_Diff_Type.In_Hours)
                {
                    return diff.TotalHours;
                }



                if (diff_type == Date_Diff_Type.In_Days)
                {
                    return diff.TotalDays;
                }

            }

            catch
            {
                return -1;
            }

            return -1;
        }




        /// <summary>
        /// Return 2 Persian Dates difference
        /// </summary>
        /// <param name="date1">First Date (String Format)</param>
        /// <param name="date2">Second Date (String Format)</param>
        /// <returns>Double , difference between two dates</returns>
        public  static double Get_Persian_Dates_Difference(String date1, String date2, Date_Diff_Type diff_type)
        {
           

            try
            {

                if(validate_Persian_Date_format(date1)==false || validate_Persian_Date_format(date2)==false)
                {
                    throw new DateTime_Exceptions.NotValidPersianDate();
                }

                // calculate difference between two dates


                DateTime dt_1 = Persian_To_Greagorian(date1);



                DateTime dt_2 = Persian_To_Greagorian(date2);


              

                TimeSpan diff = (dt_1 - dt_2);


                // then convert the difference in desire format

                if (diff_type == Date_Diff_Type.In_MilliSeonds)
                {
                    return diff.TotalMilliseconds;
                }


                if (diff_type == Date_Diff_Type.In_Seconds)
                {
                    return diff.TotalSeconds;
                }



                if (diff_type == Date_Diff_Type.In_Minutes)
                {
                    return diff.TotalMinutes;
                }


                if (diff_type == Date_Diff_Type.In_Hours)
                {
                    return diff.TotalHours;
                }



                if (diff_type == Date_Diff_Type.In_Days)
                {
                    return diff.TotalDays;
                }

            }

            catch
            {
                return -1;
            }

            return -1;
        }








    } // End of DateTime class

} // End of Singonet.ir.Core namespace

