namespace nimporteauth
{
    public class ContactGroupe
    {
        public int GroupeId { get; set; }
        public int ContactId { get; set; }
        public Groupe Groupe { get; set; } = null!;
        public Contact Contact { get; set; } = null!;
    }
}
