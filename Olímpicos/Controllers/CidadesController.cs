using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;

namespace Olímpicos.Controllers
{
    public class CidadesController : Controller
    {
        private readonly Database db = new Database();

        public IActionResult Criar()
        {
            ViewBag.EstadosPaises = GetEstadosPaises(); // Para dropdown
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Cidade cidade)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"INSERT INTO cidades (nome_cidade, cod_estado)
                     VALUES (@nome_cidade, @cod_estado)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome_cidade", cidade.NomeCidade);
                cmd.Parameters.AddWithValue("@cod_estado", cidade.CodEstado);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Home");
        }

        private List<EstadosPaises> GetEstadosPaises()
        {
            List<EstadosPaises> estadosPaises = new List<EstadosPaises>();
            using (var conn = db.GetConnection())
            {
                var sql = "SELECT Distinct * FROM estados order by nome_estado";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    estadosPaises.Add(new EstadosPaises                    {
                        CodEstado = reader.GetInt32("cod_estado"),
                        NomeEstado = reader.GetString("nome_estado"),
                    });
                }
            }

            return estadosPaises;
        }

    }
}
