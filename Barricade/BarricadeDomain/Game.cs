﻿using BarricadeDomain.Helpers;
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

        // Create player pawns
        foreach (Player player in Players)
        {
            List<Pawn> pawns = new List<Pawn>();
            for (int i = 0; i < 4; i++)
            {
                Pawn newPawn = new Pawn {Color = player.Color};
                pawns.Add(newPawn);
            }
            player.Pawns = pawns;
        }

        // Selected starting player
        Random r = new Random();
        activePlayer = Players.ElementAt(r.Next(0, Players.Count()));

        // Get and parse level
          Level level = new Level("Default");
          LevelParser levelParser = new LevelParser(level.GetLevelXml());
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

    public void ChoosePawn(int nr)
    {
        Pawn selected = activePlayer.ChoosePawn(nr);
    }

    public void PlacePawn()
    {
        activePlayer.PlacePawn();
    }
    #endregion

}

