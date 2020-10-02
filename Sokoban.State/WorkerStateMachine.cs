using Sokoban.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Command;
using Sokoban.Infrastructure.Interfaces.State;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model;
using Sokoban.Infrastructure.Model.Interfaces;

namespace Sokoban.State
{
    public class WorkerStateMachine : IWorkerStateMachine
    {
        private Dictionary<DirectionEnum, int[]> movementDic;       // The dictionary that converts direction to change in row and col
        private IBoardComponentVisitor<bool> movementVisitor;   // The vistor used as a state machine
        private State m_currentState;                           // The current state of the board, worker and last direction played
        private IMovementCommandService m_movementService;      // The movment service 
        public WorkerStateMachine()
        {
            m_movementService = DependencyContainer.Instance.Resolve<IMovementCommandService>();
            m_currentState = new State();
            movementDic = new Dictionary<DirectionEnum, int[]>()
            {
                {DirectionEnum.UP, new int[]{-1, 0}},
                {DirectionEnum.DOWN, new int[]{1, 0}},
                {DirectionEnum.RIGHT, new int[]{0, 1}},
                {DirectionEnum.LEFT, new int[]{0, -1}}
            };
            movementVisitor = new MovementVisitor(m_currentState, m_movementService);
        }

        public void SetBoard(BasicBoardComponent[,] board)
        {
            m_currentState.Board = board;
        }

        public void SetWorker(FactoryWorker worker)
        {
            m_currentState.Worker = worker;
        }

        public bool TryMakeMove(DirectionEnum direction)
        {
            if (direction == DirectionEnum.UNDO)
                return m_movementService.UndoMove();            // Doing an undo

            m_currentState.LastDirection = movementDic[direction];      // Parsing the direction enum to actual movemnent

            return movementVisitor.Visit(m_currentState.Worker);        // Trying to make a move
        }

        public void UndoMove()
        {
            m_movementService.UndoMove();                   // We are Undoing the last move
        }

        public class State
        {
            public FactoryWorker Worker { get; set; }         // The state and position of the worker in the game
            public BasicBoardComponent[,] Board { get; set; }         // The full board of the game
            public int[] LastDirection { get; set; }          // The last direction played

        }
        public class MovementVisitor : IBoardComponentVisitor<bool>
        {
            // Directions that appear in the directions array
            public const int ROW = 0;
            public const int COL = 1;

            private int NumberOfBoxesPushed;
            private State m_currentState;            // The direction the player goes
            private IMovementCommandService m_movementService;      // Service used to make movement on the board
            public MovementVisitor(State a_state, IMovementCommandService moveService)
            {
                m_currentState = a_state;           // Storing the state
                NumberOfBoxesPushed = 0;            // Set the defualt number of packages pushed
                m_movementService = moveService;    // Storing the move service
            }

            public bool Visit(IBoardComponent component)
            {
                return component.Accept(this);
            }

            public bool Visit(Cell cell)
            {
                var occupant = cell.GetMovableOccupant();
                if (occupant == null)
                    return true;

                // If we can move from the occupant forward
                return occupant.Accept(this);
            }

            public bool Visit(FactoryWorker component)
            {
                NumberOfBoxesPushed = 0;            // Set the defualt number of packages pushed
                return TryMakeMove(component);             // Trying to make move
            }

            public bool Visit(Package component)
            {
                NumberOfBoxesPushed++;
                if (NumberOfBoxesPushed > 1)
                {
                    return false;       // can't push more than one
                }
                return TryMakeMove(component);             // Trying to make move
            }

            public bool Visit(Wall component)
            {
                return false;           // Return that a wall can't be moved to
            }

            public BasicBoardComponent NextComponent(Cell cell)
            {
                int newRow = cell.GetRow() + m_currentState.LastDirection[ROW];
                int newCol = cell.GetCol() + m_currentState.LastDirection[COL];

                return m_currentState.Board[newRow, newCol];
            }
            public void UndoMove()
            {

            }
            public bool TryMakeMove(IMovableComponent component)
            {
                var parent = component.getParent(); // Checking if a move from the parent is possible
                if (!IsMoveValid(parent))
                {
                    return false;                   // Return that worker can't move
                }
                var targetCell = NextComponent(parent); // Getting to the next location

                // Return if we can move to the mext cell (i.e. valid) and make move
                if (targetCell.Accept(this))    
                {
                    // Downcast the traget Cell to be a cell (since this is the only option to move)
                    m_movementService.MoveComponent(parent, (Cell)targetCell);

                    return true;
                }
                return false;
            }
            public bool IsMoveValid(BasicBoardComponent cell)
            {
                int newRow = cell.GetRow() + m_currentState.LastDirection[ROW];
                int newCol = cell.GetCol() + m_currentState.LastDirection[COL];

                if (newRow < 0 || newCol < 0)
                {
                    return false;
                }

                if(newRow >= m_currentState.Board.GetLength(0))
                {
                    return false;
                }

                if (newCol >= m_currentState.Board.GetLength(1))
                {
                    return false;
                }
                

                return true;
            }
        }
    }
}
