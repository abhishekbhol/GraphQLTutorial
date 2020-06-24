using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTestProject.Types
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public int JerseyNumber { get; set; }
        //public Team Team { get; set; }
       
    }

    public enum Team
    {
        India,
        Australia,
        NewZealand,
        England,
        SouthAfrica
    }

    public class TeamEnum : EnumerationGraphType<Team>
    {
    }

    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType()
        {
            Name = "PlayerType";
            Description = "To get player Info";

            Field(_ => _.Id, nullable: true);
            Field(_ => _.Name, nullable: true);
            Field(_ => _.JerseyNumber, nullable: true);
            Field(_ => _.Rating, nullable: true);
            //Field(_ => _.Team, nullable: true);
        }
    }
}
