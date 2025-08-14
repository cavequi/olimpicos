using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;

namespace Olímpicos.Controllers
{
    public class EstadosPaisesController : Controller
    {

        private readonly Database db = new Database();

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(EstadosPaises estadoPais)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"INSERT INTO estados (nome_estado)
                     VALUES (@nome_estado)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome_estado", estadoPais.NomeEstado);
                
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Home");
        }


    }
}

