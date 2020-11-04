
namespace Sudoku {

    public interface IGrid<T> {

        int Size { get; }

        ICell<T>[,] Cells { get; }

        ICell<T> GetCell(int x, int y);

        void Solve();
    }
}