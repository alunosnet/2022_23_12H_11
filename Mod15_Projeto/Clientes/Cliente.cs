using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod15_Projeto.Clientes
{
    public class Cliente
    {
        public string ClienteID { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public string CP { get; set; }
        public DateTime DataNasc { get; set; }
        public int Idade { get; set; }
        public DateTime DataRegisto { get; set; }

        public Cliente(string clienteID, string nome, string nIF, string email, string cP, DateTime dataNasc, int idade, DateTime dataRegisto)
        {
            ClienteID = clienteID;
            Nome = nome;
            NIF = nIF;
            Email = email;
            CP = cP;
            DataNasc = dataNasc;
            Idade = idade;
            DataRegisto = dataRegisto;
        }
        public Cliente()
        {

        }


        public static int nultimocliente(BaseDados bd) 
        {
            string sql = "SELECT Top 1 ClienteID From Cliente Order by ClienteID desc";
            DataTable dados = bd.DevolveSQL(sql);
            if (dados == null || dados.Rows.Count == 0)
            {
                return 0;
            }
            string temp = dados.Rows[0]["ClienteID"].ToString();
            temp = temp.Replace("C", "");
            return int.Parse(temp);

        }

        //listar clientes
        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Cliente";
            return bd.DevolveSQL(sql);
        }
        //identificar o n do cliente
        public void ProcurarNrCliente(BaseDados bd, string clienteid)
        {
            string sql = "SELECT * FROM Cliente WHERE ClienteID = @ClienteID";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ClienteID",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value= clienteid,
                },
            };

            DataTable dados = bd.DevolveSQL(sql,parametros);

            if(dados != null && dados.Rows.Count > 0 )
            {
                this.ClienteID = dados.Rows[0]["clienteid"].ToString();
                this.Nome = dados.Rows[0]["nome"].ToString();
                this.NIF = dados.Rows[0]["nif"].ToString();
                this.Email = dados.Rows[0]["email"].ToString(); 
                this.CP = dados.Rows[0]["cp"].ToString() ;
                this.DataNasc = DateTime.Parse(dados.Rows[0]["datanasc"].ToString());
                this.Idade = int.Parse(dados.Rows[0]["idade"].ToString());
                this.DataRegisto = DateTime.Parse(dados.Rows[0]["dataregisto"].ToString());
            }
        }
        //Adicionar na bd
        public void Adicionar(BaseDados bd)
        {
            string sql = $@"insert into Cliente(ClienteID,Nome,NIF,Email,CP,DataNasc)
                            values 
                            (@ClienteID,@Nome,@NIF,@Email,@CP,@DataNasc)";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ClienteID",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.ClienteID,
                },
                new SqlParameter()
                {
                    ParameterName="@Nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome,
                },
                new SqlParameter()
                {
                    ParameterName="@NIF",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NIF,
                },
                new SqlParameter()
                {
                    ParameterName="@Email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Email,
                },
                new SqlParameter()
                {
                    ParameterName="@CP",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.CP,
                },
                new SqlParameter()
                {
                    ParameterName="@Datanasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataNasc,
                },

            };
            //executar
            bd.ExecutaSQL(sql, parametros);
           
        }
        //Apagar na bd
        public static void Apagar(BaseDados bd, string nCliente_Selecionado)
        {
            string sql = "DELETE FROM Cliente WHERE ClienteID=@ClienteID"; 
            List<SqlParameter> parametros = new List<SqlParameter>(){
                new SqlParameter()
                {
                    ParameterName="@ClienteID",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=nCliente_Selecionado,
                }, 
            };
            
            bd.ExecutaSQL(sql,parametros);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = "UPDATE Cliente " +
                 "SET Nome = @Nome, NIF = @NIF, Email = @Email, CP = @CP, DataNasc = @Datanasc " +
                 "WHERE ClienteID = @ClienteID ";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                 new SqlParameter()
                {
                    ParameterName="@Nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome,
                },
                new SqlParameter()
                {
                    ParameterName="@NIF",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NIF,
                },
                new SqlParameter()
                {
                    ParameterName="@Email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Email,
                },
                new SqlParameter()
                {
                    ParameterName="@CP",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.CP,
                },
                new SqlParameter()
                {
                    ParameterName="@Datanasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataNasc,
                },
                new SqlParameter()
                {
                    ParameterName = "@ClienteID",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value= this.ClienteID,

                }
            };

            bd.ExecutaSQL(sql, parametros);
        }
        public override string ToString()
        {
            return this.ClienteID;
        }
    }
}

