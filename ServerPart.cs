class Server
{
    TcpListener Listener; // listener
 
    // Server start
    public Server(int Port)
    {
        // create TCPListener for port
        Listener = new TcpListener(IPAddress.Any, Port);
        Listener.Start(); // start
 
        // infinity cycle
        while (true)
        {
            // new clients
            Listener.AcceptTcpClient();
        }
    }
 
    // stop server
    ~Server()
    {
        // if listener = true
        if (Listener != null)
        {
            // stop
            Listener.Stop();
        }
    }
 
    static void Main(string[] args)
    {
        // new server on 80 port
        new Server(8888);
    }
}
