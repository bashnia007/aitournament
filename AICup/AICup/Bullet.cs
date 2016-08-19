using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class Bullet : IGameObject
    {
        public Position Position { get; set; }
        public ObjectsEnum Symbol => ObjectsEnum.Bullet;
    }
}
