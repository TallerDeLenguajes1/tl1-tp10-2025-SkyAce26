using System;
using catFacts;
using System.Text.Json;

List<CatFact> historial = new List<CatFact>();
List<string> historialTexto = new List<string>();

bool seguir = true;
do
{
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
    response.EnsureSuccessStatusCode();
    string? myJsonResponse = await response.Content.ReadAsStringAsync();
    CatFact? catFact = JsonSerializer.Deserialize<CatFact>(myJsonResponse);


    Console.WriteLine("Curiosidades de los gatos:\n");
    Console.WriteLine($"\nCuriosidad: {catFact?.Fact}");

    if (catFact != null)
    {
        historial.Add(catFact);
        historialTexto.Add(catFact.Fact);
    }

    Console.WriteLine("Quiere leer otra curiosidad? 1 = Si, 0 = No\n");
    int continuar = int.Parse(Console.ReadLine());
    if (continuar == 0)
    {
        seguir = false;
    }
} while (seguir);


string jsonCuriosidadesTexto = JsonSerializer.Serialize<List<string>>(historialTexto);
string jsonString = JsonSerializer.Serialize<List<CatFact>>(historial);

File.WriteAllText($"TextoCuriosidades.txt", jsonCuriosidadesTexto);
File.WriteAllText("Curiosidades.json", jsonString);




