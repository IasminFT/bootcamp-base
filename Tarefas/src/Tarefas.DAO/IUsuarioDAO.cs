using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;
using System.Collections.Generic;


namespace Tarefas.DAO
{
    public interface IUsuarioDAO
    {
        SQLiteConnection Connection { get; }

        TarefaDTO Consultar(int id);
        void Criar(UsuarioDTO usuario);
    }

}

 