namespace WebIluminaMVC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<WebIluminaMVC.DataAccess.IluminaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(WebIluminaMVC.DataAccess.IluminaContext context)
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

            context.User.AddOrUpdate(p=>p.username, new Model.User { name = "Victor Hugo",
                                                      lastname = "Zambrano Dominguez",
                                                      username = "admin",
                                                      password = "admin",
                                                      active = true,
                                                      dni = "44748194",
                                                      email = "vhzambrano87@gmail.com" });

            context.Role.AddOrUpdate(p => p.name, new Model.Role {name="Administrador",
                                                                    active=true});


            context.UserRole.AddOrUpdate(p =>new { p.userID, p.roleID }, new Model.UserRole {userID=1,roleID=1 });

            context.Option.AddOrUpdate(p=>p.name, new Model.Option {name = "Usuarios",
                                                                        active =true }
                                                    , new Model.Option {name = "Roles",
                                                                        active = true}
                                                    , new Model.Option {name = "Opciones",
                                                                        active = true}
                                                    , new Model.Option {name = "Empleados",
                                                                        active = true}
                                                    , new Model.Option {name = "Eventos",
                                                                        active = true}
                                                    , new Model.Option {name = "Noticias",
                                                                        active = true}
                                                    , new Model.Option {name = "Sugerencias",
                                                                        active = true}
                                                    , new Model.Option {name = "Encuestas",
                                                                        active = true}
                                                                        );

            context.RoleOption.AddOrUpdate(p => new { p.roleID, p.optionID }, new Model.RoleOption { roleID = 1, optionID = 1 }
                                                              , new Model.RoleOption { roleID = 1, optionID = 2 }
                                                              , new Model.RoleOption { roleID = 1, optionID = 3 }
                                                              , new Model.RoleOption { roleID = 1, optionID = 4 }
                                                              , new Model.RoleOption { roleID = 1, optionID = 5 }
                                                              , new Model.RoleOption { roleID = 1, optionID = 6 }
                                                              , new Model.RoleOption { roleID = 1, optionID = 7 }
                                                              , new Model.RoleOption { roleID = 1, optionID = 8 });

        }
    }
}
