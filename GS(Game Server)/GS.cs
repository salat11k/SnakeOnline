using GS_Game_Server_.Exceptions_GS;
using System.Net;
using System.Net.Sockets;

namespace GS_Game_Server_
{
    public class GS
    {
        private readonly int _maxClientCount;

        private TcpListener _listner;
        private Queue<TcpClient> _clients;

        public bool IsClientsCountIsMax { get; private set; } = false;
        public IReadOnlyCollection<TcpClient> Clients { get => _clients; } 

        public GS(string ip, int port, int maxClientCount)
        {
            if (IPAddress.TryParse(ip, out var address))
            {
                InitServer(address, port);
                _maxClientCount = maxClientCount;
            }
            else
                throw new IpParseExcepion("We couldn`t parse ip that was transferred to method");
        }

        public async Task StartServer()
        {
            try
            {
                _listner.Start();

                while(_clients.Count < 2)
                {
                    var client = await _listner.AcceptTcpClientAsync();
                    _clients.Enqueue(client);
                }

                
                IsClientsCountIsMax = true;
            }
            catch(Exception ex)
            {
                
            }
        }
        public async Task SendDataForAllClients(byte[] data)
        {
            foreach (var client in _clients) 
            {
                var strem =  client.GetStream();
                await strem.WriteAsync(data);
            }

        }
        public void PutDataFromAllClients()
        {
            var buffer = new byte[1024];
            var bytesFromAllClients = new List<byte[]>();

            foreach (var client in _clients)
            {
                var strem = client.GetStream();
                Task.Run(() => strem.ReadAsync(buffer));
                bytesFromAllClients.Add(buffer);
            }
        }


        private void InitServer(IPAddress IP,int port) 
        {
            _listner = new(IP, port);
            _clients = new();
        }
        

    }
}
