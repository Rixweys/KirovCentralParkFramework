using KirovCentralParkFramework.Models;

namespace KirovCentralParkFramework.Classes
{
    public class DBConnect
    {
        private static yurtymbaevEntities _dbContext;
        public static yurtymbaevEntities DBContext { get => _dbContext == null ? _dbContext = new() : _dbContext; }

    }
}
