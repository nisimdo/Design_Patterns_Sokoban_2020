# Design_Patterns_Sokoban_2020
A final project in design patterns at BIU - Overview of all helpful design patterns implemented in C#

# Game Description
**Sokoban** is a puzzle video game in which the player pushes crates or boxes around in a warehouse, trying to get them to storage locations

The game is played on a board of squares, where each square is a floor or a wall. Some floor squares contain boxes, and some floor squares are marked as storage locations.

The player is confined to the board and may move horizontally or vertically onto empty squares (never through walls or boxes). The player can move a box by walking up to it and pushing it to the square beyond. Boxes cannot be pulled and cannot be pushed to squares with walls or other boxes. The number of boxes equals the number of storage locations. The puzzle is solved when all boxes are placed at storage locations.

The game is played on the Console and the display is as follows:

![alt text](https://github.com/nisimdo/Design_Patterns_Sokoban_2020/blob/main/Console.png?raw=true)

To run the program, compile the files and run the main function found in:
*Sokoban.Main*

# UML Diagram
![alt text](https://github.com/nisimdo/Design_Patterns_Sokoban_2020/blob/main/UML.png?raw=true)

# Used Patterns
* Dependency container (Singleton) - *IRegisterableService*
* Bootstrap Façade (Facade) - *BootstrapFacade*
* Level Template (Template) - *SokobanLevelTemplate*
* Game Template (Template) -  *SokobanGameTemplate*
* Level Provider (Proxy) - *LevelProvider*
* Board Component Factory (Factory) - *BoardComponentFactory*
* Basic Movement Listener (Observer) - *BasicMovementListener*
* Input Output Abstract Factory (Abstract Factory) - *ConsoleOutputInputFactory*
* Displayer and Key Input (Bridge) - *KeyboardImplementor*
* Command Service (Command) - *MovementCommandService*
* State Machine (State) - *WorkerStateMachine*
* Visitor (Visitor) - *FindFactoryWorkerVisitor*
