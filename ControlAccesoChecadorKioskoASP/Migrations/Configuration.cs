﻿namespace ControlAccesoChecadorKioskoASP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ControlAccesoChecadorKioskoASP.Models.ControlAccessCheckerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ControlAccesoChecadorKioskoASP.Models.ControlAccessCheckerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // context.Database.ExecuteSqlCommand("Create FUNCTION TruncateTime(dateValue DateTime) RETURNS date return Date(dateValue)");
        }
    }
}
