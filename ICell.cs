
namespace Sudoku {

    public interface ICell<T> {

        bool IsFinal { get; }

        T State { get; }

        T[] PossibleStates { get; }

        void Populate(IGrid<T> grid, int x, int y, T[] registerStates);

        void SetFinalState(int index);
    }
}