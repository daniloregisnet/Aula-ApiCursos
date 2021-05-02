using ApiCursos.Model;
using System.Collections.Generic;

namespace ApiCursos.Services
{
    public interface ITurmaService
    {
        IEnumerable<Turma> RetornarTodasTurmas();
        Turma RetornarTurmaPorId(int idTurma);
    }
}