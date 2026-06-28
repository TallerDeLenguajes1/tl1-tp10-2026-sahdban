namespace spaceTarea
{
    public class Tarea
    {
        public int userId{get; set;}
        public int id{get; set;}
        public string? title{get; set;} = String.Empty;
        public bool completed{get; set;}

        public void mostrar()
        {
            Console.WriteLine($"Titulo: {title}, estado: {completed}");
        }
    }
}