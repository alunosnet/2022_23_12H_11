using MOD_17E_PROJETO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOD_17E_PROJETO.Helper
{
    public static class Helper
    {
        public static string UserId(this HtmlHelper htmlHelper, System.Security.Principal.IPrincipal utilizador)
        {
            string iduser = "";

            using (var context = new MOD_17E_PROJETOContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT IdTecnico FROM Tecnicoes WHERE Nome = @p0",
                    utilizador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }
            return iduser;

        }
    }
}