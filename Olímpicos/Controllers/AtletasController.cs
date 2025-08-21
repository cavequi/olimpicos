using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;

namespace Olímpicos.Controllers
{
    public class AtletasController : Controller
    {

        private readonly Database db = new Database();

        public IActionResult Criar()
        {
            ViewBag.Cidades = GetCidades(); // Para dropdown
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Atletas atleta)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"INSERT INTO atletas (nome_atleta, data_nascimento, sexo, altura, peso, cod_cidade)
                     VALUES (@nome, @data, @sexo, @altura, @peso, @cidade)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", atleta.NomeAtleta);
                cmd.Parameters.AddWithValue("@data", atleta.DataNascimento);
                cmd.Parameters.AddWithValue("@sexo", atleta.Sexo);
                cmd.Parameters.AddWithValue("@altura", atleta.Altura);
                cmd.Parameters.AddWithValue("@peso", atleta.Peso);
                cmd.Parameters.AddWithValue("@cidade", atleta.CodCidade);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET - abre tela de edição
        public IActionResult Editar()
        {
            ViewBag.Atletas = GetAtletas();
            ViewBag.Cidade = GetCidades();
            return View();
        }

        // POST - busca atleta escolhido no select e preenche form
        [HttpPost]
        public IActionResult Buscar(int CodAtleta)
        {
            ViewBag.Atletas = GetAtletas();
            ViewBag.Cidade = GetCidades();

            Atletas atleta = null;

            using (var conn = db.GetConnection())
            {
                var sql = "SELECT * FROM atletas WHERE cod_atleta = @cod";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", CodAtleta);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    atleta = new Atletas
                    {
                        CodAtleta = reader.GetInt32("cod_atleta"),
                        NomeAtleta = reader["nome_atleta"]?.ToString(),
                        DataNascimento = reader["data_nascimento"]?.ToString(),
                        Sexo = reader.IsDBNull(reader.GetOrdinal("sexo"))
                            ? (char?)null
                            : Convert.ToChar(reader["sexo"]),
                        Altura = reader.IsDBNull(reader.GetOrdinal("altura"))
                            ? (decimal?)null
                            : reader.GetDecimal(reader.GetOrdinal("altura")),
                        Peso = reader.IsDBNull(reader.GetOrdinal("peso"))
                            ? (decimal?)null
                            : reader.GetDecimal(reader.GetOrdinal("peso")),
                        CodCidade = reader.IsDBNull(reader.GetOrdinal("cod_cidade"))
                            ? (int?)null
                            : reader.GetInt32(reader.GetOrdinal("cod_cidade"))
                    };
                }
            }

            // devolve a mesma view com Model preenchido
            return View("Editar", atleta);
        }

        // POST - grava alterações no banco
        [HttpPost]
        public IActionResult Editar(Atletas atleta)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"UPDATE atletas 
					SET nome_atleta = @nome, 
						data_nascimento = @data_nascimento,
						sexo = @sexo, 
						altura = @altura, 
						peso = @peso, 
						cod_cidade = @cod_cidade
					WHERE cod_atleta = @cod_atleta";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", atleta.NomeAtleta);
                cmd.Parameters.AddWithValue("@data_nascimento", atleta.DataNascimento);
                cmd.Parameters.AddWithValue("@sexo", atleta.Sexo);
                cmd.Parameters.AddWithValue("@altura", atleta.Altura);
                cmd.Parameters.AddWithValue("@peso", atleta.Peso);
                cmd.Parameters.AddWithValue("@cod_cidade", atleta.CodCidade);
                cmd.Parameters.AddWithValue("@cod_atleta", atleta.CodAtleta);

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Home");
        }


        private List<Atletas> GetAtletas()
        {
            var atletas = new List<Atletas>();

            using (var conn = db.GetConnection())
            {
                var sql = "SELECT DISTINCT * FROM atletas ORDER BY nome_atleta";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    atletas.Add(new Atletas
                    {
                        CodAtleta = reader.GetInt32("cod_atleta"),
                        NomeAtleta = reader["nome_atleta"]?.ToString(),
                        DataNascimento = reader["data_nascimento"]?.ToString(),
                        Sexo = reader.IsDBNull(reader.GetOrdinal("sexo"))
                            ? (char?)null
                            : Convert.ToChar(reader["sexo"]),
                        Altura = reader.IsDBNull(reader.GetOrdinal("altura"))
                            ? (decimal?)null
                            : reader.GetDecimal(reader.GetOrdinal("altura")),
                        Peso = reader.IsDBNull(reader.GetOrdinal("peso"))
                            ? (decimal?)null
                            : reader.GetDecimal(reader.GetOrdinal("peso")),
                        CodCidade = reader.IsDBNull(reader.GetOrdinal("cod_cidade"))
                            ? (int?)null
                            : reader.GetInt32(reader.GetOrdinal("cod_cidade"))
                    });
                }
            }

            return atletas;
        }

        private List<Cidade> GetCidades()
        {
            var cidades = new List<Cidade>();

            using (var conn = db.GetConnection())
            {
                var sql = "SELECT DISTINCT * FROM cidades ORDER BY nome_cidade";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cidades.Add(new Cidade
                    {
                        CodCidade = reader.GetInt32("cod_cidade"),
                        NomeCidade = reader.GetString("nome_cidade"),
                        CodEstado = reader.GetInt32("cod_estado")
                    });
                }
            }

            return cidades;
        }


    }
}
