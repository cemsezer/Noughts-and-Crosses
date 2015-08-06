namespace NoughtsAndCrosses
{
    /// <summary>
    /// Holds the current status of a cell in the game board
    /// </summary>
    public class Cell
    {
        public Player? Value { get; set; }

        public bool HasValue
        {
            get { return Value != null; }
        }
    }
}