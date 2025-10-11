using Laboratorio1_linqs_OPENAI;
using System;
using System.Net.Http.Json;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        var url = "https://jsonplaceholder.typicode.com/posts";
        using var http = new HttpClient();

        try
        {
            // Descargar y deserializar el JSON en List<Post>
            List<Post> posts = await http.GetFromJsonAsync<List<Post>>(url);

            Console.WriteLine($"Cargados {posts?.Count ?? 0} posts.\n");

            // Mostrar los primeros 5 como ejemplo
            foreach (var p in posts.Take(5))
            {
                Console.WriteLine(p); // Usa el ToString() de Post
            }

            // Ejecutar consultas LINQ
            ConsultasLinqs consultas = new ConsultasLinqs(posts);
            consultas.EjecutarConsultas();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los datos: " + ex.Message);
        }
    }
}
