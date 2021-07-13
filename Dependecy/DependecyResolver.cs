using BLInterfaces;
using BussinessLayer;
using DataLayer;
using System.Configuration;

namespace Dependecy
{
    public class DependecyResolver
    {
        #region SINGLTONE
        private static DependecyResolver _instance;
        public static DependecyResolver Instance => _instance = new DependecyResolver();
        #endregion;
        
        public IDL db = new DB_SQL(ConfigurationManager.ConnectionStrings["DB_EpamConnectionString"].ConnectionString);
        public IBL b => new BL_SQL(db);
    }
}