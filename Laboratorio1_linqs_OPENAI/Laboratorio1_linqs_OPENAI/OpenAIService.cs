using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1_linqs_OPENAI
{
    public class OpenAIService
    {
        public string ExplicarConsulta(string descripcion)
        {
            return $"🤖 Explicación automática: {descripcion}";
        }

        public string ResumirResultados(string resumen)
        {
            return $"🧠 Resumen IA: {resumen}";
        }
    }
}

