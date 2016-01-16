using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Game
{
    #region Properties
    public IEnumerable<Player> Players { get; set; }
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

