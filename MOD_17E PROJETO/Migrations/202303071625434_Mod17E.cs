namespace MOD_17E_PROJETO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mod17E : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Morada = c.String(nullable: false, maxLength: 80),
                        CP = c.String(nullable: false, maxLength: 8),
                        Email = c.String(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Servicoes",
                c => new
                    {
                        IdServico = c.Int(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 250),
                        data_criado = c.DateTime(nullable: false),
                        data_começou = c.DateTime(nullable: false),
                        data_Acabou = c.DateTime(nullable: false),
                        valor_pago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        IdTecnico = c.Int(),
                    })
                .PrimaryKey(t => t.IdServico)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Tecnicoes", t => t.IdTecnico)
                .Index(t => t.ClienteID)
                .Index(t => t.IdTecnico);
            
            CreateTable(
                "dbo.Tecnicoes",
                c => new
                    {
                        IdTecnico = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false),
                        Perfil = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTecnico);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicoes", "IdTecnico", "dbo.Tecnicoes");
            DropForeignKey("dbo.Servicoes", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Servicoes", new[] { "IdTecnico" });
            DropIndex("dbo.Servicoes", new[] { "ClienteID" });
            DropTable("dbo.Tecnicoes");
            DropTable("dbo.Servicoes");
            DropTable("dbo.Clientes");
        }
    }
}
