using bbs.AppTemplate.Interfaces;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(bbs.AppTemplate.UWP.DbContext_helper))]
namespace bbs.AppTemplate.UWP
{
    public class DbContext_helper : IDbContext_helper
    {
        public string GetDbPathOnPlatform(string dbName)
        {
            var folder = ApplicationData.Current.RoamingFolder.Path;
            var dbPath = Path.Combine(folder, "Databases", dbName); 
            if (!File.Exists(dbPath)
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
