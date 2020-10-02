using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Infrastructure.Interfaces.Command
{
    public interface ISokobanCommand
    {
        void Execute();
        void Undo();
    }
}
