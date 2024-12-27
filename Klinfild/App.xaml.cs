using Klinfild.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Klinfild
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static KlinfildDbEntities _context;
        public static KlinfildDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new KlinfildDbEntities();
            }
            return _context;
        }
    }
}
