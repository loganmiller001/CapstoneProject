using Capstone.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstone.Startup))]
namespace Capstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        private void CreateRoles()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!roleManager.RoleExists("Soldier"))
            {
                var role = new IdentityRole();
                role.Name = "Soldier";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("First Sergeant"))
            {
                var role = new IdentityRole();
                role.Name = "First Sergeant";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Company Commander"))
            {
                var role = new IdentityRole();
                role.Name = "Company Commander";
                roleManager.Create(role);
            }
        }
    }
}
