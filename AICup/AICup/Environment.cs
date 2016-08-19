using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public static class Environment
    {
        public static char[,] Map = new char[Constants.MapHeight, Constants.MapWidth];
        public static List<IGameObject> AvaivableObjects = new List<IGameObject>();
        public static List<Bullet> Bullets = new List<Bullet>();
        public static InputData InputData { get; set; }

        public static void CreateMap()
        {
            for (int i = 0; i < Constants.MapHeight; i++)
            {
                for (int j = 0; j < Constants.MapWidth; j++)
                {
                    Map[i, j] = (char) ObjectsEnum.Empty; 
                }
            }
        }

        public static void SetGameObject(IGameObject go, IGameObject empty = null)
        {
            if(empty != null) DrawGameObject(empty);
            Map[go.Position.Y, go.Position.X] = (char) go.Symbol;
            DrawGameObject(go);
        }

        public static bool IsInField(Position position)
        {
            return position.X >= Constants.MinWidth && position.X < Constants.MinWidth + Constants.MapWidth &&
                position.Y >= Constants.MinHeight && position.Y < Constants.MinHeight + Constants.MapHeight;
        }

        private static void DrawGameObject(IGameObject go)
        {
            Console.SetCursorPosition(go.Position.X, go.Position.Y);
            Console.Write((char) go.Symbol);
            Console.SetCursorPosition(go.Position.X, go.Position.Y);
        }

        public static void UpdateBullets()
        {
            foreach (var bullet in Bullets)
            {
                if (bullet.Direction == Direction.Down)
                {
                    var newPosition = new Position(bullet.Position.X, bullet.Position.Y + 1);
                    if (IsInField(newPosition))
                    {
                        var empty = new Empty { Position = bullet.Position };
                        bullet.Position = newPosition;
                        SetGameObject(bullet, empty);
                    }
                }
                if (bullet.Direction == Direction.Up)
                {
                    var newPosition = new Position(bullet.Position.X, bullet.Position.Y - 1);
                    if (IsInField(newPosition))
                    {
                        var empty = new Empty { Position = bullet.Position };
                        bullet.Position = newPosition;
                        SetGameObject(bullet, empty);
                    }
                }
                if (bullet.Direction == Direction.Right)
                {
                    var newPosition = new Position(bullet.Position.X + 1, bullet.Position.Y);
                    if (IsInField(newPosition))
                    {
                        var empty = new Empty { Position = bullet.Position };
                        bullet.Position = newPosition;
                        SetGameObject(bullet, empty);
                    }
                }
                if (bullet.Direction == Direction.Left)
                {
                    var newPosition = new Position(bullet.Position.X - 1, bullet.Position.Y);
                    if (IsInField(newPosition))
                    {
                        var empty = new Empty { Position = bullet.Position };
                        bullet.Position = newPosition;
                        SetGameObject(bullet, empty);
                    }
                }
            }
        }

        public static void CheckToKill(Bullet bullet)
        {

        }
    }
}
