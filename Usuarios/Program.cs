using System.Text.Json;
using spaceUsuarios;


HttpClient cliente = new HttpClient();

async Task GetClima()
{
    var url = "https://jsonplaceholder.typicode.com/users/";
    HttpResponseMessage response = await cliente.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string body = await response.Content.ReadAsStringAsync();
    List<Usuarios> tareas = JsonSerializer.Deserialize<List<Usuarios>>(body);
    for (int i = 0; i < 5; i++)
    {
        tareas[i].mostrar();
    }
}

await GetClima();