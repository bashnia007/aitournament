using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public interface IEnemy : IGameObject
    {
        void GetInputData(InputData inputData);
        BotActions CreateAction();
    }
}
