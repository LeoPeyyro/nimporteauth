using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace nimporteauth
{
    public class Contact
    {
        public int Id { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string email { get; set; }
        public bool estPro { get; set; }
        public Groupe? groupe { get; set; }
        public int? groupeId { get; set; }
    }

}
