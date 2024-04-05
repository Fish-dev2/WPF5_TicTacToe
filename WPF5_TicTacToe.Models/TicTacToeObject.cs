namespace WPF5_TicTacToe.Models
{
    public class TicTacToeObject
    {
        public TicTacToeObject(int coord, char letter)
        {
            this.coord = coord;
            this.letter = letter;
        }
        public TicTacToeObject()
        {
            
        }

        public int coord { get; set; }
        public char letter { get; set; }

    }
}