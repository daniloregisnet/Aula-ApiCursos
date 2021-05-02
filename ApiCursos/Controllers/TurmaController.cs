using ApiCursos.Model;
using ApiCursos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        readonly ITurmaService service;
        
        public TurmaController(ITurmaService turmaService)
        {
            service = turmaService;
        }
        /// <summary>
        /// Este método retorna uma lista de turmas com seus respectivos aluno
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Turma> GetTurmas()
        {
            return service.RetornarTodasTurmas();
        }

        [HttpGet]
        [Route("{idTurma}")]
        public Turma GetTurma([FromRoute] int idTurma)
        {            
            return service.RetornarTurmaPorId(idTurma);
        }

        [HttpPost]
        public ActionResult InserirTurma(Turma turma)
        {
            //
            return Ok();
        }

        [HttpPost]
        [Route("aluno")]
        public ActionResult InserirAluno([FromBody] Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                return BadRequest("Nome não informado.");
            //
            
            return Ok();
        }

        [HttpPut]
        [Route("aluno")]
        public ActionResult AtualizarAluno([FromBody] Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                return BadRequest("Nome não informado.");

            if (aluno.Id == 0)
                return BadRequest("ID não informado.");
            //

            return Ok();
        }

        [HttpDelete]
        [Route("aluno")]
        public ActionResult ExcluirAluno([FromBody] Aluno aluno)
        {
            if (aluno.Id == 0)
                return BadRequest("ID não informado.");
            //

            return Ok();
        }


      
    }
}
