using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;

namespace Olímpicos.Controllers
{
    public class ModalidadesController : Controller
    {

        private readonly Database db = new Database();

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Modalidades modalidade)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"INSERT INTO modalidades (nome_modalidade)
                     VALUES (@nome_modalidade)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome_modalidade", modalidade.NomeModalidade);
               
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Home");
        }

       
    }
}
