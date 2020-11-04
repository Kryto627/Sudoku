using System;
using System.Threading;

namespace Sudoku {

    public static class Start {

        public static void Main() {

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Grid grid = new Grid(9, numbers);
            grid.SolveRandomCells(9);

            while (true) {
                Thread.Sleep(500);
                grid.SolveSingleRandomCell();
                Console.Clear();
                Console.Write(grid);
            }
        }
    }
}
