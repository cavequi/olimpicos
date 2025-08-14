using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;

namespace Olímpicos.Controllers
{
    public class ProvasController : Controller
    {
        private readonly Database db = new Database();

        public IActionResult Criar()
        {
            ViewBag.Modalidades = GetModalidades(); // Para dropdown
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Provas prova)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"INSERT INTO provas (nome_prova, cod_modalidade)
                     VALUES (@nome_prova, @cod_modalidade)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome_prova", prova.NomeProva);
                cmd.Parameters.AddWithValue("@cod_modalidade", prova.CodModalidade);
               
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Home");
        }

        private List<Modalidades> GetModalidades()
        {
            List<Modalidades> modalidades = new List<Modalidades>();
            using (var conn = db.GetConnection())
            {
                var sql = "SELECT Distinct * FROM modalidades order by nome_modalidade";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    modalidades.Add(new Modalidades
                    {
                        CodModalidade = reader.GetInt32("cod_modalidade"),
                        NomeModalidade = reader.GetString("nome_modalidade"),
                    });
                }
            }

            return modalidades;
        }

    }
}
