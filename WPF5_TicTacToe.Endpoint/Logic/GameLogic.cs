namespace WPF5_TicTacToe.Endpoint.Logic
{
    public class GameLogic
    {
		private char[] table;

		//012
		//345
		//678
		public char[] Table
		{
			get { return table; }
			set { table = value; }
		}

		public GameLogic()
		{
			ResetTable();
		}
		public bool GameEnd
		{
			get
			{
				for (int i = 0; i < table.Length; i++)
				{
					if (table[i] == ' ')
					{
						return false;
					}
				}
				return true;
			}
		}

		//coords 0: sor, coords 1: oszlop
		public bool PutLetter(char letter, int coord)
		{
			if (letter != 'X' && letter != 'O')
			{
				return false;
			}
			if (table[coord] != ' ')
			{
				return false;
			}
			table[coord] = letter;
			return true;
		}
		public void ResetTable()
		{
			table = new char[9];
			for (int i = 0; i < table.Length; i++)
			{
				table[i] = ' ';
			}
		}


	}
}
