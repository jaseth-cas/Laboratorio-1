using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Laboratorio1_linqs_OPENAI
{
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            // Muestra solo los primeros 50 caracteres del body para que sea legible
            string shortBody = body.Length > 50 ? body.Substring(0, 50) + "..." : body;
            return $"{id} (user {userId}): {title} (body {shortBody})";
        }
    }
}

