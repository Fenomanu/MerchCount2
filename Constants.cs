using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchCount2
{
    public static class Constants
    {
        public const string DatabaseFilename = "MerchCount.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(StoragePath, DatabaseFilename);

        public static string StoragePath =>
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public const string ImagesFolder = "Images";
        public static string ImagesPath =>
            Path.Combine(Constants.StoragePath, Constants.ImagesFolder);
    }
}
