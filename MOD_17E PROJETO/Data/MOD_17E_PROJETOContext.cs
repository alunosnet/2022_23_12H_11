using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MOD_17E_PROJETO.Data
{
    public class MOD_17E_PROJETOContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MOD_17E_PROJETOContext() : base("name=MOD_17E_PROJETOContext")
        {
        }

        public System.Data.Entity.DbSet<MOD_17E_PROJETO.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<MOD_17E_PROJETO.Models.Tecnico> Tecnicoes { get; set; }

        public System.Data.Entity.DbSet<MOD_17E_PROJETO.Models.Servico> Servicoes { get; set; }
    }
}
