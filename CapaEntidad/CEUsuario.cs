namespace CapaEntidad
{
    public class CEUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;

       

        public CEUsuario(int id, string nombre, string apellido, string foto)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Foto = foto;
        }

        public CEUsuario()
        {

        }
      
    }
}