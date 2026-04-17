using NexPos.Data;
using NexPos.Data.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NexPos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Database.SetInitializer(new DatabaseInitializer());

            using (var db = new AppDbContext())
            {
                db.Database.Initialize(false);
            }
        }
    }
}
