using estacionamento.Models;
using estacionamento.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace estacionamento.Controllers
{
    [Route("/valores")]
    public class ValorDominutoController : Controller
    {
        private readonly IRepositorio<ValorDoMinuto> _repositorio;

        public ValorDominutoController(IRepositorio<ValorDoMinuto> repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            var valores = _repositorio.ObterTodos();
            return View(valores);
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost("Criar")]
        public IActionResult Criar([FromForm] ValorDoMinuto valorDoMinuto)
        {
            // Verificar se o modelo é válido
            if (ModelState.IsValid)
            {
                _repositorio.Inserir(valorDoMinuto);
                // Redirecionar para uma página de sucesso ou outra ação
                return RedirectToAction("Index"); // Ajuste conforme sua necessidade    
            }
            // Caso haja erro de validação no modelo
            return View(valorDoMinuto);
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
        public IActionResult Alterar([FromRoute] int id, [FromForm] ValorDoMinuto valorDoMinuto)
        {
            valorDoMinuto.Id = id;
            _repositorio.Atualizar(valorDoMinuto);

            return Redirect("/valores");
        }
    }
}