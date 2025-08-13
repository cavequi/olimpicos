namespace Olímpicos.Models
{
    public class Resultados
    {
        public int CodResultado { get; set; }

        public int CodAtleta { get; set; }

        public int CodProva { get; set; }
        public int Edicao { get; set; }
        public string? Resultado { get; set; }
        public string? Medalha { get; set; }

    }
}
