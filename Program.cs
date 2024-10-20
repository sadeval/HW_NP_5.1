using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string url = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status";

        using HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            Console.WriteLine($"Статус-код: {response.StatusCode}");

            Console.WriteLine("Заголовки ответа:");
            foreach (var header in response.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }

            Console.WriteLine("Заголовки содержимого:");
            foreach (var contentHeader in response.Content.Headers)
            {
                Console.WriteLine($"{contentHeader.Key}: {string.Join(", ", contentHeader.Value)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
