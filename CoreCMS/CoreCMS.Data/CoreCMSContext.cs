using CoreCMS.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreCMS.Data
{
    public class CoreCMSContext : IdentityDbContext<CustomUser, CustomRole, int>
    {
        public CoreCMSContext(DbContextOptions<CoreCMSContext> options) : base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Sidebar> Sidebars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sidebar>()
                .HasData(new Sidebar
                {
                    Id = 1,
                    SidebarTitle = "Test Sidebar",
                    Content = "<p>The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.</p>"
                });

            builder.Entity<Page>()
                .HasData(new Page
                {
                    Id = 1,
                    Title = "Home",
                    Slug = "home",
                    Content = "<p>Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.</p><p>The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.</p>",
                    IsPageVisibleInMenu = true,
                    IsSidebarVisible = true,
                    SidebarId = 1
                },
                new Page
                {
                    Id = 2,
                    Title = "ASP.NET Core Online Training",
                    Slug = "asp-dot-net-core-online-training",
                    Content = "<p>Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.</p><p>The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.</p>",
                    IsPageVisibleInMenu = true,
                    IsSidebarVisible = true,
                    SidebarId = 1
                });

            builder.Entity<CustomRole>().HasData(new CustomRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = 1,
                ConcurrencyStamp = "admin"
            });

            var appUser = new CustomUser
            {
                Id = 1,
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "Test",
                UserName = "test",
                NormalizedUserName = "TEST",
                SecurityStamp = "test"
            };

            //set user password
            PasswordHasher<CustomUser> hasher = new();
            appUser.PasswordHash = hasher.HashPassword(appUser, "TEST@#123");

            builder.Entity<CustomUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });

            base.OnModelCreating(builder);
        }
    }
}