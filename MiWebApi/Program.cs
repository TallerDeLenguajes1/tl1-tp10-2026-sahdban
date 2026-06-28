using System.Text.Json.Nodes;
using System.Text.Json;

HttpClient cliente = new HttpClient();

async Task GetPoke()
{
    var url = "https://pokeapi.co/api/v2/pokemon/";
    Console.WriteLine("ingrese el id del pokemon a buscar: ");
    string? id = Console.ReadLine();
    HttpResponseMessage response = await cliente.GetAsync(url+id);
    response.EnsureSuccessStatusCode();

    string body = await response.Content.ReadAsStringAsync();
    var json = JsonNode.Parse(body);
    string? nombre = json?["name"]?.ToString();
    var listaTipos = new List<string>();
    var tiposArray = json?["types"]?.AsArray();

    if (tiposArray != null)
    {
        foreach (var tip in tiposArray)
        {
            string? nombreTipo = tip?["type"]?["name"]?.ToString();
            if (nombreTipo != null) listaTipos.Add(nombreTipo);
        }
    }

    var datos = new
    {
        nombre = nombre,
        tipos = listaTipos
    };
    
    string datosFinal = JsonSerializer.Serialize(datos);
    using (FileStream js = File.Create("tareas.json"))
    {
        await JsonSerializer.SerializeAsync(js, datosFinal);
    }
}

await GetPoke();