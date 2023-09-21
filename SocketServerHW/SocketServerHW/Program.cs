using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Server
{
	static async Task Main()
	{
		TcpListener listener = new TcpListener(IPAddress.Any, 12345);
		listener.Start();
		Console.WriteLine("Сервер запущен. Ожидание клиентов...");

		while (true)
		{
			TcpClient client = await listener.AcceptTcpClientAsync();
			Task.Run(() => HandleClient(client));
		}
	}

	static async Task HandleClient(TcpClient client)
	{
		try
		{
			NetworkStream stream = client.GetStream();
			byte[] buffer = new byte[1024];

			while (true)
			{
				int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
				if (bytesRead <= 0)
					break;

				string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
				Console.WriteLine("Получен запрос: " + request);

				// Здесь вы можете обработать запрос и отправить ответ
				string response = "Ответ на запрос: " + request + "\n";
				byte[] responseBuffer = Encoding.UTF8.GetBytes(response);
				await stream.WriteAsync(responseBuffer, 0, responseBuffer.Length);
				Console.WriteLine("Отправлен ответ: " + response);
			}

			client.Close();
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ошибка при обработке клиента: " + ex.Message);
		}
	}
}
