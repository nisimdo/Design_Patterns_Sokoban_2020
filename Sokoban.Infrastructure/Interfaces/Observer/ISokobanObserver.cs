using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Sokoban.Infrastructure.Interfaces.Observer
{
    public interface ISokobanObserver<T>
    {
        void Update(T direction);
    }
}
