using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod15_Projeto.Computadores
{
    public class Computador
    {
		public int Computadorid { get; set; }
		public string Marca { get; set; }
		public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Ram { get; set; }
        public string SO { get; set; }
        public decimal Preco { get; set; }
        public int Stock { get; set; }

        public Computador(int computadorid, string marca, string cpu, string gpu, string ram, string sO, decimal preco, int stock)
        {
            Computadorid = computadorid;
            Marca = marca;
            Cpu = cpu;
            Gpu = gpu;
            Ram = ram;
            SO = sO;
            Preco = preco;
            Stock = stock;
        }

        public static DataTable ListarDisponiveis(BaseDados bd)
        {
            string sql = " SELECT * FROM Computador WHERE Stock > 0";
            return bd.DevolveSQL(sql);
        }

        public Computador()
        {
        }
        //Adicionar novo computador
        public void Adicionar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"insert into Computador(Marca,Cpu,Gpu,Ram,SO,Preco,Stock)
                            values 
                            (@Marca,@Cpu,@Gpu,@Ram,@SO,@Preco,@Stock)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@Marca",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Marca,
                },
                new SqlParameter()
                {
                    ParameterName="@Cpu",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Cpu,
                },
                new SqlParameter()
                {
                    ParameterName="@Gpu",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Gpu,
                },
                new SqlParameter()
                {
                    ParameterName="@Ram",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Ram,
                },
                new SqlParameter()
                {
                    ParameterName="@SO",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.SO,
                },
                new SqlParameter()
                {
                    ParameterName="@Preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Preco,
                },
                new SqlParameter()
                {
                    ParameterName = "@Stock",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value=this.Stock,
                },

            };
            //executar
            bd.ExecutaSQL(sql, parametros);
            
            //bd.ExecutaSQL(sql);
        }
        //Apagar na bd
        public static void Apagar(BaseDados bd, int nComputador_escolhido)
        {
            string sql = "DELETE FROM Computador WHERE Computadorid=" + nComputador_escolhido;
            bd.ExecutaSQL(sql);
        }
        //Atualizar na base de dados
        public void Atualizar(BaseDados bd)
        {
            string sql = "UPDATE Computador " +
                 "SET Marca = @Marca, Cpu = @Cpu, Gpu = @Gpu, Ram = @Ram, SO = @SO, Preco = @Preco, Stock = @Stock " +
                 "WHERE Computadorid = @Computadorid ";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@Marca",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Marca,
                },
                new SqlParameter()
                {
                    ParameterName="@Cpu",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Cpu,
                },
                new SqlParameter()
                {
                    ParameterName="@Gpu",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Gpu,
                },
                new SqlParameter()
                {
                    ParameterName="@Ram",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Ram,
                },
                new SqlParameter()
                {
                    ParameterName="@SO",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.SO,
                },
                new SqlParameter()
                {
                    ParameterName="@Preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Preco,
                },
                new SqlParameter()
                {
                    ParameterName = "@Stock",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value=this.Stock,
                },
                new SqlParameter()
                {
                    ParameterName = "@Computadorid",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value=this.Computadorid,
                },

            };

            bd.ExecutaSQL(sql, parametros);
        }
        //identificar o numero do computador
        public void ProcurarNrComputador(BaseDados bd,int computadorid)
        {
            string sql = "SELECT * FROM Computador WHERE Computadorid=" + computadorid;
            DataTable dados = bd.DevolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.Computadorid = int.Parse(dados.Rows[0]["computadorid"].ToString());
                this.Marca = dados.Rows[0]["marca"].ToString();
                this.Cpu = dados.Rows[0]["cpu"].ToString();
                this.Gpu = dados.Rows[0]["gpu"].ToString();
                this.Ram = dados.Rows[0]["ram"].ToString();
                this.SO = dados.Rows[0]["so"].ToString();
                this.Preco = decimal.Parse(dados.Rows[0]["preco"].ToString());
                this.Stock = int.Parse(dados.Rows[0]["stock"].ToString()); 

            }
        }
        //Listar Computadores
        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * From Computador";
            return bd.DevolveSQL(sql);
        }
        public override string ToString()
        {
            return this.Computadorid.ToString();
        }
    }
}
