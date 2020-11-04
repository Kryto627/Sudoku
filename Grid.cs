using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku {

    public class Grid {

        public readonly int size;
        public readonly Cell[,] cells;
        public readonly List<Cell> cellList;

        public Grid(int size, int[] states) {
            this.size = size;
            cells = new Cell[size, size];
            cellList = new List<Cell>();
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    cells[x, y] = new Cell(x, y, this, states);
                    cellList.Add(cells[x, y]);
                }
            }
        }

        public void PopulateCells() {
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    cells[x, y].Populate();
                }
            }
        }

        public void SolveRandomCells(int amount) {
            for (int i = 0; i < amount; i++) {
                PopulateCells();
                Random random = new Random();
                Cell randomCell = cellList.Where(c => !c.isFinal).OrderBy(c => random.Next()).FirstOrDefault();
                randomCell?.SetRandomPossibleState();
            }
        }

        public void SolveSingleRandomCell() {
            PopulateCells();
            Cell randomCell = cellList.Where(c => !c.isFinal).OrderBy(c => c.possibleStates.Length).FirstOrDefault();
            randomCell?.SetRandomPossibleState();
        }

        public Cell GetCell(int x, int y) {
            if (IsWithinGrid(x, y)) {
                return cells[x, y];
            }

            return null;
        }

        public bool IsWithinGrid(int x, int y) {
            return x >= 0 && y >= 0 & x < size && y < size;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            for (int y = 0; y < size; y++) {
                for (int x = 0; x < size; x++) {
                    builder.Append(cells[x, y]);
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}