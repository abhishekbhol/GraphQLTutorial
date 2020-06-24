using GraphQLTestProject.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQLTestProject
{
    public class Data
    {
        private List<Player> playerList { get; set; }

        private static int IdCount = 10;

        public Data()
        {
            playerList = new List<Player>();

            playerList.Add(new Player
            {
                Id = 1,
                Name = "KL Rahul",
                JerseyNumber = 1,
                Rating = "EE"
                //Team = Team.India
            });

            playerList.Add(new Player
            {
                Id = 2,
                Name = "Sentenar",
                JerseyNumber = 88,
                Rating = "EE"
                //Team = Team.NewZealand
            });

            playerList.Add(new Player
            {
                Id = 3,
                Name = "Clark",
                JerseyNumber = 13,
                Rating = "ME"
                //Team = Team.Australia
            });

            playerList.Add(new Player
            {
                Id = 4,
                Name = "Virat",
                JerseyNumber = 18,
                Rating = "Good"
                //Team = Team.India
            });
        }

        public Player GetPlayerById(int id)
        {
            var p = playerList.Where(_ => _.Id == id).FirstOrDefault();
            return p;
        }

        public List<Player> GetPlayers()
        {
            return playerList;
        }

        public Player AddPlayer(Player p)
        {
            p.Id = IdCount++;
            playerList.Add(p);
            return p;
        }
    }
}
