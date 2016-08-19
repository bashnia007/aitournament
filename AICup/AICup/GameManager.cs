using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AICup
{
    public class GameManager
    {
        public void Start()
        {
            Environment.CreateMap();
            Environment.InputData = new InputData();
            PrintMap();
            Settings();
            var thread = new Thread(StartListen);
            thread.Start();
        }

        private void PrintMap()
        {
            for (int i = 0; i < Constants.MapHeight; i++)
            {
                for (int j = 0; j < Constants.MapWidth; j++)
                {
                    Console.Write(Environment.Map[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void StartListen()
        {
            var movement = new Movement();
            movement.Player = new Player();
            Environment.SetGameObject(movement.Player);
            var enemyManager = new EnemyManager();
            while (true)
            {
                movement.Listen();
                enemyManager.TickProcess();
                Environment.UpdateBullets();
                Thread.Sleep(Constants.ThreadSleepTime);
                Environment.UpdateBullets();
            }
        }

        private void Settings()
        {
            Console.CursorVisible = false;
        }

        private void CreateEnemy()
        {
            
        }
    }
}
