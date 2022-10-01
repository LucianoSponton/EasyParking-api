using System;

namespace EasyParkingAPI.Service
{
    public static class Tools
    {
        public static string ExceptionMessage(Exception e)
        {
            string message = e.Message;
            while (e.InnerException != null)
            {
                e = e.InnerException;
                message = message + " -*- " + e.Message;
            };


            return message;

        }
    }





}
