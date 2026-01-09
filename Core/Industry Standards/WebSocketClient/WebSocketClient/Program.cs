using System.Net.WebSockets;
using System.Text;

namespace WebSocketClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (ClientWebSocket webSocket = new ClientWebSocket())
            {
                Uri serverUri = new Uri("wss://localhost:7107/"); // Update the URL as needed

                try
                {
                    await webSocket.ConnectAsync(serverUri, CancellationToken.None);
                    Console.WriteLine("Connected to WebSocket server.");

                    // Send a message to the server
                    string messageToSend = "Hello from client";
                    byte[] messageBytes = Encoding.UTF8.GetBytes(messageToSend);
                    await webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);

                    // Receive a response from the server
                    byte[] buffer = new byte[1024];
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine("Received from server: " + receivedMessage);
                }
                catch (Exception e)
                {
                    Console.WriteLine("WebSocket error: " + e.Message);
                }
            }
        }
    }
}
