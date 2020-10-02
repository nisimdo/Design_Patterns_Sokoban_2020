using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Bridge.Implementation;

namespace Sokoban.Implementor.Movement
{
    public class KeyboardImplementor : IMovementImplementer<char>
    {
        private IDictionary<char, DirectionEnum> m_DirectionMapping;
        private IDictionary<DirectionEnum, char> m_typeToDir;

        public KeyboardImplementor()
        {
            m_DirectionMapping = new Dictionary<char, DirectionEnum>()
            {
                {'w', DirectionEnum.UP },
                {'W', DirectionEnum.UP },
                {'d', DirectionEnum.RIGHT },
                {'D', DirectionEnum.RIGHT },
                {'s', DirectionEnum.DOWN },
                {'S', DirectionEnum.DOWN },
                {'a', DirectionEnum.LEFT },
                {'A', DirectionEnum.LEFT },
                {'u', DirectionEnum.UNDO },
                {'U', DirectionEnum.UNDO },
            };
            m_typeToDir = new Dictionary<DirectionEnum, char>()
            {
                {DirectionEnum.UP, 'W' },
                {DirectionEnum.RIGHT, 'D' },
                {DirectionEnum.DOWN, 'S' },
                {DirectionEnum.LEFT, 'A'},
                {DirectionEnum.UNDO, 'U' },
            };
        }
        public DirectionEnum ConvertToDirection(char info)
        {
            return m_DirectionMapping[info];
        }

        public char DirectionToType(DirectionEnum direction)
        {
            return m_typeToDir[direction];
        }

        public bool hasKey(char info)
        {
            return m_DirectionMapping.ContainsKey(info);
        }
    }
}
