using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOD17AB_Projeto.Models
{
    public class Material
    {
        public int nMaterial;
        public string nome;
        public DateTime data_aquisicao;
        public decimal preco;
        public string marca;
        public int quantidade;

        BaseDados bd;

        public Material() { bd = new BaseDados(); }
        //Add materiais
        public int Add()
        {
            string sql = @"INSERT INTO material(nome,data_aquisicao,preco,marca,quantidade)
                    VALUES (@nome,@data_aquisicao,@preco,@marca,@quantidade);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.nome
                },
                new SqlParameter()
                {
                    ParameterName = "@data_aquisicao",
                    SqlDbType = System.Data.SqlDbType.Date,
                    Value = this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName = "@preco",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = this.preco
                },
                new SqlParameter()
                {
                    ParameterName = "@marca",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.marca
                },
                new SqlParameter()
                {
                    ParameterName = "@quantidade",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.quantidade
                },
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }
        //admin list view materiais
        internal DataTable ListaTodosMateriais()
        {
            string sql = @"SELECT nMaterial as ID,nome as Nome,data_aquisicao as Data,preco as Preço,marca as Marca,quantidade as Quantidade,
                    case
                        when quantidade=0 then 'Sem stock'
                        when quantidade>=1 then 'Em stock'
                        
                    end as quantidades
                    FROM material";
            return bd.devolveSQL(sql);
        }
        //Devolver info Materiais
        public DataTable DadosMaterial(int nMaterial)
        {
            string sql = "SELECT * FROM Material WHERE nMaterial=@nMaterial";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nMaterial",SqlDbType=SqlDbType.Int,Value=nMaterial }
            };
            return bd.devolveSQL(sql, parametros);
        }
        //Remove Material Admin
        public void Remove(int nMaterial)
        {
            string sql = "DELETE FROM Material WHERE nMaterial=@nMaterial";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nMaterial",SqlDbType=SqlDbType.Int,Value=nMaterial }
            };
            bd.executaSQL(sql, parametros);
        }
        //Editar/Update Material Admin
        public void atualizaMaterial()
        {
            string sql = "UPDATE Material SET nome=@nome,data_aquisicao=@data,preco=@preco,marca=@marca,quantidade=@quantidade";
            sql += " WHERE nMaterial=@nMaterial;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@data",SqlDbType=SqlDbType.DateTime,Value= data_aquisicao},
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value= preco},
                new SqlParameter() {ParameterName="@marca",SqlDbType=SqlDbType.VarChar,Value=marca},
                new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.VarChar,Value=quantidade},
                new SqlParameter() {ParameterName="@nMaterial",SqlDbType=SqlDbType.Int,Value=nMaterial}
            };
            bd.executaSQL(sql, parametros);
        }
        //Mostra material em stock
        public DataTable MaterialDisponiveis(int? ordena = null)
        {
            string sql = "SELECT * FROM Material WHERE quantidade!=0";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by marca";
            }
            return bd.devolveSQL(sql);
        }
        //Mostra material da marca 
        internal DataTable MaterialMarca(string pesquisa)
        {
            string sql = "SELECT * FROM material WHERE quantidade != 0 and marca like @nome";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
        //Mostra material com pesquisa
        internal DataTable MateriaisDisponiveisComPesquisa(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM material WHERE quantidade!=0 and nome like @nome";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by marca";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
       

    }
}