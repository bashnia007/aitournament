using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public interface IGameObject : IDisposable
    {
        ObjectsEnum Symbol { get; }
        Position Position { get; set; }
    }
}
