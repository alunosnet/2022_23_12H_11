using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOD17AB_Projeto.Models
{
    public class Utilizador
    {
        public int id;
        public string nome;
        public string email;
        public string cp;
        public string nif;
        public string password;
        public int perfil;
        public int sal;
        Random rnd = new Random();
        

        BaseDados bd;

        public Utilizador()
        {
            bd = new BaseDados();
        }

        //adicionar 0-user/1-jardineiro/2-admin
        public void Add()
        {
           
            string sql = @"INSERT INTO utilizadores(email,nome,CP,nif,password,estado,perfil,sal)
                            VALUES (@email,@nome,@CP,@nif,HASHBYTES('SHA2_512',concat(@password,@sal)),@estado,@perfil,@sal)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@CP",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.cp
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=1
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
                 new SqlParameter()
                {
                     //adicionar com o random 
                    ParameterName="@sal",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=rnd.Next(999)
                },
            };
            bd.executaSQL(sql, parametros);
        }
        //Lista users Admin
        internal DataTable ListUsers()
        {
            return bd.devolveSQL("SELECT * FROM Utilizadores");
        }
        //dropbox admin e vendas
        public DataTable listUsersDisponiveis()
        {
            string sql = $@"SELECT id, email,nome, CP, nif, estado, perfil 
            FROM utilizadores where estado=1";
            return bd.devolveSQL(sql);
        }
        //Update User
        public void UpdateUser()
        {
            string sql = @"UPDATE utilizadores SET nome=@nome,CP=@CP,nif=@nif 
                            WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@CP",SqlDbType=SqlDbType.VarChar,Value=cp },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
            };
            bd.executaSQL(sql, parametros);
        }
        //Buscar Dados User
        public DataTable DadosUser(int id)
        {
            string sql = "SELECT * FROM utilizadores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            if (dados.Rows.Count == 0)
            {
                return null;
            }
            return dados;
        }
        //Saber se ta ativo ou bloqueado
        public int EstadoUser(int id)
        {
            string sql = "SELECT estado FROM utilizadores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return int.Parse(dados.Rows[0][0].ToString());
        }
        //on ou off user
        public void OnOffUser(int id)
        {
            int estado = this.EstadoUser(id);
            if (estado == 0) estado = 1;
            else estado = 0;
            string sql = "UPDATE utilizadores SET estado = @estado WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Bit,Value=estado },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            bd.executaSQL(sql, parametros);
        }
        //Remove user
        public void RemoveUser(int id)
        {
            string sql = "DELETE FROM Utilizadores WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= id},
            };
            bd.executaSQL(sql, parametros);
        }
        //Recuperarpass
        public void RecuperarPass(string email, string guid)
        {
            string sql = "UPDATE utilizadores set lnkRecuperar=@lnk WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        //Updatepass
        public void UpdatePass(string guid, string password)
        {
            string sql = "UPDATE utilizadores set password=HASHBYTES('SHA2_512',concat(@password,sal)),estado=1,lnkRecuperar=null WHERE lnkRecuperar=@lnk";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        //Dados com Email
        public DataTable DadosUserMail(string email)
        {
            string sql = "SELECT * FROM utilizadores WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }
    }
}