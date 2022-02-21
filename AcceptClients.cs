using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
  public static void Main()
  {
    TcpListener server=null;
    try
    {
      // назначаем листенера на порту 13000
      Int32 port = 13000;
      IPAddress localAddr = IPAddress.Parse("127.0.0.1"); // нужно вписать IP вашего сервера

      // TcpListener server = new TcpListener(port);
      server = new TcpListener(localAddr, port);

      // стартуем сервер
      server.Start();

      // новый буфер
      Byte[] bytes = new Byte[256];
      String data = null;

      // цикл шобы подключение принимать
      while(true)
      {
        Console.Write("Waiting for a connection... ");

        // асепт регуестс
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Connected!");

        data = null;

        // берем то что нам приходит
        NetworkStream stream = client.GetStream();

        int i;

        // Loop to receive all the data sent by the client.
        while((i = stream.Read(bytes, 0, bytes.Length))!=0)
        {
          // декодируем
          data = System.Text.Encoding.Json.GetString(bytes, 0, i);
          Console.WriteLine("coords: {0}", data);
        }
        // Если вам больше не нужно соединение, грохните его с помощью client.Close();
      }
    }
    // в этом блоке кода рассматривается случай, если произошла ошибка
    catch(SocketException e)
    {
      Console.WriteLine("SocketException: {0}", e);
    }
    finally
    {
       // остановка приёма подключений новых клиентов
       server.Stop();
    }
  }
}
