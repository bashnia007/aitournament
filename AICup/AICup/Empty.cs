using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class Empty : IGameObject
    {
        public Position Position { get; set; }

        public ObjectsEnum Symbol => ObjectsEnum.Empty;
    }
}
