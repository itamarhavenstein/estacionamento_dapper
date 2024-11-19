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
    }
}