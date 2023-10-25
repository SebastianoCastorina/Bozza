namespace LuxuryForYou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asta",
                c => new
                    {
                        idAsta = c.Int(nullable: false, identity: true),
                        idAuto = c.Int(),
                    })
                .PrimaryKey(t => t.idAsta)
                .ForeignKey("dbo.Autovettura", t => t.idAuto)
                .Index(t => t.idAuto);
            
            CreateTable(
                "dbo.Autovettura",
                c => new
                    {
                        idAuto = c.Int(nullable: false, identity: true),
                        NomeModello = c.String(maxLength: 50),
                        Colore = c.String(maxLength: 50),
                        Costo = c.Decimal(storeType: "money"),
                        Chilometraggio = c.String(maxLength: 50),
                        Luogo = c.String(maxLength: 50),
                        Anno = c.String(maxLength: 50),
                        HasAsta = c.Boolean(),
                        idCasaMadre = c.Int(),
                        HasEpoca = c.Boolean(),
                    })
                .PrimaryKey(t => t.idAuto)
                .ForeignKey("dbo.CasaMadre", t => t.idCasaMadre)
                .Index(t => t.idCasaMadre);
            
            CreateTable(
                "dbo.CasaMadre",
                c => new
                    {
                        idCasaMadre = c.Int(nullable: false, identity: true),
                        NomeCasaMadre = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.idCasaMadre);
            
            CreateTable(
                "dbo.Offerta",
                c => new
                    {
                        idOfferta = c.Int(nullable: false, identity: true),
                        idUtente = c.Int(),
                        idAuto = c.Int(),
                        OffertaFatta = c.Decimal(storeType: "money"),
                        DataOfferta = c.DateTime(storeType: "date"),
                        idAsta = c.Int(),
                    })
                .PrimaryKey(t => t.idOfferta)
                .ForeignKey("dbo.Asta", t => t.idAsta)
                .ForeignKey("dbo.Autovettura", t => t.idAuto)
                .ForeignKey("dbo.Utente", t => t.idUtente)
                .Index(t => t.idUtente)
                .Index(t => t.idAuto)
                .Index(t => t.idAsta);
            
            CreateTable(
                "dbo.Utente",
                c => new
                    {
                        idUtente = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Role = c.String(maxLength: 50),
                        Nome = c.String(maxLength: 50),
                        Cognome = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Indirizzo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.idUtente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offerta", "idUtente", "dbo.Utente");
            DropForeignKey("dbo.Offerta", "idAuto", "dbo.Autovettura");
            DropForeignKey("dbo.Offerta", "idAsta", "dbo.Asta");
            DropForeignKey("dbo.Autovettura", "idCasaMadre", "dbo.CasaMadre");
            DropForeignKey("dbo.Asta", "idAuto", "dbo.Autovettura");
            DropIndex("dbo.Offerta", new[] { "idAsta" });
            DropIndex("dbo.Offerta", new[] { "idAuto" });
            DropIndex("dbo.Offerta", new[] { "idUtente" });
            DropIndex("dbo.Autovettura", new[] { "idCasaMadre" });
            DropIndex("dbo.Asta", new[] { "idAuto" });
            DropTable("dbo.Utente");
            DropTable("dbo.Offerta");
            DropTable("dbo.CasaMadre");
            DropTable("dbo.Autovettura");
            DropTable("dbo.Asta");
        }
    }
}
