namespace codefirst.Migrations
{
    using codefirst.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<codefirst.Models.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "codefirst.Models.StudentContext";
        }


        protected override void Seed(codefirst.Models.StudentContext context)
        {
            if (!context.Students.Any())
            {
                Student S1 = new Student()
                {
                    Id = 1,
                    Name = "shavez",
                    Age = 22,
                    Course = "btech",
                };
                context.Students.Add(S1);

                List<Student> Stdlist = new List<Student> {
                    new Student{Name="Two",Age=22,Course="btech", },
                    new Student{Name="Threee",Age=22,Course="btech", },
                    new Student{Name="Foir",Age=22,Course="btech", },
                };
                context.Students.AddRange(Stdlist);

                context.SaveChanges();

            }





            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
