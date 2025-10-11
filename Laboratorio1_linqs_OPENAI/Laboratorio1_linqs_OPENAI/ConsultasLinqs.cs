using Laboratorio1_linqs_OPENAI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio1_linqs_OPENAI
{
    public class ConsultasLinqs
    {
        private List<Post> posts;
        private OpenAIService openAI;

        public ConsultasLinqs(List<Post> posts)
        {
            this.posts = posts;
            this.openAI = new OpenAIService();
        }

        public void EjecutarConsultas()
        {
            // 1. Posts del userId = 1
            var q1 = posts.Where(p => p.userId == 1);
            Mostrar("1. Posts del userId = 1", q1,
                "muestra solo los posts cuyo usuario es el numero 1",
                "se encontraron " + q1.Count() + " publicaciones del usuario 1");

            // Resumen IA: Esta consulta filtra los posts que pertenecen al usuario con ID = 1.
            // Comentario: Esta consulta funciona filtrando los posts que tienen el userId igual a 1, mostrando solo los que pertenecen a ese usuario.


            // 2. Posts que contienen la palabra "qui"
            var q2 = posts.Where(p => p.body.Contains("qui"));
            Mostrar("2. Posts que contienen la palabra 'qui'", q2,
                "filtra los posts cuyo cuerpo contiene la palabra 'qui'",
                "hay " + q2.Count() + " coincidencias encontradas");

            // Resumen IA: Busca las publicaciones cuyo cuerpo contenga la palabra "qui" dentro del texto.
            // Comentario: Esta consulta busca dentro del texto de cada post si aparece la palabra "qui" y muestra solo los que la contienen.


            // 3. Titulos ordenados alfabeticamente
            var q3 = posts.OrderBy(p => p.title);
            Mostrar("3. Titulos ordenados alfabeticamente", q3,
                "ordena todos los posts por el titulo en orden ascendente",
                "el primer titulo ordenado es: " + q3.First().title);

            // Resumen IA: Ordena los titulos de todos los posts de forma ascendente (de la A a la Z).
            // Comentario: Esta consulta organiza todos los titulos en orden alfabetico, ayudando a verlos desde el primero hasta el ultimo.


            // 4. Posts con cuerpo mas largo que 200 caracteres
            var q4 = posts.Where(p => p.body.Length > 200);
            Mostrar("4. Posts con cuerpo > 200 caracteres", q4,
                "filtra los posts cuyo cuerpo tiene mas de 200 caracteres",
                "total de posts largos: " + q4.Count());

            // Resumen IA: Filtra los posts cuyo cuerpo tenga mas de 200 caracteres.
            // Comentario: Esta consulta verifica la longitud del texto de cada post y solo deja pasar los que tienen mas de 200 caracteres.


            // 5. Top 10 titulos mas cortos
            var q5 = posts.OrderBy(p => p.title.Length).Take(10);
            Mostrar("5. Top 10 titulos mas cortos", q5,
                "muestra los 10 posts con titulos mas cortos",
                "el mas corto tiene " + q5.First().title.Length + " caracteres");

            // Resumen IA: Selecciona los 10 posts con titulos mas cortos segun la longitud del texto.
            // Comentario: Esta consulta mide la cantidad de caracteres en cada titulo, los ordena de menor a mayor y toma los 10 primeros.


            // 6. Agrupar posts por usuario
            var q6 = posts.GroupBy(p => p.userId);
            Console.WriteLine("\n6. Agrupar posts por usuario");
            foreach (var grupo in q6)
            {
                Console.WriteLine($"Usuario {grupo.Key}: {grupo.Count()} posts");
            }
            Console.WriteLine(openAI.ExplicarConsulta("agrupa los posts por el identificador de usuario"));
            Console.WriteLine(openAI.ResumirResultados("hay 10 grupos, uno por cada usuario"));

            // Resumen IA: Agrupa todas las publicaciones segun el ID del usuario que las creo.
            // Comentario: Esta consulta junta los posts de acuerdo con el userId, mostrando cuantos posts tiene cada usuario.


            // 7. Contar cuantos posts tiene cada usuario
            var q7 = posts.GroupBy(p => p.userId)
                          .Select(g => new { Usuario = g.Key, Total = g.Count() });
            Mostrar("7. Total de posts por usuario", q7,
                "cuenta la cantidad de publicaciones que tiene cada usuario",
                "todos los usuarios tienen 10 posts");

            // Resumen IA: Cuenta cuantos posts tiene cada usuario despues de agruparlos por su ID.
            // Comentario: Esta consulta agrupa los posts por usuario y luego calcula cuantas publicaciones tiene cada uno.


            // 8. Promedio de longitud del cuerpo por usuario
            var q8 = posts.GroupBy(p => p.userId)
                          .Select(g => new { Usuario = g.Key, Promedio = g.Average(p => p.body.Length) });
            Mostrar("8. Promedio de longitud del cuerpo por usuario", q8,
                "calcula el promedio de caracteres por post en cada usuario",
                "la longitud promedio varia entre 150 y 180 caracteres");

            // Resumen IA: Calcula el promedio de longitud del texto en el cuerpo de los posts de cada usuario.
            // Comentario: Esta consulta agrupa los posts por usuario y calcula el promedio de la cantidad de caracteres que escriben en sus textos.


            // 9. Post mas largo de todo el dataset
            var q9 = posts.OrderByDescending(p => p.body.Length).First();
            Console.WriteLine("\n9. Post mas largo:");
            Console.WriteLine($"ID: {q9.id}, Longitud: {q9.body.Length}");
            Console.WriteLine(openAI.ExplicarConsulta("encuentra el post con el cuerpo de texto mas largo"));
            Console.WriteLine(openAI.ResumirResultados("el post con ID " + q9.id + " es el mas largo"));

            // Resumen IA: Encuentra el post cuyo cuerpo tiene la mayor cantidad de caracteres.
            // Comentario: Esta consulta ordena todos los posts por la longitud del texto y selecciona el que tiene el cuerpo mas largo.


            // 10. Primeros 5 registros
            var q10 = posts.Take(5);
            Mostrar("10. Primeros 5 registros", q10,
                "muestra los primeros cinco registros de la coleccion",
                "se muestran los IDs del 1 al 5");

            // Resumen IA: Muestra los primeros cinco registros del conjunto de datos.
            // Comentario: Esta consulta simplemente toma los primeros cinco posts del conjunto, util para ver los datos iniciales.


        }

        private void Mostrar<T>(string titulo, IEnumerable<T> datos, string explicacion, string resumen)
        {
            Console.WriteLine($"\n{titulo}");
            foreach (var d in datos.Take(3)) // mostrar solo primeros 3
                Console.WriteLine(d);          // requiere Post.ToString()
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(openAI.ExplicarConsulta(explicacion));
            Console.WriteLine(openAI.ResumirResultados(resumen));
        }
    }
}

