using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCursos.Model
{
    public class Turma
    {
        public Turma(int id)
        {
            Id = id;
            Alunos = new List<Aluno>();
        }

        public int Id { get; private set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; private set; }
    }
}
