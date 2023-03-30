using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOD17AB_Projeto.Models
{
    public class Servicos
    {
        BaseDados bd;

        public Servicos() { bd = new BaseDados(); }
        //Add materiais
        public int add(int idutilizador,string tema, string descricao, DateTime datainicio)
        {
            string sql = @"INSERT INTO marcacoes(idutilizador,tema,descricao,estado,data_inicio)
                    VALUES (@idutilizador,@tema,@descricao,@estado,@data_inicio);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@idutilizador",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = idutilizador
                },
                new SqlParameter()
                {
                    ParameterName = "@tema",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = tema
                },
                new SqlParameter()
                {
                    ParameterName = "@descricao",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = descricao
                },
                new SqlParameter()
                {
                    ParameterName = "@estado",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = 0
                },
                
                new SqlParameter()
                {
                    ParameterName = "@data_inicio",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = datainicio
                },
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal object ServicosCriados(int idutilizador)
        {
            string sql = @"SELECT nMarcacao ,idutilizador,tema,estado,data_inicio 
                        FROM marcacoes Where idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador }
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal object ServicosAceitesporx(int idutilizador)
        {
            string sql = @"SELECT nMarcacao ,idutilizador,tema,estado,idaceita,data_inicio 
                        FROM marcacoes Where idaceita=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador }
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal object listaAnunciosDisponiveis()
        {
            string sql = @"SELECT nMarcacao,idutilizador,tema,descricao,data_inicio,
                    case
                        when estado=0 then 'Disponivel'
                        when estado=1 then 'Aceite'
                        when estado=2 then 'Terminado'
                    end as estado
                    FROM marcacoes";
            return bd.devolveSQL(sql);
        }

        internal void terminado(int idMarcacao, int idutilizador)
        {
            string sql = "SELECT * FROM marcacoes WHERE nMarcacao=@idMarcacao";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idMarcacao",SqlDbType=SqlDbType.Int,Value=idMarcacao }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //testar se o serviço ainda está disponível
                if (dados.Rows[0]["estado"].ToString() != "1")
                    throw new Exception("Servico ainda não foi aceite ou já foi terminado");

                sql = "UPDATE marcacoes SET estado=@estado WHERE nMarcacao=@idMarcacao";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idMarcacao",SqlDbType=SqlDbType.Int,Value=idMarcacao },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=2 },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);

                sql = @"UPDATE marcacoes SET idaceita=@idutilizador,estado=@estado where nMarcacao = @idMarcacao";

                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idMarcacao",SqlDbType=SqlDbType.Int,Value=idMarcacao },
                    new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=2 },
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

        internal void aceitar(int idMarcacao, int idutilizador)
        {
            string sql = "SELECT * FROM marcacoes WHERE nMarcacao=@idMarcacao";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idMarcacao",SqlDbType=SqlDbType.Int,Value=idMarcacao }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //testar se o serviço ainda está disponível
                if (dados.Rows[0]["estado"].ToString() != "0")
                    throw new Exception("Servico não está disponível");
                
                sql = "UPDATE marcacoes SET estado=@estado WHERE nMarcacao=@idMarcacao";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idMarcacao",SqlDbType=SqlDbType.Int,Value=idMarcacao },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);

                sql = @"UPDATE marcacoes SET idaceita=@idutilizador,estado=@estado where nMarcacao = @idMarcacao";

                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idMarcacao",SqlDbType=SqlDbType.Int,Value=idMarcacao },
                    new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
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
        internal object listaAnunciosPorAceitar()
        {
            string sql = @"SELECT nMarcacao,idutilizador,idaceita,tema,descricao,data_inicio 
                        FROM marcacoes where estado=0";
            return bd.devolveSQL(sql);
        }
        internal object listaAnunciosAceites()
        {
            string sql = @"SELECT nMarcacao,idutilizador,idaceita,tema,descricao,data_inicio 
                        FROM marcacoes where estado=1";
            return bd.devolveSQL(sql);
        }
         internal object listaAnunciosTerminados()
        {
            string sql = @"SELECT nMarcacao,idutilizador,idaceita,tema,descricao,data_inicio 
                        FROM marcacoes where estado=2";
            return bd.devolveSQL(sql);
        }
    }
}