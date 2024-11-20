using System.Data;
using Dapper;
using estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace estacionamento.Controllers
{
    [Route("/valores")]
    public class ValorDominutoController : Controller
    {
        private readonly IDbConnection _connection;

        public ValorDominutoController(IDbConnection connection)
        {
            _connection = connection;
        }

        public IActionResult Index()
        {
            var valores = _connection.Query<ValorDoMinuto>("Select * from valores");
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
                // Definir o comando SQL para inserir os dados
                string query = "INSERT INTO valores (Minutos, Valor) VALUES (@Minutos, @Valor)";

                // Executar o comando SQL com os parâmetros do objeto valorDoMinuto
                var result = _connection.Execute(query, new { Minutos = valorDoMinuto.Minutos, Valor = valorDoMinuto.Valor });

                // Se a inserção foi bem-sucedida, redirecionar para outra página ou exibir mensagem de sucesso
                if (result > 0)
                {
                    // Redirecionar para uma página de sucesso ou outra ação
                    return RedirectToAction("Index"); // Ajuste conforme sua necessidade
                }
                else
                {
                    // Se não conseguiu inserir, exibir erro
                    ModelState.AddModelError("", "Erro ao tentar salvar os dados.");
                }

            }
            // Caso haja erro de validação no modelo
            return View(valorDoMinuto);
        }


        [HttpPost("{id}/apagar")]
        public IActionResult Apagar([FromRoute] int id)
        {
            var sql = "Delete from valores where id=@Id";
            _connection.Execute(sql, new ValorDoMinuto{ Id = id });
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/editar")]
        public IActionResult Editar([FromRoute] int id)
        {
            var sql = _connection.Query<ValorDoMinuto>("Select * from valores where Id = @id", new ValorDoMinuto{Id = id}).FirstOrDefault();
            return View(sql);
            
        }

        [HttpPost("{id}/alterar")]
        public IActionResult Alterar([FromRoute] int id, [FromForm] ValorDoMinuto valorDoMinuto)
        {
            valorDoMinuto.Id = id;
            var sql = "UPDATE valores SET Minutos=@Minutos, Valor=@Valor where Id = @id";
            _connection.Execute(sql,valorDoMinuto);

            return Redirect("/valores");
        }
    }
}