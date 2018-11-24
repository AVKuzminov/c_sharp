using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapApp
{
    public class Result
    {
        public long? Value { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Обычный конструктор
        /// </summary>
        /// <param name="v"></param>
        public Result(long v)
        {
            Value = v;
            Valid = true;
            Message = null;
        }
        
        /// <summary>
        /// С исключением конструктор
        /// </summary>
        /// <param name="ex"></param>
        public Result(Exception ex)
        {
            Value = null;
            Valid = false;
            Message = string.Format("{0}: {1}",ex.GetType().FullName,ex.Message);
        }

        public Result()
        {
            Value = null;
            Valid = false;
            Message = null;
        }

        public Result(string s)
        {
            Value = null;
            Valid = false;
            Message = s;
        }

    }
}