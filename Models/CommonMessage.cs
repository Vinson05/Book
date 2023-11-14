using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class CommonMessage
    {
      
        public static string Success = "Success";
        public static string Failed = "Failed!";
        public static string NoRecordsFound = "No Record Found!";

    }

    public class Message
    {
        public static ResultSet Messages(bool truefalse, string message, object Result)
        {
            ResultSet _objResultSet = new ResultSet();

            if (truefalse == true)
            {
                _objResultSet.Status = "True";
                _objResultSet.Result = Result;
            }
            else
            {
                _objResultSet.Status = "False";
                _objResultSet.Result = "{}";
            }

            _objResultSet.Message = message;

            return _objResultSet;
        }

    }

}
