using OpenAI;
using OpenAI.Chat;
using System;
using System.Threading.Tasks;

namespace Laboratorio1_linqs_OPENAI
{
    public class OpenAIService
    {
        private readonly ChatClient _chatClient;

        public OpenAIService()
        {
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");//contiene la API para las consultas con la IA


            if (string.IsNullOrEmpty(apiKey))
                throw new Exception(" No se encontró la variable de entorno OPENAI_API_KEY.");

           
            _chatClient = new ChatClient(model: "gpt-4o-mini", apiKey: apiKey);
        }

        //  Explica una consulta LINQ
        public async Task<string> ExplicarConsultaAsync(string descripcion)
        {
            try
            {
                var response = await _chatClient.CompleteChatAsync([
                    ChatMessage.CreateUserMessage($"Explica en lenguaje natural esta consulta LINQ de C#: {descripcion}")
                ]);

                return "Explicación IA: " + response.Value.Content[0].Text;
            }
            catch (Exception ex)
            {
                return $" Error al obtener explicación: {ex.Message}";
            }
        }


        //  Resume resultados
        public async Task<string> ResumirResultadosAsync(string datos)
        {
            var response = await _chatClient.CompleteChatAsync([
                ChatMessage.CreateUserMessage($"Resume brevemente estos resultados: {datos}")
            ]);

            return "Resumen IA: " + response.Value.Content[0].Text;
        }

        //  Genera una nueva consulta LINQ
        public async Task<string> GenerarNuevaConsultaAsync(string contexto)
        {
            var response = await _chatClient.CompleteChatAsync([
                ChatMessage.CreateUserMessage(
                    $"Analiza esta descripción de datos: {contexto}. " +
                    "Genera una nueva idea de consulta LINQ útil para analizar los posts.")
            ]);

            return response.Value.Content[0].Text;
        }

        // Clasifica los posts dentro del json
        public async Task<string> ClasificarPostsAsync(string texto)
        {
            try
            {
                var response = await _chatClient.CompleteChatAsync([
                    ChatMessage.CreateUserMessage(
                $"Analiza el siguiente texto con varios posts y clasifícalos en categorías temáticas: \n\n{texto}")
                ]);

                return "Clasificación IA:\n" + response.Value.Content[0].Text;
            }
            catch (Exception ex)
            {
                return $" No se pudo clasificar: {ex.Message}";
            }
        }

    }
}
