using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class EnemyManager
    {
        List<IEnemy> enemies = new List<IEnemy>();
        public void CreateEnemies()
        {
            enemies.Add(new SimpleBot());
            enemies.Add(new SimpleBot());
            enemies.Add(new SimpleBot());
            enemies.Add(new SimpleBot());
        }

        public void StartProcess()
        {
            var inputData = new InputData();
            foreach(var enemy in enemies)
            {
                enemy.GetInputData(inputData);
                var action = enemy.CreateAction();
                action();
            }
        }
    }
}
