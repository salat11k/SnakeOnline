using GS_Game_Server_;
using ServerOnlineSnake.GameProcess;
using Services;

namespace ServerOnlineSnake
{
    public class Server
    {
        private GameController _gameController;
        private GS _serverUtilites;

        public Server(string ip, int port,int maxClientCount)
        {
            _gameController = new(32, 32, 2);
            _gameController.OnMoveEnded += SendInfo;
            _serverUtilites = new(ip,port,maxClientCount);
        }

        public async Task StartServer()
        {
            await _serverUtilites.StartServer();
            Console.WriteLine("Server was started");
        }
        public void StartGame()
        {
            _gameController.StartGame();
            Console.WriteLine("Game was started");
        }

        private void SendInfo(List<Snake> snakes)
        {
            Task.Run(() => _serverUtilites.SendDataForAllClients(DataSerializer.SerializeToByte(snakes)));
            Console.WriteLine("Data was sended");
        }
    }
}
