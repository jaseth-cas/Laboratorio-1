using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1_linqs_OPENAI
{
    public class Post
    {
        public int userId { get; set; }//obtenemos y seteamos los datos de la API
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()//funciona para devolver los datos importantes dentro de la API
        {
            string shortBody = body.Length > 50 ? body.Substring(0, 50) + "..." : body;
            return $"{id} (user {userId}): {title} (body {shortBody})";
        }
    }
}

