using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;

namespace Olímpicos.Controllers
{
    public class ResultadosController : Controller
    {

        private readonly Database db = new Database();

        public IActionResult Criar()
        {
            ViewBag.Atletas = GetAtletas();
            ViewBag.Provas = GetProvas().Select(p => new
            {
                p.CodProva,
                NomeProva = $"[{p.NomeModalidade}] {p.NomeProva}"
            }).ToList();

            ViewBag.Edicoes = GetEdicoes().Select(e => new
            {
                Codedicao = e.Codedicao,
                Ano = $"{e.Ano} - {e.Sede}"
            }).ToList();

            ViewBag.Medalhas = new List<string> { "Nenhuma", "Ouro", "Prata", "Bronze" };

            return View();
        }

        [HttpPost]
        public IActionResult Criar([FromForm]Resultados resultados)
        {
            System.Diagnostics.Debug.WriteLine(resultados.CodAtleta);
            System.Diagnostics.Debug.WriteLine(resultados.CodProva);
            System.Diagnostics.Debug.WriteLine(resultados.Edicao);

            using (var conn = db.GetConnection())
            {
                var sql = @"insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
                                values (@cod_atleta, @cod_prova, @edicao, @resultado, @medalha)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod_atleta", resultados.CodAtleta);
                cmd.Parameters.AddWithValue("@cod_prova", resultados.CodProva);
                cmd.Parameters.AddWithValue("@edicao", resultados.Edicao);
                cmd.Parameters.AddWithValue("@resultado", resultados.Resultado);
                cmd.Parameters.AddWithValue("@medalha", resultados.Medalha);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Home");
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
        private List<Provas> GetProvas()
        {
            List<Provas> provas = new List<Provas>();
            using (var conn = db.GetConnection())
            {
                var sql = """
                    select distinct p.cod_prova, p.nome_prova, m.nome_modalidade FROM provas p
                    inner join modalidades m on m.cod_modalidade = p.cod_modalidade
                    order by p.nome_prova
                    """;

                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    provas.Add(new Provas
                    {
                        CodProva = reader.GetInt32("cod_prova"),
                        NomeProva = reader.GetString("nome_prova"),
                        NomeModalidade = reader.GetString("nome_modalidade"),
                    });
                }
            }

            return provas;
        }

        private List<Edicao> GetEdicoes()
        {
            List<Edicao> edicoes = new List<Edicao>();
            using (var conn = db.GetConnection())
            {
                var sql = "SELECT Distinct * FROM edicao order by ano";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    edicoes.Add(new Edicao
                    {
                        Codedicao = reader.GetInt32("cod_edicao"),
                        Ano = reader.GetInt32("ano"),
                        Sede = reader.GetString("sede"),
                    });
                }
            }

            return edicoes;
        }
    }
}
