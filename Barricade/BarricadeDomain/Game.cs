using BarricadeDomain.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

public class Game
{
    #region Properties
    public IEnumerable<Player> Players { get; set; }
    #endregion

    #region Constructor
    public Game(List<Player> players)
    {
        // TODO: check if max players (4) is not overruled and min 2.
        Players = players;
        InitGame();
    }
    #endregion

    #region Methods
    private void InitGame()
    {
        // Get all colors
        List<Color> colors = new List<Color>();
        foreach (Color color in Enum.GetValues(typeof(Color)))
	    {
		    colors.Add(color);
	    }

        // Set player colors
        for (int i = 0; i < Players.Count(); i++)
        {
            Players.ElementAt(i).Color = colors.ElementAt(i);
        }

        // Parse level
        XmlDocument xmlFile = new XmlDocument();
        xmlFile.Load(@"..\..\..\BarricadeData\Default.xml");
        LevelParser levelParser = new LevelParser(xmlFile);

    }

    public void Play()
	{
		// Game loop here?
	}

	public int ThrowDice()
	{
        Random r = new Random();
        return r.Next(1, 7);
	}

	public void ChangeTurn()
	{
		// Change turn here
	}
    #endregion

}

