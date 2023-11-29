namespace nimporteauth
{
    public class Groupe
    {
        public int Id { get; set; }
        public string nom {  get; set; }
        public List<ContactGroupe> contactGroupes { get; set; }
    }
}
