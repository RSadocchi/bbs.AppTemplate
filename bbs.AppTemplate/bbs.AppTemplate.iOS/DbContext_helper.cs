using bbs.AppTemplate.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(bbs.AppTemplate.iOS.DbContext_helper))]
namespace bbs.AppTemplate.iOS
{
    public class DbContext_helper : IDbContext_helper
    {
        public string GetDbPathOnPlatform(string dbName)
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Databases");
            if (!Directory.Exists(folder))
                try
                {
                    Directory.CreateDirectory(folder);
                }
                catch
                {
                    throw;
                }

            var dbPath = Path.Combine(folder, dbName);
            if (!File.Exists(dbPath))
                try
                {
                    using (var stream = File.Create(dbPath))
                    {
                        // TO DO: any additional operation here
                    }
                }
                catch
                {
                    throw;
                }

            return dbPath;
        }
    }
}