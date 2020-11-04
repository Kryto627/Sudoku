using System;
using System.Collections.Generic;

namespace Sudoku {

    public class Cell {

        public bool isFinal;
        public int state;
        public int[] possibleStates;

        public readonly int cellX, cellY;
        public readonly Grid grid;
        public readonly int[] states;

        public Cell(int cellX, int cellY, Grid grid, int[] states) {
            this.cellX = cellX;
            this.cellY = cellY;
            this.grid = grid;
            this.states = states;
        }

        public void Populate() {

            List<int> currentStates = new List<int>();

            currentStates.AddRange(states);

            for (int x = 0; x < grid.size; x++) {
                for (int y = 0; y < grid.size; y++) {
                    if (cellX == x || cellY == y || Math.Floor(x / 3f) == Math.Floor(cellX / 3f) && Math.Floor(y / 3f) == Math.Floor(cellY / 3f)) {
                        if (grid.GetCell(x, y).isFinal) {
                            currentStates.Remove(grid.GetCell(x, y).state);
                        }
                    }
                }
            }

            possibleStates = currentStates.ToArray();
        }

        public void SetRandomPossibleState() {
            if (!isFinal && possibleStates.Length > 0) {
                Random random = new Random();
                state = possibleStates[random.Next(0, possibleStates.Length)];
                isFinal = true; 
            }
        }

        public override string ToString() {
            return isFinal ? state.ToString() : "#";
        }
    }
}