using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Factory;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Factory
{
    public delegate BasicBoardComponent BoardComponentFactoryMethod(int row, int col);
    public class BoardComponentFactory : IBoardComponentFactory
    {
        private IDictionary<ComponentsEnum, BoardComponentFactoryMethod> factory;

        public BoardComponentFactory()
        {
            factory = new Dictionary<ComponentsEnum, BoardComponentFactoryMethod>()
            {
                { ComponentsEnum.EMPTY_CELL, (row, col) => {return new Cell(row, col); } },
                { ComponentsEnum.TARGET_CELL, (row, col) => {return new Cell(row, col, true); } },
                { ComponentsEnum.WALL, (row, col) => {return new Wall(row, col); } },
                { ComponentsEnum.PACKAGE, (row, col) => {
                    Cell parent = new Cell(row, col);       // Creating the cell that will be the parent
                    Package package = new Package(parent);  // Creating the package object
                    parent.SetMovableOccupant(package);     // Setting that the package is in the cell
                    return parent;
                } },
                { ComponentsEnum.FACTORY_WORKER, (row, col) => {
                    Cell parent = new Cell(row, col);       // Creating the cell that will be the parent
                    FactoryWorker worker = new FactoryWorker(parent);  // Creating the worker object
                    parent.SetMovableOccupant(worker);     // Setting that the worker is in the cell
                    return parent;
                } },
            };
        }
        public BasicBoardComponent Create(ComponentsEnum a_moveableEnum, int row, int col)
        {
            BoardComponentFactoryMethod factoryMethod = null;
            if (!factory.TryGetValue(a_moveableEnum, out factoryMethod))
                throw new Exception($"No factory method was found for ${a_moveableEnum}");
            return factoryMethod(row, col);            // Creating the Object
        }
    }
}
