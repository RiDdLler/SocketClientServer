using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SocketClientHW
{
	public partial class MainWindow : Window
	{
		private TcpClient client;
		private NetworkStream stream;

		public MainWindow()
		{
			InitializeComponent();
			client = new TcpClient();
			ConnectToServer();
		}

		private async void ConnectToServer()
		{
			try
			{
				await client.ConnectAsync("127.0.0.1", 12345);
				StatusTextBlock.Text = "Подключено к серверу";

				stream = client.GetStream();

				Task.Run(() => ReceiveMessages());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при подключении к серверу: " + ex.Message);
			}
		}

		private async void SendButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string request = RequestTextBox.Text;
				byte[] buffer = Encoding.UTF8.GetBytes(request + "\n");

				await stream.WriteAsync(buffer, 0, buffer.Length);

				// Очистим поле ввода
				RequestTextBox.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при отправке запроса: " + ex.Message);
			}
		}

		private async void ReceiveMessages()
		{
			byte[] buffer = new byte[1024];
			string incompleteMessage = string.Empty;

			while (true)
			{
				try
				{
					int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
					if (bytesRead <= 0)
						break;

					string response = incompleteMessage + Encoding.UTF8.GetString(buffer, 0, bytesRead);

					string[] messages = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
					
					if (messages.Length > 0)
					{
						incompleteMessage = messages[messages.Length - 1];
					}


					foreach (string message in messages)
					{
						Dispatcher.Invoke(() =>
						{
							ResponseTextBox.Text += "Получен ответ: " + message + "\n";
						});
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ошибка при получении сообщения: " + ex.Message);
					break;
				}
			}
		}
	}
}
