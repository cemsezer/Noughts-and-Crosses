namespace NoughtsAndCrosses.Console
{
    public class Cell
    {
        public Player? Value { get; set; }

        public bool HasValue
        {
            get { return Value != null; }
        }
    }
}