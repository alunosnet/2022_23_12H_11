using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOD17AB_Projeto.Models
{
    public class Vendas
    {
        BaseDados bd;

        public Vendas()
        {
            this.bd = new BaseDados();
        }

        public void AddVenda(int nMaterial, int id, int quantidadeComprar,decimal preco)
        {
            string sql = "SELECT * FROM material WHERE nMaterial=@nMaterial";   
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nMaterial",SqlDbType=SqlDbType.Int,Value=nMaterial }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);
            try
            {
                //verificar disponibilidade do material
                if (int.Parse(dados.Rows[0]["quantidade"].ToString()) < quantidadeComprar)
                    throw new Exception("Material não está disponível");
                //alterar quantidade de materiais
                sql = "UPDATE material SET quantidade=quantidade-@quantidade WHERE nMaterial=@nMaterial";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nMaterial",SqlDbType=SqlDbType.Int,Value=nMaterial },
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Int,Value=quantidadeComprar },
                    
                };

                bd.executaSQL(sql, parametrosUpdate, transacao);
                sql = @"INSERT INTO vendas(idMaterial,idutilizador,preco,quantidade,datavenda) 
                            VALUES (@nMaterial,@id,@preco,@quantidade,@datavenda)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nMaterial",SqlDbType=SqlDbType.Int,Value=nMaterial },
                    new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
                    new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value=preco*quantidadeComprar },
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Int,Value=quantidadeComprar }, 
                    new SqlParameter() {ParameterName="@datavenda",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},

                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();

        }
        public DataTable listaVendasComNomes(int id)
        {
            string sql = @"SELECT nVenda as NVenda,material.nome as NomeMaterial,vendas.quantidade as QuantidadeComprada,utilizadores.nome as NomeUser,datavenda as DataCompra
                        FROM vendas inner join material on vendas.idMaterial=material.nMaterial
                        inner join utilizadores on vendas.idutilizador=utilizadores.id Where idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=id }
            };
            return bd.devolveSQL(sql, parametros);
        }
    }
}