namespace ProdajaTelevizora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTehnologijeEkrana : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TehnologijaEkranas ( Naziv) VALUES ( N'LCD')");
            Sql("INSERT INTO TehnologijaEkranas ( Naziv) VALUES ( N'LED LCD')");
            Sql("INSERT INTO TehnologijaEkranas ( Naziv) VALUES ( N'OLED')");
            Sql("INSERT INTO TehnologijaEkranas ( Naziv) VALUES ( N'QLED')");
            Sql("INSERT INTO TehnologijaEkranas ( Naziv) VALUES ( N'UHD')");

        }
        
        public override void Down()
        {
        }
    }
}
