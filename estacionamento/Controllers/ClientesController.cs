using estacionamento.Models;
using estacionamento.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace estacionamento.Controllers
{
    [Route("/clientes")]
    public class ClientesController(IRepositorio<Cliente> repositorio) : Controller
    {
        private readonly IRepositorio<Cliente> _repositorio = repositorio;

        public IActionResult Index()
        {
            var clientes = _repositorio.ObterTodos();
            return View(clientes);
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost("Criar")]
        public IActionResult Criar([FromForm] Cliente cliente)
        {
            
            // Verificar se o modelo é válido
            if (ModelState.IsValid)
            {
                _repositorio.Inserir(cliente);
                // Redirecionar para uma página de sucesso ou outra ação
                return RedirectToAction("Index"); // Ajuste conforme sua necessidade    
            }
            // Caso haja erro de validação no modelo
            return View(cliente);
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
        public IActionResult Alterar([FromRoute] int id, [FromForm] Cliente cliente)
        {
            cliente.Id = id;
            _repositorio.Atualizar(cliente);

            return Redirect("/clientes");
        }
    }
}