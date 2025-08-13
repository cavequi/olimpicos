using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;

namespace Olímpicos.Controllers
{
    public class ResultadoController : Controller
    {

        private readonly Database db = new Database();

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Resultados resultado)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
                            values (@cod_atleta, @cod_prova, @edicao, @resultado, @medalha)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod_atleta", resultado.CodAtleta);
                cmd.Parameters.AddWithValue("@cod_prova", resultado.CodProva);
                cmd.Parameters.AddWithValue("@edicao", resultado.Edicao);
                cmd.Parameters.AddWithValue("@resultado", resultado.Resultado);
                cmd.Parameters.AddWithValue("@", resultado.Medalha);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


        private List<Atletas> GetAtletas()
        {
            List<Atletas> atletas = new List<Atletas>();
            using (var conn = db.GetConnection())
            {
                var sql = "SELECT Distinct * FROM atletas order by nome_atleta";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    atletas.Add(new Atletas
                    {
                        CodAtleta = reader.GetInt32("cod_atleta"),
                        NomeAtleta = reader.GetString("nome_atleta"),
                    });
                }
            }

            return atletas;
        }
        private List<Atletas> Getprovas()
        {
            List<Provas> provas = new List<Provas>();
            using (var conn = db.GetConnection())
            {
                var sql = "SELECT Distinct p.cod_prova, p.nome_prova, m.nome_modalidade FROM provas p" +
                    "inner join modalidades m on m.cod_modalidade = p.cod_modalidade" +
                    "order by nome_prova;";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    provas.Add(new Provas
                    {
                        CodProva = reader.GetInt32("p.cod_prova"),
                        NomeProva = reader.GetString("p.nome_prova"),
                        NomeModalidade = reader.GetString("p.nome_modalidade"),
                    });
                }
            }

            return provas;
        }
    }
}
