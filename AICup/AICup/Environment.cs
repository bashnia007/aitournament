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
    }
}
