using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class EnemyManager
    {
        #region Privates

        private List<IEnemy> _enemies;
        private Dictionary<BotActions, Action<IGameObject>> _botActions;
        #endregion

        #region Constructors

        public EnemyManager()
        {
            Init();
        }
        #endregion

        #region Methods
        public void TickProcess()
        {
            foreach (var enemy in _enemies)
            {
                enemy.GetInputData(Environment.InputData);
                var botAction = enemy.CreateAction();
                if (_botActions.ContainsKey(botAction))
                {
                    var action = _botActions[botAction];
                    action(enemy);
                }
            }
        }
        private void Init()
        {
            _enemies = new List<IEnemy>();
            _botActions = new Dictionary<BotActions, Action<IGameObject>>();
            CreateEnemies();
        }
        private void CreateEnemies()
        {
            var rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                var bot = new SimpleBot
                {
                    Position = new Position(rnd.Next(Constants.MapWidth), rnd.Next(Constants.MapHeight))
                };
                _enemies.Add(bot);
                Environment.SetGameObject(bot);
            }
            FillActionDictionary();
        }

        private void FillActionDictionary()
        {
            _botActions.Add(BotActions.MoveDown, MoveDown);
            _botActions.Add(BotActions.MoveUp, MoveUp);
            _botActions.Add(BotActions.MoveLeft, MoveLeft);
            _botActions.Add(BotActions.MoveRight, MoveRight);
        }
        #endregion
        
        #region DictionaryActions
        private void MoveLeft(IGameObject bot)
        {
            var newPosition = new Position(bot.Position.X - 1, bot.Position.Y);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = bot.Position };
                bot.Position = newPosition;
                Environment.SetGameObject(bot, empty);
            }
            else
            {
                Environment.SetGameObject(bot);
            }
        }

        private void MoveRight(IGameObject bot)
        {
            var newPosition = new Position(bot.Position.X + 1, bot.Position.Y);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = bot.Position };
                bot.Position = newPosition;
                Environment.SetGameObject(bot, empty);
            }
            else
            {
                Environment.SetGameObject(bot);
            }
        }

        private void MoveUp(IGameObject bot)
        {
            var newPosition = new Position(bot.Position.X, bot.Position.Y - 1);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = bot.Position };
                bot.Position = newPosition;
                Environment.SetGameObject(bot, empty);
            }
            else
            {
                Environment.SetGameObject(bot);
            }
        }

        private void MoveDown(IGameObject bot)
        {
            var newPosition = new Position(bot.Position.X, bot.Position.Y + 1);
            if (Environment.IsInField(newPosition))
            {
                var empty = new Empty { Position = bot.Position };
                bot.Position = newPosition;
                Environment.SetGameObject(bot, empty);
            }
            else
            {
                Environment.SetGameObject(bot);
            }
        }
        #endregion
    }
}
