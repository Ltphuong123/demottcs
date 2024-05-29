using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SocketClient : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private byte[] receiveBuffer = new byte[1024];

    void Start()
    {
        ConnectToPythonServer();
    }

    void ConnectToPythonServer()
    {
        try
        {
            client = new TcpClient("localhost", 5555);
            stream = client.GetStream();
            Debug.Log("Connected to Python server.");

            // Nhận các đoạn text từ Python và hiển thị
            ReceiveTextFromPython();
        }
        catch (Exception e)
        {
            Debug.LogError("Error connecting to Python server: " + e.Message);
        }
    }

    void ReceiveTextFromPython()
    {
        try
        {
            while (true)
            {
                int bytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                string receivedText = Encoding.UTF8.GetString(receiveBuffer, 0, bytesRead);
                Debug.Log("Received from Python: " + receivedText);

                // Reset buffer
                Array.Clear(receiveBuffer, 0, receiveBuffer.Length);

                // Handle received text here...
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error receiving data from Python: " + e.Message);
        }
    }

    void OnDestroy()
    {
        if (stream != null)
            stream.Close();
        if (client != null)
            client.Close();
    }
}
