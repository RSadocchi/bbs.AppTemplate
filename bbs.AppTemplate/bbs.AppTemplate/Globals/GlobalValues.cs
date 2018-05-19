using bbs.AppTemplate.Services;
using System;
using X = Xamarin.Forms;

namespace bbs.AppTemplate.Globals
{
    public enum Orientations
    {
        Undefined = 0,

        // sample:
        //[FontSize(8.5, 10, 12, 14, 16, X.TargetIdiom.Desktop | X.TargetIdiom.Tablet, new string[] { "iOS" , "Android", "UWP" }, 1000, 10000, 1000, 10000)]
        Landscape,

        Portrait
    }

    public enum DbResults
    {
        Undefined = 0,

        // samples:
        //[StringValue("OMG!!! An error was occurred!!!")]
        Error,

        Fail,

        Success,
    }

    public enum DbActions
    {
        Undefined = 0,
        Delete,
        Insert,
        Update
    }

    public struct DbResult
    {
        public DbActions Action { get; private set; }
        public DbResults Result { get; private set; }
        public int? Id { get; private set; }
        public string TableName { get; private set; }
        public string Message { get; private set; }

        public DbResult(DbActions action, DbResults result, int? id, string tableName, string message)
        {
            Action = action;
            Result = result;
            Id = id;
            TableName = tableName;
            Message = message;
        }
    }

    public static class Icons
    {
        static string prefix
        {
            get
            {
                switch (X.Device.RuntimePlatform)
                {
                    case X.Device.iOS:
                        return "";

                    case X.Device.Android:
                        return "";

                    case X.Device.UWP:
                    case X.Device.WinPhone:
                    case X.Device.WinRT:
                        return "Images/";

                    default:
                        return "";
                }
            }
        }
    }
}
