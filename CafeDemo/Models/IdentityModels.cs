using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CafeDemo.Models.CafeModels;
using CafeDemo.Models.EnumClasses;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using CafeDemo.Models.StoreModels;

namespace CafeDemo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Ta2re4a> Ta2re4a { get; set; }

        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Far3> Far3 { get; set; }
        public DbSet<Daraga> Daraga { get; set; }
        /// /////////////   store models//////////////
        public DbSet<GoodsAddtion> GoodsAddtions { get; set; }
        //public DbSet<GoodsAddtionProduct> GoodsAddtionProducts { get; set; }
        public DbSet<GoodsAddtionPayment> GoodsAddtionPayments { get; set; }
        public DbSet<Tager> Tagers { get; set; }
        public DbSet<Kafteria> Kafterias{ get; set; }
        public DbSet<GoodsSell> GoodsSells { get; set; }
        //public DbSet<GoodsSellProduct> GoodsSellProducts { get; set; }
        public DbSet<GoodsSellPayment> GoodsSellPayments { get; set; }

        public DbSet<Goods> Goods  { get; set; }




        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CafeDemo.Models.ViewModels.ReportViewModels.StoreReportViewModel> StoreReportViewModels { get; set; }
    }
}