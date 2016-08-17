using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class SimpleBot : IEnemy, IGameObject
    {
        #region Privates
        private InputData _inputData;
        #endregion
        #region Properties
        public Position Position { get; set; }

        public ObjectsEnum Symbol => ObjectsEnum.Enemy;
        #endregion

        public void GetInputData(InputData inputData)
        {
            _inputData = inputData;
        }

        public Action CreateAction()
        {
            if (_inputData.PlayerPosition.X == Position.X) return new Action(Shoot);
            if (_inputData.PlayerPosition.Y == Position.Y) return new Action(Shoot);
            return new Action(Move);
        }

        private void Shoot()
        {

        }

        private void Move()
        {

        }
    }
}
