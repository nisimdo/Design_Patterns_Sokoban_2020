
using Sokoban.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.AbstractFactory;
using Sokoban.Infrastructure.Interfaces.Bridge;
using Sokoban.Infrastructure.Interfaces.Bridge.Abstraction;
using Sokoban.Infrastructure.Interfaces.Proxy;
using Sokoban.Infrastructure.Interfaces.State;
using Sokoban.Infrastructure.Interfaces.Template;

namespace Sokoban.Template
{
    public class SokobanGameTemplate : ISokobanGameTemplate
    {
        private IBoardDisplayer m_boardDisplayer;       // The displayer of the Board
        private ISubjectMovementListener m_movemnetListener;   // The listener that will wait for input
        private IWorkerStateMachine m_stateMachine;     // The state machine that handles the game logic
        private ISokobanLevelTemplate m_levelTemplate;  // The template that will handle the curent level
        private ILevelProvider m_levelProvider;         // The level provider
        private int m_difficulty;                       // The current difficulty of the level
        public SokobanGameTemplate()
        {
            // Storing the services
            m_stateMachine = DependencyContainer.Instance.Resolve<IWorkerStateMachine>();
            m_levelProvider = Dependency.DependencyContainer.Instance.Resolve<ILevelProvider>();
            var ioFactory = DependencyContainer.Instance.Resolve<IOutputInputFactory>();    // Getting the factory
            m_boardDisplayer = ioFactory.CreateDisplayer();
            m_movemnetListener = ioFactory.CreateMovementListener();
            m_levelTemplate = new SokobanLevelTemplate();               // Creating the level template

            m_movemnetListener.Attach(this);            // Adding the current template as an observer to the input
        }

        public void StartGame()
        {
            m_difficulty = 1;       // Setting the Intial Difficulty
            StartLevel();           // Starting a new Level  
            m_movemnetListener.StartListen();       // Start listening to the input channel
        }
        private void StartLevel()
        {
            if (m_levelProvider.HasLevel(m_difficulty))
            {
                var level = m_levelProvider.GetLevel(m_difficulty); // Getting the level from the provider
                if (level != null)
                {
                    m_levelTemplate.LoadLevel(level); // Loading the Level to the template
                    m_boardDisplayer.ClearBoard(); // Clearing the Board
                    m_boardDisplayer.DisplayBoard(m_levelTemplate.GetBoard()); // Displaying the board of the game
                    m_stateMachine.SetBoard(m_levelTemplate.GetBoard()); // Storing the board
                    m_stateMachine.SetWorker(m_levelTemplate.GetWorker()); // Storing the worker
                }
            }
            else
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            m_movemnetListener.StopListen();       // Stoping listening to the input channel
        }

        // What happends when an input is recieved
        public void Update(DirectionEnum direction)
        {
            bool madeMove = m_stateMachine.TryMakeMove(direction);  // Trying to make move

            if (madeMove)
            {
                m_boardDisplayer.ClearBoard();                  // Clearing the Board
                m_boardDisplayer.DisplayBoard(m_levelTemplate.GetBoard());
                if (m_levelTemplate.isLevelDone())
                {
                    m_difficulty++;
                    StartLevel();           // Starting a new Level
                }
            }
        }
    }
}
