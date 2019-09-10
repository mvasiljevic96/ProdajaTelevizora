namespace ProdajaTelevizora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fakturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumKupovine = c.DateTime(nullable: false),
                        Kupac_Id = c.Int(nullable: false),
                        Televizor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kupacs", t => t.Kupac_Id, cascadeDelete: true)
                .ForeignKey("dbo.Televizors", t => t.Televizor_Id, cascadeDelete: true)
                .Index(t => t.Kupac_Id)
                .Index(t => t.Televizor_Id);
            
            CreateTable(
                "dbo.Kupacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Adresa = c.String(),
                        BrojTelefona = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Televizors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        DijagonalaEkrana = c.String(),
                        Dimenzije = c.String(),
                        Cijena = c.String(),
                        TehnologijaEkrana_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TehnologijaEkranas", t => t.TehnologijaEkrana_Id)
                .Index(t => t.TehnologijaEkrana_Id);
            
            CreateTable(
                "dbo.TehnologijaEkranas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fakturas", "Televizor_Id", "dbo.Televizors");
            DropForeignKey("dbo.Televizors", "TehnologijaEkrana_Id", "dbo.TehnologijaEkranas");
            DropForeignKey("dbo.Fakturas", "Kupac_Id", "dbo.Kupacs");
            DropIndex("dbo.Televizors", new[] { "TehnologijaEkrana_Id" });
            DropIndex("dbo.Fakturas", new[] { "Televizor_Id" });
            DropIndex("dbo.Fakturas", new[] { "Kupac_Id" });
            DropTable("dbo.TehnologijaEkranas");
            DropTable("dbo.Televizors");
            DropTable("dbo.Kupacs");
            DropTable("dbo.Fakturas");
        }
    }
}
