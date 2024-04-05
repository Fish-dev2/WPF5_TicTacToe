namespace WPF5_TicTacToe.Endpoint.Logic
{
    public interface IGameLogic
    {
        bool GameEnd { get; }
        List<char> Table { get; set; }

        void DeleteCoord(int coord);
        List<char> GetTable();
        char GetTable(int coord);
        bool PutLetter(char letter, int coord);
        void ResetTable();
    }
}