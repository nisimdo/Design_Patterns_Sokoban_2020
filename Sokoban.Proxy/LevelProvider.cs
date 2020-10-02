using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Proxy;

namespace Sokoban.Proxy
{
    public class LevelProvider : ILevelProvider
    {
        private IDictionary<int, string[]> m_database;      // The database of the levels
        private IDictionary<char, ComponentsEnum> m_dbToTypeConverter;   // The converter used to map a db character to a Component Enum 

        public LevelProvider()
        {
            m_database = new Dictionary<int, string[]>()
            {
                { 1, new string[]{
                    "XXXXXXXXX",
                    "XT___P_WX",
                    "XXXXXXXXX"
                } },
                { 2, new string[]{
                    "__XXX___",
                    "__XTX___",
                    "__X_XXXX",
                    "XXXP_PTX",
                    "XT_PWXXX",
                    "XXXXPX__",
                    "___XTX__",
                    "___XXX__"
                }},
                { 3, new string[]{
                    "XXXXXXXXX",
                    "XXX__XXXX",
                    "X_____P_X",
                    "X_X__XP_X",
                    "X_T_TXW_X",
                    "XXXXXXXXX"
                }}
            };

            m_dbToTypeConverter = new Dictionary<char, ComponentsEnum>()
            {
                {'X',  ComponentsEnum.WALL},
                {'_',  ComponentsEnum.EMPTY_CELL},
                {'P',  ComponentsEnum.PACKAGE},
                {'W',  ComponentsEnum.FACTORY_WORKER},
                {'T',  ComponentsEnum.TARGET_CELL}
            };
        }

        public ComponentsEnum[,] GetLevel(int difficulty)
        {
            string[] dbBoard;
            ComponentsEnum[,] formattedBoard;
            if (!m_database.TryGetValue(difficulty, out dbBoard))
                throw new Exception($"The Level Provider do not contain a level with dificulty of ${difficulty}");

            int rows = dbBoard.Length;
            int cols = dbBoard.FirstOrDefault().Length;

            formattedBoard = new ComponentsEnum[rows,cols];    // Creating the board
            for(int rowIndex=0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    char componentType = dbBoard[rowIndex][colIndex];
                    formattedBoard[rowIndex, colIndex] = m_dbToTypeConverter[componentType];
                }
            }
            return formattedBoard;      // Return the board
        }

        public bool HasLevel(int level)
        {
            return m_database.ContainsKey(level);
        }
    }
}
