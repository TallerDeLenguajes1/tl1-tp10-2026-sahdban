using System.Text.Json;
using spaceTarea;
HttpClient cliente = new HttpClient();

async Task GetClima()
{
    var url = "https://jsonplaceholder.typicode.com/todos/";
    HttpResponseMessage response = await cliente.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string body = await response.Content.ReadAsStringAsync();
    List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(body);
    List<Tarea> pendientes = tareas.FindAll(t => !t.completed);
    List<Tarea> completas = tareas.FindAll(t => t.completed);
    foreach (var tar in pendientes)
    {
        tar.mostrar();
    }
    foreach (var tar in completas)
    {
        tar.mostrar();
    }
    string json = JsonSerializer.Serialize(completas);
    using (FileStream js = File.Create("tareas.json"))
    {
        await JsonSerializer.SerializeAsync(js, completas);
    }
}

await GetClima();