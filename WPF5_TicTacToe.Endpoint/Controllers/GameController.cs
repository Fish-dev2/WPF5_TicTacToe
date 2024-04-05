
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
        public IEnumerable<Game> ReadAll()
        {
            List<Game> l = new List<Game>();
            for (int i = 0; i < this.logic.Table.Count; i++)
            {
                l.Add(new Game(i, this.logic.Table[i]));
            }
            return l;
        }

        [HttpGet("{id}")]
        public Game Read(int id)
        {
            return new Game(id, this.logic.Table[id]);
        }

        [HttpPost]
        public void Create([FromBody] Game value)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void Put([FromBody] Game value)
        {
            this.logic.PutLetter(value.letter, value.coord);
            this.hub.Clients.All.SendAsync("TableUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var coordToDelete = new Game(id, this.logic.Table[id]);
            this.logic.DeleteCoord(id);
            this.hub.Clients.All.SendAsync("TableDeleted", coordToDelete);
        }
    }
}

