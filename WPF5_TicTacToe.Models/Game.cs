namespace WPF5_TicTacToe.Models
{
    public class Game
    {
        public Game(int coord, char letter)
        {
            this.coord = coord;
            this.letter = letter;
        }
        public Game()
        {
            
        }

        public int coord { get; set; }
        public char letter { get; set; }

    }
}