using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DbUp;

namespace MLAA.Database
{
    // Create "00001. Hello, world.sql" script (empty file) in the Scripts folder
    // Install-Package DbUp

    public static class DatabaseUpgrader
    {
        public static void Upgrade(string connectionString)
        {
            var upgrader = DeployChanges.To
                       .SqlDatabase(connectionString)
                       .WithScriptsEmbeddedInAssembly(
                            Assembly.GetExecutingAssembly())
                       .LogToConsole()
                       .Build();

            upgrader.PerformUpgrade();
        }

    }
}
