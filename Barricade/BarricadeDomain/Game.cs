using BarricadeDomain.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BarricadeData;

public class Game
{
    #region Properties
    public Player activePlayer { get; set; }
    public IEnumerable<Player> Players { get; set; }

    public List<IField> Fields;
    #endregion

    #region Constructor
    public Game(List<Player> players)
    {
        Players = players;
        InitGame();
    }
    #endregion

    #region Methods
    private void InitGame()
    {
        // Get and parse level
        Level level = new Level("Default");
        LevelParser levelParser = new LevelParser(level.GetLevelXml());
        Fields = levelParser.AllFields;

        // Get all colors
        List<Color> colors = new List<Color>();
        foreach (Color color in Enum.GetValues(typeof(Color)))
	    {
		    colors.Add(color);
	    }

        // Set player settings
        for (int i = 0; i < Players.Count(); i++)
        {
            // Set color
            Players.ElementAt(i).Color = colors.ElementAt(i);

            // Set start fields
            switch (i)
            {
                case 0:
                    Players.ElementAt(i).StartFields = levelParser.StartFieldsPlayerOne;
                    break;
                case 1:
                    Players.ElementAt(i).StartFields = levelParser.StartFieldsPlayerTwo;
                    break;
                case 2:
                    Players.ElementAt(i).StartFields = levelParser.StartFieldsPlayerThree;
                    break;
                case 3:
                    Players.ElementAt(i).StartFields = levelParser.StartFieldsPlayerFour;
                    break;
                default:
                    Players.ElementAt(i).StartFields = levelParser.StartFieldsPlayerOne;
                    break;
            }

            // Add pawns
            List<Pawn> pawns = new List<Pawn>();
            for (int j = 0; j < 4; j++)
            {
                Pawn newPawn = new Pawn { Color = colors.ElementAt(i) };
                int coordx = Players.ElementAt(i).StartFields.ElementAt(j).CoordX;
                int y = Players.ElementAt(i).StartFields.ElementAt(j).CoordY;
                IField startField = levelParser.AllFields.Where(x => x.CoordX == Players.ElementAt(i).StartFields.ElementAt(j).CoordX && x.CoordY == Players.ElementAt(i).StartFields.ElementAt(j).CoordY).First();
                newPawn.Position = startField;
                startField.Moveables.Add(newPawn);
                pawns.Add(newPawn);
            }
            Players.ElementAt(i).Pawns = pawns;

            
        }

        // Selected starting player
        Random r = new Random();
        activePlayer = Players.ElementAt(r.Next(0, Players.Count()));

    }

    public Boolean validMove(IField old,IField newField,int steps)
    {
        for (int i = 0; i < steps; i++)
        {
        }
        return false;
    }

    public void Play()
	{
		while(true)
        {
            var input = Console.ReadLine();
        }
	}

	public int ThrowDice()
	{
        Random r = new Random();
        return r.Next(1, 7);
	}

	public void ChangeTurn()
	{
        for (int i = 0; i < Players.Count(); i++)
        {
            if(Players.ElementAt(i) == activePlayer)
            {
                activePlayer = i == (Players.Count() - 1) ? Players.ElementAt(0) : Players.ElementAt(i+1);
                break;
            }
        }
	}

    public Pawn ChoosePawn(int nr)
    {
        Pawn selected = activePlayer.ChoosePawn(nr);
        return selected;
    }

    public void PlacePawn()
    {
        activePlayer.PlacePawn();
    }
    #endregion

}