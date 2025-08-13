using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olímpicos.Data;
using Olímpicos.Models;
using System.Collections.Generic;

namespace Olímpicos.Controllers
{
    public class EdicaoController : Controller
    {
        private readonly Database db = new Database();
        public IActionResult Index()
        {
            List<Edicao> edicoes = new List<Edicao>();
            using (MySqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM edicao";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        edicoes.Add(new Edicao
                        {
                            Codedicao = reader.GetInt32("cod_edicao"),
                            Ano = reader.GetInt32("ano"),
                            Sede = reader.GetString("sede")
                        });
                    }
                }
            }
            return View(edicoes);

        }

        public IActionResult Atletas(int id)
        {
            List<Atletas> atletas = new List<Atletas>();
            string nomeEdicao = "";
            int totalAtletas = 0;

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"
            SELECT DISTINCT 
                        a.cod_atleta, 
                        a.nome_atleta, 
                        a.data_nascimento, 
                        a.sexo, 
                        a.cod_cidade,
                        m.cod_modalidade, 
                        m.nome_modalidade
                    FROM resultados_atletas r
                    JOIN provas p ON p.cod_prova = r.cod_prova
                    JOIN atletas a ON a.cod_atleta = r.cod_atleta
                    LEFT JOIN modalidades m ON m.cod_modalidade = p.cod_modalidade
                    WHERE r.edicao = @id        
                    ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        atletas.Add(new Atletas
                        {
                            CodAtleta = reader.GetInt32(reader.GetOrdinal("cod_atleta")),

                            NomeAtleta = reader.IsDBNull(reader.GetOrdinal("nome_atleta")) ? null : reader.GetString(reader.GetOrdinal("nome_atleta")),

                            DataNascimento = reader.IsDBNull(reader.GetOrdinal("data_nascimento")) ? null
                                : reader.GetString(reader.GetOrdinal("data_nascimento")),

                            Sexo = reader.IsDBNull(reader.GetOrdinal("sexo"))
                                ? '\0'  // valor padrão para char
                                : reader.GetChar(reader.GetOrdinal("sexo")),

                            CodCidade = reader.IsDBNull(reader.GetOrdinal("cod_cidade"))
                                ? 0  // ou (int?)null se for Nullable<int>
                                : reader.GetInt32(reader.GetOrdinal("cod_cidade")),

                            CodModalidade = reader.IsDBNull(reader.GetOrdinal("cod_modalidade"))
                                ? 0  // ou (int?)null se sua propriedade for Nullable
                                : reader.GetInt32(reader.GetOrdinal("cod_modalidade")),

                            Modalidade = reader.IsDBNull(reader.GetOrdinal("nome_modalidade"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("nome_modalidade"))
                        });
                    }

                }

                totalAtletas = atletas.Count;
            }

            ViewBag.EdicaoId = id;
            ViewBag.TotalAtletas = totalAtletas;
            return View(atletas);
        }
        public IActionResult Detalhes(int id)
        {
            Atletas atleta = null;
            List<(string Prova, string Edicao, string Resultado, string Medalha)> participacoes = new();

            using (var conn = db.GetConnection())
            {
                string query = @"
         SELECT 
             a.cod_atleta,a.nome_atleta,a.data_nascimento,a.sexo,c.cod_cidade, c.nome_cidade,e.nome_estado,
             m.cod_modalidade, m.nome_modalidade,p.nome_prova,r.resultado,r.medalha 
                 FROM atletas a
                 JOIN cidades c ON c.cod_cidade = a.cod_cidade
                 JOIN estados e ON e.cod_estado = c.cod_estado
                 JOIN resultados_atletas r ON r.cod_atleta = a.cod_atleta
                 JOIN provas p ON p.cod_prova = r.cod_prova
                 JOIN modalidades m ON m.cod_modalidade = p.cod_modalidade
                 WHERE a.cod_atleta = @id";

                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        atleta = new Atletas
                        {
                            CodAtleta = reader.GetInt32("cod_atleta"),
                            NomeAtleta = reader.GetString("nome_atleta"),
                            DataNascimento = reader.GetString("data_nascimento"),
                            Sexo = reader.GetChar("sexo"),
                            CidadeNascimento = reader.GetString("nome_cidade"),
                            CodModalidade = reader.GetInt32("cod_modalidade"),
                            Modalidade = reader.GetString("nome_modalidade"),
                            EstadoNascimento = reader.GetString("nome_estado"),
                            CodCidade = reader.GetInt32("cod_cidade")
                        };
                    }
                }

                // Buscar participações
                string participacaoQuery = @"
SELECT p.nome_prova, e.ano, e.sede, r.resultado, r.medalha
     FROM resultados_atletas r
     JOIN provas p ON p.cod_prova = r.cod_prova
     JOIN edicao e ON e.cod_edicao = r.edicao
     WHERE r.cod_atleta = @id";
                var cmd2 = new MySqlCommand(participacaoQuery, conn);
                cmd2.Parameters.AddWithValue("@id", id);
                using (var reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        participacoes.Add((
                            reader.IsDBNull(reader.GetOrdinal("nome_prova"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("nome_prova")),

                            $"{(reader.IsDBNull(reader.GetOrdinal("ano"))
                                ? "?"
                                : reader.GetInt32(reader.GetOrdinal("ano")).ToString())} - {(reader.IsDBNull(reader.GetOrdinal("sede"))
                                ? "?"
                                : reader.GetString(reader.GetOrdinal("sede")))}",

                            reader.IsDBNull(reader.GetOrdinal("resultado"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("resultado")),

                            reader.IsDBNull(reader.GetOrdinal("medalha"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("medalha"))
                        ));
                    }

                }
            }

            ViewBag.Participacoes = participacoes;
            return View(atleta);
        }


    }
}
