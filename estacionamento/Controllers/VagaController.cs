using estacionamento.Models;
using estacionamento.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace estacionamento.Controllers
{
    [Route("/vaga")]
    public class VagaController : Controller
    {
        private readonly IRepositorio<Vaga> _repositorio;

        public VagaController(IRepositorio<Vaga> repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            var vagas = _repositorio.ObterTodos();
            return View(vagas);
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost("Criar")]
        public IActionResult Criar([FromForm] Vaga vaga)
        {
            // Verificar se o modelo é válido
            if (ModelState.IsValid)
            {
                _repositorio.Inserir(vaga);
                // Redirecionar para uma página de sucesso ou outra ação
                return RedirectToAction("Index"); // Ajuste conforme sua necessidade    
            }
            // Caso haja erro de validação no modelo
            return View("novo");
        }


        [HttpPost("{id}/apagar")]
        public IActionResult Apagar([FromRoute] int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/editar")]
        public IActionResult Editar([FromRoute] int id)
        {
            var sql = _repositorio.ObterPorId(id);
            return View(sql);
        }

        [HttpPost("{id}/alterar")]
        public IActionResult Alterar([FromRoute] int id, [FromForm] Vaga vaga)
        {
            vaga.Id = id;
            _repositorio.Atualizar(vaga);

            return Redirect("/valores");
        }
    }
}