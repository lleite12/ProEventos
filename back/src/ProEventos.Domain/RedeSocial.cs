
namespace ProEventos.Domain
{
    public class RedeSocial
    {
        
        public int ID { get; set; }
        public string nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public Evento Evento { get; set; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}