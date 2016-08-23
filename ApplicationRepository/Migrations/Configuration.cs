namespace ApplicationRepository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationRepository.ApplicationDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        /// <summary>
        /// To write the seeding records through migration command
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ApplicationRepository.ApplicationDb context)
        {
            context.Products.AddOrUpdate(new Product[]
             {
                            new Product() {Id =1,Name="Test1",Category ="Sample Cat", Price=1,StockCount = 1},
                            new Product() {Id =2,Name="Test2",Category ="Sample Cat2", Price=1,StockCount = 1},
                            new Product() {Id =3,Name="Test4",Category ="Sample Cat3", Price=1,StockCount = 1}
             });

        }
    }
}
