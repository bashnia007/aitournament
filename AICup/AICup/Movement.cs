﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class Movement
    {
        #region Privates
        private Dictionary<ConsoleKey, Action> _functions;
        #endregion

        #region Properties
        public Player Player { get; set; }
        #endregion

        #region Constructors
        public Movement()
        {
            Initialize();
        }
        #endregion

        #region Methods
        public void Listen()
        {
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey();
                if (_functions.ContainsKey(key.Key))
                {
                    var action = _functions[key.Key];
                    action();
                }
            }
        }

        private void Initialize()
        {
            _functions = new Dictionary<ConsoleKey, Action>();
            _functions.Add(ConsoleKey.LeftArrow, MoveLeft);
            _functions.Add(ConsoleKey.RightArrow, MoveRight);
            _functions.Add(ConsoleKey.UpArrow, MoveUp);
            _functions.Add(ConsoleKey.DownArrow, MoveDown);
        }
        
        #endregion

        #region DictionaryActions
        private void MoveLeft()
        {
            var newPosition = new Position(Player.Position.X - 1, Player.Position.Y);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = Player.Position };
                Player.Position = newPosition;
                Environment.SetGameObject(Player, empty);
            }
            else
            {
                Environment.SetGameObject(Player);
            }
        }

        private void MoveRight()
        {
            var newPosition = new Position(Player.Position.X + 1, Player.Position.Y);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = Player.Position };
                Player.Position = newPosition;
                Environment.SetGameObject(Player, empty);
            }
            else
            {
                Environment.SetGameObject(Player);
            }
        }

        private void MoveUp()
        {
            var newPosition = new Position(Player.Position.X, Player.Position.Y - 1);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = Player.Position };
                Player.Position = newPosition;
                Environment.SetGameObject(Player, empty);
            }
            else
            {
                Environment.SetGameObject(Player);
            }
        }

        private void MoveDown()
        {
            var newPosition = new Position(Player.Position.X, Player.Position.Y + 1);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = Player.Position };
                Player.Position = newPosition;
                Environment.SetGameObject(Player, empty);
            }
            else
            {
                Environment.SetGameObject(Player);
            }
        }
        #endregion
    }
}