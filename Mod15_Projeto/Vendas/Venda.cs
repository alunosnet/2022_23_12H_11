using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod15_Projeto.Vendas
{
    public class Venda
    {
        public int VendaID { get; set; }    
        public string ClienteID { get; set; }
        public int Computadorid { get; set; }
        public bool Garantia{ get; set; }
        public DateTime DataVenda { get; set; }
        public bool Funciona { get; set; }
        public decimal Computador_Preco { get; set; }
        public decimal Total { get; set; }

        public Venda(string clienteID, int computadorid, decimal computador_Preco)
        {
            ClienteID = clienteID;
            Computadorid = computadorid;
            Computador_Preco = computador_Preco;
        }
        public Venda() { }
        public void Adicionar(BaseDados bd)
        {
            string sql = $@"insert into Vendas(Clienteid,Computadorid,Garantia,Funciona,Computador_Preco,Total)
                            values 
                            (@Clienteid,@Computadorid,@Garantia,@Funciona,@Computador_Preco,@Total)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@Clienteid",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.ClienteID,
                },
                new SqlParameter()
                {
                    ParameterName="@Computadorid",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Computadorid,
                },
                new SqlParameter()
                {
                    ParameterName="@Garantia",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.Garantia,
                },
                new SqlParameter()
                {
                    ParameterName="@Funciona",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.Funciona,
                },
                new SqlParameter()
                {
                    ParameterName="@Computador_Preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Computador_Preco,
                },
                new SqlParameter()
                {
                    ParameterName="@Total",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Total,
                },

            };
            //executar
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Vendas";
            return bd.DevolveSQL(sql);
        }

        public static void Apagar(BaseDados bd, int n_venda_escolhida)
        {
            string sql = "DELETE FROM Vendas WHERE VendaID =" + n_venda_escolhida;
            bd.ExecutaSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = "UPDATE Vendas " +
                 "SET Clienteid = @clienteid, Computadorid = @Computadorid,Garantia = @Garantia,Funciona= @Funciona,Computador_Preco=@Computador_Preco,Total = @Total " +
                 "WHERE VendaID = @VendaID ";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@Clienteid",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.ClienteID,
                },
                new SqlParameter()
                {
                    ParameterName="@Computadorid",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Computadorid,
                },
                new SqlParameter()
                {
                    ParameterName="@Garantia",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.Garantia,
                },
                new SqlParameter()
                {
                    ParameterName="@Funciona",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.Funciona,
                },
                new SqlParameter()
                {
                    ParameterName="@Computador_Preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Computador_Preco,
                },
                new SqlParameter()
                {
                    ParameterName="@Total",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Total,
                },
                new SqlParameter()
                {
                    ParameterName="@VendaID",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.VendaID,
                },
            };

            bd.ExecutaSQL(sql, parametros);
        }

        public void ProcurarNrVenda(BaseDados bd, int vendaID)
        {
            string sql = "SELECT * FROM Vendas WHERE VendaID=" + vendaID;
            DataTable dados = bd.DevolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.VendaID = int.Parse(dados.Rows[0]["VendaID"].ToString());
                this.Computadorid = int.Parse(dados.Rows[0]["Computadorid"].ToString());
                this.ClienteID = dados.Rows[0]["Clienteid"].ToString();
                this.Garantia = bool.Parse(dados.Rows[0]["Garantia"].ToString());
                this.Funciona = bool.Parse(dados.Rows[0]["Funciona"].ToString());
                this.Computador_Preco = decimal.Parse(dados.Rows[0]["Computador_Preco"].ToString());
                this.Total = decimal.Parse(dados.Rows[0]["Total"].ToString());

            }
        }

        public static void Compor(BaseDados bd, int n_venda_escolhida)
        {
            bool funciona = false;
            string sql = "UPDATE Vendas SET Funciona = @Funciona"+
                " WHERE VendaID = " + n_venda_escolhida;
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                 new SqlParameter()
                {
                    ParameterName="@Funciona",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value= funciona,
                },
            };
            bd.ExecutaSQL(sql,parametros);

        }
    }
}
