namespace LeaveApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LeaveApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LeaveApplication.Models.LeaveApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeaveApplication.Models.LeaveApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(u => u.Id,
                new User { Name = "Andrew Peters" },
                new User { Name = "Brice Lambson" },
                new User { Name = "Rowan Miller" },
                new User { Name = "Anthony Lekson" },
                new User { Name = "Liam Smith" },
                new User { Name = "Olivia Johnson" },
                new User { Name = "Mary Brown" },
                new User { Name = "Catherine Jones" },
                new User { Name = "Joe Garcia" },
                new User { Name = "Patricia Anderson" }

                );
        }
    }
}
