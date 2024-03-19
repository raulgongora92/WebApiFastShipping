namespace WebApiFastShipping.Models
{
    public class Conductor
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int LicenTrans {  get; set; }
        public DateTime FechaNacim {  get; set; }

    }
}
