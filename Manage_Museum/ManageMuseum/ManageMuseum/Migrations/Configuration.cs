using ManageMuseum.Models;

namespace ManageMuseum.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManageMuseum.Models.OurContectDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ManageMuseum.Models.OurContectDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //context.UserAccounts.AddOrUpdate(x => x.FirstName,
            //    new UserAccount() { FirstName = "Jessica", LastName = "Franco", Username = "jsfranco", Password = "igualparatodos", Role = "spacemanager" },
            //    new UserAccount() { FirstName = "Tiago", LastName = "Gouveia", Username = "jtmg", Password = "igualparatodos", Role = "artpiecemanager" },
            //    new UserAccount() { FirstName = "Andre", LastName = "Figueira", Username = "ffigueira", Password = "igualparatodos", Role = "artpiecemanager" }
            //);
            //context.SaveChanges();

            //context.Roles.AddOrUpdate(x => x.Name,
            //        new Role() {  Name = "spacemanager" },
            //        new Role() { Name = "artpiecemanager" }
            //);
            //context.SaveChanges();

            //context.UserAccounts.AddOrUpdate(x => x.FirstName,
            //    new UserAccount() { FirstName = "Jessica", LastName = "Franco", Username = "jsfranco", Password = "igualparatodos", Role = "1" },
            //    new UserAccount() { FirstName = "Tiago", LastName = "Gouveia", Username = "jtmg", Password = "igualparatodos", Role = "2" },
            //    new UserAccount() { FirstName = "Andre", LastName = "Figueira", Username = "ffigueira", Password = "igualparatodos", Role = "2" }
            //);
            //context.SaveChanges();

            //context.EventState.AddOrUpdate(x => x.Name,
            //    new EventType() { Name = "exposicao" },
            //    new EventType() { Name = "social" }
            //);
            //context.SaveChanges();

            //context.EventStates.AddOrUpdate(x => x.Name,
            //    new EventState() { Name = "poraprovar" },
            //    new EventState() { Name = "exibicao" },
            //    new EventState() { Name = "encerrado" },
            //    new EventState() { Name = "aceites" },
            //    new EventState() { Name = "terminado" }
            //);
            //context.SaveChanges();

            //context.Events.AddOrUpdate(x => x.Name,
            //    new Event() { StartDate = "2018-03-03 00:00:00.000", EnDate = "2018-02-04 00:00:00.000", Description = "Isto é uma descrição de evento", Name = "Palavras Solarentas", EventType = "1", EventState = "1", UserAccount = "2"},
            //    new Event() { StartDate = "2018-03-01 00:00:00.000", EnDate = "2018-03-01 00:00:00.000", Description = "Isto é uma descrição de evento", Name = "Aniversário FNAC", EventType = "2", EventState = "1", UserAccount = "3" },
            //    new Event() { StartDate = "2018-01-18 00:00:00.000", EnDate = "2018-03-18 00:00:00.000", Description = "Isto é uma descrição de evento", Name = "Feira da Maxmat", EventType = "1", EventState = "2", UserAccount = "3" },
            //    new Event() { StartDate = "2018-01-03 00:00:00.000", EnDate = "2018-02-04 00:00:00.000", Description = "Isto é uma descrição de evento", Name = "Encontro de Universitarios", EventType = "2", EventState = "2", UserAccount = "2" },
            //    new Event() { StartDate = "2018-02-03 00:00:00.000", EnDate = "2018-02-04 00:00:00.000", Description = "Isto é uma descrição de evento", Name = "Segunda Guerra Mundial", EventType = "1", EventState = "3", UserAccount = "2" },
            //    new Event() { StartDate = "2017-12-03 00:00:00.000", EnDate = "2017-01-01 00:00:00.000", Description = "Isto é uma descrição de evento", Name = "Concerto do Panda", EventType = "2", EventState = "3", UserAccount = "3" }
            //);
            //context.SaveChanges();
        }
    }
}
