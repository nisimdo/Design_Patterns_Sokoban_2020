using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;

namespace Sokoban.Infrastructure.Interfaces.Bridge.Implementation
{
    public interface IMovementImplementer<T>
    {
        bool hasKey(T info);
        DirectionEnum ConvertToDirection(T info);
        T DirectionToType(DirectionEnum direction);
    }
}
