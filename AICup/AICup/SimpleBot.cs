using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class SimpleBot : IEnemy
    {
        #region Privates
        private InputData _inputData;
        #endregion
        #region Properties
        public Position Position { get; set; }

        public ObjectsEnum Symbol => ObjectsEnum.Enemy;
        #endregion

        #region Constructors

        public SimpleBot()
        {
            
        }
        #endregion

        #region IEnemy
        public void GetInputData(InputData inputData)
        {
            _inputData = inputData;
        }

        public BotActions CreateAction()
        {
            var enemyPosition = _inputData.PlayerPosition;
            if (enemyPosition.X == Position.X)
            {
                return enemyPosition.Y <= Position.Y ? BotActions.MoveUp : BotActions.MoveDown;
            }
            if (enemyPosition.Y == Position.Y)
            {
                return enemyPosition.X <= Position.X ? BotActions.MoveLeft : BotActions.MoveRight;
            }
            var deltaX = enemyPosition.X - Position.X;
            var deltaY = enemyPosition.Y - Position.Y;
            if (Math.Abs(deltaX) < Math.Abs(deltaY))
            {
                return deltaX < 0 ? BotActions.MoveUp : BotActions.MoveDown;
            }
            else
            {
                return deltaY < 0 ? BotActions.MoveLeft : BotActions.MoveRight;
            }
            return BotActions.Sleep;
        }

        public void Destroy()
        {
        }
        #endregion
    }
}
