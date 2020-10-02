using Sokoban.Dependency;
using Sokoban.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Factory;
using Sokoban.Infrastructure.Interfaces.Template;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Template
{
    public class SokobanLevelTemplate : ISokobanLevelTemplate
    {
        private BasicBoardComponent[,] m_board;       // The board Of The Game
        private FactoryWorker m_worker;               // The worker in the game
        private IBoardComponentFactory m_componentFactory;  // The component Factory
        private IFindFactoryWorkerVisitor m_WorkerFinder;  // The visitor that will help finding the worker
        private ILevelCompleteVisitor m_isLevelComplete;        // The visitor for checking if a level is complete

        public SokobanLevelTemplate()
        {
            m_componentFactory = DependencyContainer.Instance.Resolve<IBoardComponentFactory>();
            m_board = null;
            m_WorkerFinder = new FindFactoryWorkerVisitor();
            m_isLevelComplete = new LevelCompleteVistor();
        }
        public void LoadLevel(ComponentsEnum[,] level)
        {
            ClearBoard();       // Clearing the board from previous data
            m_board = new BasicBoardComponent[level.GetLength(0), level.GetLength(1)];
            ForeEachAction((row, col) => m_board[row, col] = m_componentFactory.Create(level[row, col], row, col));
            m_worker = FindWorker();
        }
        public BasicBoardComponent[,] GetBoard()
        {
            return m_board;
        }
        public FactoryWorker GetWorker()
        {
            return m_worker;
        }

        public bool isLevelDone()
        {
            m_isLevelComplete.ResetVisitor();   // Resetting the visitor
            ForeEachAction((row, col) => m_isLevelComplete.Visit(m_board[row, col]));
            return m_isLevelComplete.IsLevelComplete();     // Return of the level is complete
        }
        private void ClearBoard()
        {
            if(m_board != null)
            {
                ForeEachAction((row, col) => m_board[row, col] = null);
            }
            m_board = null;
        }

        private FactoryWorker FindWorker()
        {
            m_WorkerFinder.ResetFactoryWorker();
            ForeEachAction((row, col) =>m_WorkerFinder.Visit(m_board[row, col]));
            return m_WorkerFinder.GetFactoryWorker();
        }

        private void ForeEachAction(Action<int, int> action)
        {
            for (int row = 0; row < m_board.GetLength(0); row++)
            {
                for (int col = 0; col < m_board.GetLength(1); col++)
                {
                    action(row, col);
                }
            }
        }
    }
}
