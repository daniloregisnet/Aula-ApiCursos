using ApiCursos.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCursos.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly IConfiguration configuration;
        private readonly string connStr;
        private readonly IDbConnection dbConnection;

        public TurmaService(IConfiguration configuration)
        {
            this.configuration = configuration;
            connStr = configuration.GetConnectionString("Default");
            dbConnection = new SqlConnection(connStr);
        }

        public IEnumerable<Turma> RetornarTodasTurmas()
        {
            return dbConnection.Query<Turma>("select Id, Nome from turmas");
        }

        public int InserirTurma(string nome)
        {
            return dbConnection.ExecuteScalar<int>("insert into turma(Nome) values(@nome); select scope_identitiy()", new { nome });
        }

        public int Update(Turma turma)
        {
            return dbConnection.Execute("update turma set nome=@nome where Id = @id", turma);
        }

        public Turma RetornarTurmaPorId(int idTurma)
        {
            return dbConnection.QuerySingle<Turma>($"select Id, Nome from turmas where Id = {idTurma}");
        }

    }
}
