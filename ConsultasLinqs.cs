using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1_linqs_OPENAI
{
    public class ConsultasLinqs
    {
        //variables que guardan datos y servicios que la clase necesita
        private readonly List<Post> posts;
        private readonly OpenAIService openAI;

        public ConsultasLinqs(List<Post> posts)//constructor para el post y la IA
        {
            this.posts = posts;
            this.openAI = new OpenAIService();
        }

        public async Task EjecutarConsultasAsync()//metodo para llamar a todas las consultas
        {
            await Consulta1Async();
            await Consulta2Async();
            await Consulta3Async();
            await Consulta4Async();
            await Consulta5Async();
            await Consulta6Async();
            await Consulta7Async();
            await Consulta8Async();
            await Consulta9Async();
            await Consulta10Async();
            await Consulta11Async();
            await Consulta12Async();
            await Consulta13Async();
            await Consulta14Async();
            await Consulta15Async();
            await Consulta16Async();
            await Consulta17Async();
            await Consulta18Async();
            await Consulta19Async();
            await Consulta21Async();
            await Consulta22Async();
        }

        //los async son metodos asincronicos osea que async hacer que se pueda ejecutar operaciones que toman tiempo
        // en estos casos del programa son esperar a que la API de una respuesta o leer un archivo
        //por ultimo task es una tarea que puede ejecutarse en segundo plano y el await ayuda a que la tarea termine 
        // imprime, explica y resume con 3 registros siempre

        private async Task MostrarAsync<T>(string titulo, IEnumerable<T> datos, string explicacion, string resumen)
        {
            Console.WriteLine($"\n{titulo}");
            foreach (var d in datos.Take(3))
                Console.WriteLine(d);
            Console.WriteLine(new string('-',40));
            Console.WriteLine(await openAI.ExplicarConsultaAsync(explicacion));
            Console.WriteLine(await openAI.ResumirResultadosAsync(resumen));
        }

        //1. Posts del userId=1
        private async Task Consulta1Async()
        {
            var q = posts.Where(p => p.userId == 1);// se utiliza where cuando se necesita encontra el usuario 1
            await MostrarAsync("1. Posts del userId = 1", q,
                "filtra los posts cuyo usuario es el número 1",
                $"se encontraron {q.Count()} publicaciones del usuario 1");
        }

        // 2. Posts que contienen la palabra “qui”.
        private async Task Consulta2Async()
        {
            var q = posts.Where(p => p.body.Contains("qui"));//se utiliza where donde el cuerpo contiene qui
            await MostrarAsync("2. Posts que contienen la palabra 'qui'", q,
                "filtra los posts cuyo cuerpo contiene la palabra 'qui'",
                $"hay {q.Count()} coincidencias encontradas");
        }

        //3. Títulos ordenados alfabéticamente.
        private async Task Consulta3Async()
        {
            var q = posts.OrderBy(p => p.title);//se utilizar orderby para que los titulos se ordenen de manera ascendente
            await MostrarAsync("3. Títulos ordenados alfabéticamente", q,
                "ordena los posts por título en orden ascendente",
                $"el primer título es: {q.First().title}");
        }

        //4. Posts con cuerpo más largo que 200 caracteres.
        private async Task Consulta4Async()
        {
            var q = posts.Where(p => p.body.Length > 200);//se utiliza where para encontrar el cuerpo mas largo que 200 con la ayuda de length
            await MostrarAsync("4. Posts con cuerpo > 200 caracteres", q,
                "filtra los posts cuyo cuerpo tiene más de 200 caracteres",
                $"total de posts largos: {q.Count()}");
        }

        //5. Top 10 títulos más cortos
        private async Task Consulta5Async()
        {
            var q = posts.OrderBy(p => p.title.Length).Take(10);
            await MostrarAsync("5. Top 10 títulos más cortos", q,
                "muestra los 10 posts con títulos más cortos",
                $"el más corto tiene {q.First().title.Length} caracteres");
        }

        //6. Agrupar posts por usuario.
        private async Task Consulta6Async()
        {
            var q = posts.GroupBy(p => p.userId);//se utiliza group by para agrupar los id y un foreach para contar cuantos posts hay por usuario
            Console.WriteLine("\n6. Agrupar posts por usuario");
            foreach (var grupo in q)
                Console.WriteLine($"Usuario {grupo.Key}: {grupo.Count()} posts");

            Console.WriteLine(await openAI.ExplicarConsultaAsync("agrupa los posts por el identificador del usuario"));
            Console.WriteLine(await openAI.ResumirResultadosAsync("hay 10 grupos, uno por cada usuario"));
        }

        //7. Contar cuántos posts tiene cada usuario.
        private async Task Consulta7Async()
        {
            var q = posts.GroupBy(p => p.userId)//agrupa cuantos posts tiene los usuario y los cuenta
                         .Select(g => new { Usuario = g.Key, Total = g.Count() });
            await MostrarAsync("7. Total de posts por usuario", q,
                "cuenta la cantidad de publicaciones que tiene cada usuario",
                "todos los usuarios tienen 10 posts");
        }

        //8. Promedio de longitud del cuerpo por usuario.
        private async Task Consulta8Async()
        {
            var q = posts.GroupBy(p => p.userId)//agrupa los id y despues usamos el average para obtener el promedio de longitud de cuerpo
                         .Select(g => new { Usuario = g.Key, Promedio = g.Average(p => p.body.Length) });
            await MostrarAsync("8. Promedio de longitud del cuerpo por usuario", q,
                "calcula el promedio de caracteres por post en cada usuario",
                "la longitud promedio varía entre 150 y 180 caracteres");
        }

        //9. Post más largo de todo el dataset.
        private async Task Consulta9Async()
        {
            var q = posts.OrderByDescending(p => p.body.Length).First();// ordena de forma descendente y toma el primero
            Console.WriteLine("\n9. Post más largo:");
            Console.WriteLine($"ID: {q.id}, Longitud: {q.body.Length}");
            Console.WriteLine(await openAI.ExplicarConsultaAsync("encuentra el post con el cuerpo más largo"));
            Console.WriteLine(await openAI.ResumirResultadosAsync($"el post con ID {q.id} es el más largo"));
        }

        //10. Post mas corto
        private async Task Consulta10Async()
        {
            var q = posts.OrderBy(p => p.body.Length).First();// ordenamos ascendentemente el cuerpo y toma el primer registro

            Console.WriteLine("\n10. Post más corto:");
            Console.WriteLine($"ID: {q.id}, Longitud: {q.body.Length}");
            Console.WriteLine(await openAI.ExplicarConsultaAsync("encuentra el post con el cuerpo más corto"));
            Console.WriteLine(await openAI.ResumirResultadosAsync($"el post con ID {q.id} tiene el cuerpo más corto, con {q.body.Length} caracteres"));
        }

        // 11. Primeros 5 registros (Take)
        private async Task Consulta11Async()
        {
            var q = posts.Take(5);
            await MostrarAsync("11. Primeros 5 registros (Take)", q,//utilizamos take para tomar los registros
                "toma los primeros 5 registros de la lista",
                "muestra los primeros 5 posts del dataset");
        }

        // 12. Saltar los primeros 50 (Skip)
        private async Task Consulta12Async()
        {
            var q = posts.Skip(50);
            await MostrarAsync("12. Saltar los primeros 50 registros", q,//utilizamos skip para saltarnos los primeros 50 registros
                "omite los primeros 50 posts y muestra el resto",
                $"se muestran {q.Count()} registros después del salto");
        }

        // 13. Títulos distintos
        private async Task Consulta13Async()
        {
            var q = posts.Select(p => p.title).Distinct();//utilizamos distinct para eliminar duplicados
            await MostrarAsync("13. Títulos distintos", q,
                "obtiene los títulos únicos sin duplicados",
                $"hay {q.Count()} títulos distintos");
        }

        // 14. Usuarios con más de 8 posts
        private async Task Consulta14Async()
        {
            var q = posts.GroupBy(p => p.userId)//agrupamos los usarios para despues contar los post y los que sean mayor que 8 los presenta
                         .Where(g => g.Count() > 8)
                         .Select(g => new { Usuario = g.Key, Total = g.Count() });
            await MostrarAsync("14. Usuarios con más de 8 posts", q,
                "muestra los usuarios que tienen más de 8 publicaciones",
                $"se encontraron {q.Count()} usuarios que cumplen la condición");
        }

        // 15. Tres títulos más largos por usuario
        private async Task Consulta15Async()
        {
            var q = posts.GroupBy(p => p.userId)//agrupamos los usuarios
                         .Select(g => new
                         {
                             Usuario = g.Key,
                             Top3 = g.OrderByDescending(p => p.title.Length)//ordenemos de forma descendente por longitud 
                                     .Take(3)//toma los primeros 3
                                     .Select(p => p.title)
                         });
            Console.WriteLine("\n15. Tres títulos más largos por usuario");
            foreach (var u in q)
            {
                Console.WriteLine($"\nUsuario {u.Usuario}:");
                foreach (var t in u.Top3)
                    Console.WriteLine($" - {t}");
            }
            Console.WriteLine(await openAI.ExplicarConsultaAsync("lista los tres títulos más largos por cada usuario"));
            Console.WriteLine(await openAI.ResumirResultadosAsync("se muestran tres títulos por cada usuario"));
        }

        // 16. Agrupar por número par/impar de ID
        private async Task Consulta16Async()
        {
            var q = posts.GroupBy(p => p.id % 2 == 0 ? "Par" : "Impar")//agrupamos los id par e impar y los contamos
                         .Select(g => new { Tipo = g.Key, Total = g.Count() });
            await MostrarAsync("16. Agrupar por número par o impar de ID", q,
                "agrupa los posts según si su ID es par o impar",
                "muestra la cantidad de posts pares e impares");
        }

        // 17. posts del usuario 3 que contenga “voluptate”
        private async Task Consulta17Async()
        {
            var q = posts.Where(p => p.userId == 3 && p.body.Contains("voluptate"));// where para encontrar al usuario 3 y despues en el cuerpo que contenga voluptate
            await MostrarAsync("17. Posts del usuario 3 que contienen 'voluptate'", q,
                "filtra los posts del usuario 3 que contienen la palabra 'voluptate'",
                $"se encontraron {q.Count()} coincidencias");
        }

        // 18. Promedio global de longitud
        private async Task Consulta18Async()
        {
            var promedio = posts.Average(p => p.body.Length);//promediamos el cuerpo de cada post con la longitud
            Console.WriteLine("\n18. Promedio global de longitud del cuerpo");
            Console.WriteLine($"Promedio de caracteres por post: {promedio:F2}");
            Console.WriteLine(await openAI.ExplicarConsultaAsync("calcula el promedio de longitud del cuerpo de todos los posts"));
            Console.WriteLine(await openAI.ResumirResultadosAsync($"el promedio global es de {promedio:F2} caracteres"));
        }

        // 19. Proporción de posts largos vs cortos
        private async Task Consulta19Async()
        {
            int umbral = 150; // variable para proporcionar los posts
            int largos = posts.Count(p => p.body.Length > umbral);//contar los que sean mayor o igual que la proporciom
            int cortos = posts.Count(p => p.body.Length <= umbral);//contar los que sean menor o igual que la proporciom
            double total = posts.Count;//contamos el total de los posts

            double propLargos = (largos / total) * 100;//sacamos las proporiciones 
            double propCortos = (cortos / total) * 100;

            Console.WriteLine("\n19. Proporción de posts largos vs cortos");
            Console.WriteLine($"Largos (> {umbral}): {propLargos:F2}%");
            Console.WriteLine($"Cortos (<= {umbral}): {propCortos:F2}%");
            Console.WriteLine(await openAI.ExplicarConsultaAsync("compara la proporción de posts largos y cortos usando un umbral de 150 caracteres"));
            Console.WriteLine(await openAI.ResumirResultadosAsync($"el {propLargos:F2}% son largos y el {propCortos:F2}% son cortos"));
        }

        // 20. Consulta generada por OpenAI
        public static async Task Consulta20Async(List<Post> posts, OpenAIService openAI)
        {
            Console.WriteLine("\n20. Consulta generada por OpenAI");

            var qAI = posts.Where(p => p.title.StartsWith("s"))//donde el titulo empiece con s
                           .Select(p => new { p.id, p.title, Longitud = p.body.Length });

            foreach (var p in qAI.Take(5))//toma los 5 (simulado con 3)
                Console.WriteLine($"ID {p.id} - {p.title} ({p.Longitud} caracteres)");

            Console.WriteLine(await openAI.ExplicarConsultaAsync("filtra los posts cuyo título comienza con la letra 's'"));
            Console.WriteLine(await openAI.ResumirResultadosAsync($"se encontraron {qAI.Count()} posts que cumplen la condición"));
        }

        //21. Clasifica los posts con OpenAI
        private async Task Consulta21Async()
        {
            Console.WriteLine("\n21. Clasificación automática de posts (IA)");

            var ejemplos = string.Join("\n", posts.Take(5).Select(p => $"Título: {p.title}\nCuerpo: {p.body}"));
            //une el post con el titulo y el cuerpo
            var clasificacion = await openAI.ClasificarPostsAsync(ejemplos);
            Console.WriteLine(clasificacion);
        }

        // 22. Nueva consulta generada por OpenAI
        private async Task Consulta22Async()
        {
            Console.WriteLine("\n22. Nueva consulta generada por OpenAI");
            //consultas para la ia con su metodo dentro de openaiservice
            var idea = await openAI.GenerarNuevaConsultaAsync(
                "Tengo una lista de posts con userId, id, title y body. ¿Qué consulta LINQ interesante puedo hacer?");
            Console.WriteLine(idea);
        }
    }
}
