using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Bridge.Implementation;

namespace Sokoban.Implementor.Movement
{
    public class NumberpadImplementor : IMovementImplementer<char>
    {
        private Dictionary<char, DirectionEnum> m_DirectionMapping;
        private IDictionary<DirectionEnum, char> m_typeToDir;

        public NumberpadImplementor()
        {
            m_DirectionMapping = new Dictionary<char, DirectionEnum>()
            {
                {'8', DirectionEnum.UP },
                {'6', DirectionEnum.RIGHT },
                {'2', DirectionEnum.DOWN },
                {'4', DirectionEnum.LEFT },
                {'0', DirectionEnum.UNDO }
            };
            m_typeToDir = new Dictionary<DirectionEnum, char>()
            {
                {DirectionEnum.UP, '8' },
                {DirectionEnum.RIGHT, '6' },
                {DirectionEnum.DOWN, '2' },
                {DirectionEnum.LEFT, '4'},
                {DirectionEnum.UNDO, '0' },
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
