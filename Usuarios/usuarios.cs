using System.Runtime.Serialization;

namespace spaceUsuarios
{
    public class Geo
    {
        public string lat{get; set;} = String.Empty;
        public string lng{get; set;} = String.Empty;
    }

    public class Address
    {
        public string street{get; set;} = String.Empty;
        public string suite{get; set;} = String.Empty;
        public string city{get; set;} = String.Empty;
        public string zipcode{get; set;} = String.Empty;
        public Geo geo {get; set;} = new Geo();
    }
    public class Usuarios
    {
        public int id;
        public string name {get; set;} = String.Empty;
        public string username {get; set;} = String.Empty;
        public string email {get; set;} = String.Empty;
        public Address address{get; set;} = new Address();

        public void mostrar()
        {
            Console.WriteLine($"Nombre: {name}, correo electronico: {email}, domicilio: {address.street}");
        }
    }
}