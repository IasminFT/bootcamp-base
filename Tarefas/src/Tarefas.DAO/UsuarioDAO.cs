using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;
using System.Collections.Generic;


namespace Tarefas.DAO
{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {
        public string Email {get; set;}
        public string Senha {get; set;}
        public string Nome {get; set;}
        public bool Ativo {get; set;}

        public UsuarioDAO()
        {
            
        }

        public UsuarioDTO Consultar(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                UsuarioDTO result = con.Query<UsuarioDTO>
                (
                    @"SELECT, Email, Senha, Nome, Ativo FROM Usuario
                    WHERE Id = @Id", new { id }
                ).FirstOrDefault();
                return result;
            }
        }

        private void CreateDatabase()
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"CREATE TABLE Tarefa
                    (
                        Id          integer primary key autoincrement,
                        Email       varchar(100) not null,
                        Senha       varchar(100) not null,
                        Ativo       bool not null
                    )"
                );
            }
        }

        public void Criar(UsuarioDTO usuario)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Usuario
                    (Email, Senha, Nome, Ativo) VALUES
                    (@Email, @Senha, @Nome, @Ativo);", usuario
                );
            }
        }
    }
}
       