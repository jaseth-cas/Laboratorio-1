using Laboratorio1_linqs_OPENAI;
using System;
using System.Net.Http.Json;

var url = "https://jsonplaceholder.typicode.com/posts";//url de los posts
using var http = new HttpClient();

try
{
    var posts = await http.GetFromJsonAsync<List<Post>>(url);//utilizamos await para permitir que el codigo haga otras tareas sin esperar a que finalice esta
    Console.WriteLine($"Cargados {posts?.Count ?? 0} posts.\n");

    var consultas = new ConsultasLinqs(posts);
    await consultas.EjecutarConsultasAsync();

    await ConsultasLinqs.Consulta20Async(posts, new OpenAIService());
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
