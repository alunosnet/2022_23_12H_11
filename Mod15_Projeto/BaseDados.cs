using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod15_Projeto
{
    public class BaseDados
    {
        string Ligabd;
        SqlConnection sqlConnection;
        string NomeBD;
        string caminhoBD;

        /*CONSTRUTOR*/
        public BaseDados(string NomeBD)
        {
            //VAI BUSCAR A CONNECTION STRINGS AO APPCONFIG E ASSIM FAZ LIGACAO A BASEDADOS
            Ligabd = ConfigurationManager.ConnectionStrings["servidor"].ToString();
            this.NomeBD = NomeBD;
            //CAMINHO PARA A BASE DADOS
            string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //CRIAR PASTA PARA O FICHEIRO DA BD FICAR LA DENTRO
            caminhoBD += "\\M15_Projeto\\";
            this.caminhoBD = caminhoBD + "\\" + NomeBD + ".mdf";
            //VERIFICA SE TEM ALGUMA BASE DADOS NESTE CAMINHO
            if (System.IO.Directory.Exists(caminhoBD) == false)
            {
                System.IO.Directory.CreateDirectory(caminhoBD);
            }
            //SENAO EXISTIR CRIA UMA
            if (System.IO.File.Exists(this.caminhoBD) == false)
            {
                CriarBD();
            }

            //LIGAÇÃO A BD
            sqlConnection = new SqlConnection(Ligabd);
            sqlConnection.Open();
            sqlConnection.ChangeDatabase(NomeBD);
        }

        /*DESTRUTOR*/
        ~BaseDados()
        {
            try
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch
            {
                //PODE OCORRER ERROS
            }

        }

        private void CriarBD()
        {
            //ligar ao servidor BD
            sqlConnection = new SqlConnection(Ligabd);
            sqlConnection.Open();

            //Criar BD
            string sql = $"CREATE DATABASE {NomeBD} ON PRIMARY (NAME = {NomeBD} , FILENAME= '{caminhoBD}')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.ChangeDatabase(NomeBD);


            //Criar tabelas
            sql = @"CREATE TABLE Computador(
                    Computadorid INT IDENTITY PRIMARY KEY,
                    Marca VARCHAR(15) not null CHECK (LEN(Marca)>3),
                    cpu VARCHAR(25) not null CHECK (LEN(cpu)>4 AND CHARINDEX(' ',cpu) > 0),
                    gpu VARCHAR(25) not null CHECK (LEN(gpu)>5),
                    Ram VARCHAR(3) not null CHECK (Ram Like '__G'),
                    SO Varchar(12) not null check (SO like 'Windows%' or SO like 'MacOS'),    
                    Preco Money not null Check(Preco > 0),
                    Stock INT,
                    );

                    CREATE TABLE Cliente(
                    ClienteID VARCHAR(5) NOT NULL CHECK (ClienteID LIKE 'C%') PRIMARY KEY,
                    Nome VARCHAR(100) NOT NULL CHECK (LEN(Nome)>4 AND CHARINDEX(' ',Nome) > 0),
                    NIF VARCHAR(9) UNIQUE CHECK (LEN(NIF)=9),
                    Email VARCHAR(100) UNIQUE CHECK (Email like '%@%.%'),
                    CP VARCHAR(8) not null CHECK (CP LIKE '____-___'),
                    DataNasc date not null CHECK (DATEDIFF(YEAR , DataNasc, GETDATE())>=16),
                    Idade int CHECK (Idade>=16),
                    DataRegisto DATE not null DEFAULT(GETDATE())
                    );

                    CREATE TABLE Vendas(
                    VendaID INT IDENTITY PRIMARY KEY,
                    Clienteid VARCHAR(5) REFERENCES Cliente(Clienteid),
                    Computadorid INT REFERENCES Computador(Computadorid),
                    Garantia BIT not null default(0),
                    DiaVenda Date Default GETDATE(),
                    Funciona bit not null default(1),
                    Computador_Preco Money not null check(Computador_Preco > 0),
                    Total money not null,   
                    );

                    CREATE TABLE Reparacao(
                    ReparacaoID INT IDENTITY PRIMARY KEY,
                    VendaID INT REFERENCES Vendas(VendaID),
                    Clienteid VARCHAR(5) REFERENCES Cliente(ClienteID),
                    Computadorid INT REFERENCES Computador(Computadorid),
                    Motivo varchar(100) not null check(len(Motivo)>10),
                    Comentario varchar(Max) not null check(len(comentario)>10),  
                    DataParaResolver date not null default(GETDATE()),
                    DataResolvido date  ,
                    Resolvido bit not null ,    
                    )";
            
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            //CRIAR TRIGGERS
            sql = @"CREATE TRIGGER CalcularIdade
                    ON Cliente
                    AFTER  INSERT AS
                    BEGIN
                        DECLARE @DataNasc DATE;
                        DECLARE @Idade INT;
                        DECLARE @Clienteid VARCHAR(5);
                        SELECT @Clienteid = INSERTED.Clienteid FROM INSERTED;
                        SELECT @DataNasc = INSERTED.DataNasc FROM INSERTED;
                        SET @Idade = DATEDIFF(YEAR,@DataNasc,GETDATE());
                        UPDATE Cliente
                        SET Idade=@Idade
                        WHERE Cliente.Clienteid = @Clienteid
                    END
                    ";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sql = @"CREATE TRIGGER CalcularIdadeAtualizada
                    ON Cliente
                    AFTER UPDATE AS
                    BEGIN    
                        DECLARE @DataNasc DATE;
                        DECLARE @Idade INT;
                        DECLARE @Clienteid VARCHAR(5);
                        SELECT @Clienteid = INSERTED.Clienteid  FROM INSERTED;
                        SELECT @DataNasc = INSERTED.DataNasc FROM INSERTED;
                        SET @Idade = DATEDIFF(YEAR,@DataNasc,GETDATE());
                        UPDATE Cliente
                        SET Idade=@Idade
                        WHERE Cliente.Clienteid = @Clienteid
                    END";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            
            sql = @"CREATE TRIGGER AtualizarStock
                    ON Vendas
                    AFTER UPDATE AS
                    BEGIN
                        DECLARE @Computadorid INT;
                        SELECT @Computadorid = INSERTED.Computadorid FROM INSERTED;
                        UPDATE Computador
                        SET Stock = Stock - 1
                        WHERE Computador.Computadorid = @Computadorid
                    END";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            //Fechar a ligação ao servidor BD
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();

        }

        /// <summary>
        /// VAI EXECUTAR UM SQL Q ALTERA DADOS (INSERT / DELETE / UPDATE)
        /// </summary>
        public void ExecutaSQL(string sql, List<SqlParameter> parametros = null)
        {
            //TODO: ADD TRANSAÇÕES
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            comando.ExecuteNonQuery();
            //Fechar sempre dps de executar um comando
            comando.Dispose();
            comando = null;
        }
        /// <summary>
        /// EXECUTA A CONSULTA E DEVOLVE OS DADOS DA BD
        /// </summary>
        /// <returns> UM DATATABLE DEVOLVE COM O RESULTADO DA CONSULTA</returns>
        public DataTable DevolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            DataTable dados = new DataTable();
            SqlDataReader registos = comando.ExecuteReader();
            dados.Load(registos);
            registos.Close();
            comando.Dispose();
            registos = null;
            comando = null;
            return dados;
        }
    }
}
