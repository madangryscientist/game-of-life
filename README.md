# game-of-life
Conways game of life
## Notes
* Game of Life is not good candidate for displaying my ability to you OOP, SOLID or Design patterns.
* I haven't done desktop app since University, but the core algorithm is fine. 
* Perform of determining neighbors is not good, but I wanted to separate the logic of determining neighbors and whether a cell should life.

## Overview
The Game of Life, also known simply as Life is a cellular automaton devised by
the British mathematician John Horton Conway. It is two dimensional universe in
which patterns evolve through time.

The &quot;game&quot; is a zero-player game, meaning that its evolution is determined by its
initial state, requiring no further input. One interacts with the Game of Life by
creating an initial configuration and observing how it evolves, or, for advanced
&quot;players&quot;, by creating patterns with particular properties.

### The Requirements

Create A square grid which contains cells that are either alive or dead.
The behaviour of each cell is dependent only on the state of its eight immediate
neighbours, according to the following rules:
Live cells:
1. a live cell with zero or one live neighbours will die.
2. a live cell with two or three live neighbours will remain alive
3. a live cell with four or more live neighbours will die.
Dead cells:
1. a dead cell with exactly three live neighbours becomes alive
2. in all other cases a dead cell will stay dead.

