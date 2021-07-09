using BLInterfaces;
using BussinessLayer;
using DataLayer;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependecy
{
    public class DependecyResolver
    {
        #region SINGLTONE
        private static DependecyResolver _instance;
        public static DependecyResolver Instance => _instance = new DependecyResolver();
        #endregion;

        public IBL b = new BL();
        static void Main(string[] args){}
    }
}