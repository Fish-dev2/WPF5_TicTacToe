namespace WPF5_TicTacToe.Endpoint.Logic
{
    public class GameLogic
    {
		private char[,] table;

		public char[,] Table
		{
			get { return table; }
			set { table = value; }
		}

		public GameLogic()
		{
			table = new char[3, 3]
			{
				{' ',' ',' ' },
				{' ',' ',' ' },
				{' ',' ',' ' },
			};
		}

		//coords 0: sor, coords 1: oszlop
		public bool PutLetter(char letter, int[] coords)
		{
			if (coords.Length != 2)
			{
				return false;
			}
			if (letter != 'X' && letter != 'O')
			{
				return false;
			}
			if (table[coords[0], coords[1]] != ' ')
			{
				return false;
			}
			table[coords[0], coords[1]] = letter;
			return true;
		}

	}
}
