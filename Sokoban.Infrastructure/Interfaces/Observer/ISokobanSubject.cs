using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Infrastructure.Interfaces.Observer
{
    public interface ISokobanSubject<T>
    {
        void Attach(ISokobanObserver<T> observer);
        void Detach(ISokobanObserver<T> observer);
        void Notify(T payload);
    }
}
