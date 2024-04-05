
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using WPF5_TicTacToe.Endpoint.Logic;
using WPF5_TicTacToe.Endpoint.Services;
using WPF5_TicTacToe.Models;

namespace WPF5_TicTacToe.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic logic;
        IHubContext<SignalRHub> hub;

        public GameController(IGameLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<TicTacToeObject> ReadAll()
        {
            List<TicTacToeObject> l = new List<TicTacToeObject>();
            for (int i = 0; i < this.logic.Table.Count; i++)
            {
                l.Add(new TicTacToeObject(i, this.logic.Table[i]));
            }
            return l;
        }

        [HttpGet("{id}")]
        public TicTacToeObject Read(int id)
        {
            return new TicTacToeObject(id, this.logic.Table[id]);
        }

        [HttpPost]
        public void Create([FromBody] TicTacToeObject value)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void Put([FromBody] TicTacToeObject value)
        {
            this.logic.PutLetter(value.letter, value.coord);
            this.hub.Clients.All.SendAsync("TableUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var coordToDelete = new TicTacToeObject(id, this.logic.Table[id]);
            this.logic.DeleteCoord(id);
            this.hub.Clients.All.SendAsync("TableDeleted", coordToDelete);
        }
    }
}

