namespace WPF5_TicTacToe.Endpoint.Logic
{
    public class GameLogic
    {
		private List<char> table;

		//012
		//345
		//678
		public List<char> Table
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
				if (table.Contains(' '))
				{
					return false;
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
			table = new List<char>();
			for (int i = 0; i < 9; i++)
			{
				table.Add(' ');
			}
		}
		public List<char> GetTable()
		{
			return table;
		}
		public char GetTable(int coord)
		{
			return table[coord];
		}
		public void DeleteCoord(int coord)
		{
			table[coord] = ' ';
		}


	}
}
