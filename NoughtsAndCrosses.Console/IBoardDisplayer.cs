namespace NoughtsAndCrosses
{
    public interface IBoardDisplayer
    {
        void DisplayBoard(Board board);
        void DisplayWinner(Player player);
        void DisplayNoWinner();
    }
}