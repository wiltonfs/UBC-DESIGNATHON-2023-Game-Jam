using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int SECONDS_SURVIVED;
    public static string PLAYER_NAME;


    public static string[] PLAYERS;
    public static int[] SCORES;
    public static int LEADER_BOARD_SIZE = 3;

    public static void LOAD_SCOREBOARD()
    {
        SCORES = new int[LEADER_BOARD_SIZE];
        PLAYERS = new string[LEADER_BOARD_SIZE];
        for (int i = 0; i < LEADER_BOARD_SIZE; i++)
        {
            SCORES[i] = PlayerPrefs.GetInt("PLAYER_SCORE" + i);
            PLAYERS[i] = PlayerPrefs.GetString("PLAYER_NAME" + i, "[N/A]");
        }
    }
    
    public static bool SUBMIT_SCORE() { 

        for (int i = 0; i < LEADER_BOARD_SIZE; i++)
        {
            if (SECONDS_SURVIVED > SCORES[i])
            {
                SlideScores(i);
                SCORES[i] = SECONDS_SURVIVED;
                PLAYERS[i] = PLAYER_NAME;
                return true;
            }
        }

        SaveScores();
        return false;
    }

    private static void SaveScores()
    {
        for (int i = 0; i < LEADER_BOARD_SIZE; i++)
        {
            PlayerPrefs.SetInt("PLAYER_SCORE" + i, SCORES[i]);
            PlayerPrefs.SetString("PLAYER_NAME" + i, PLAYERS[i]);
        }
        PlayerPrefs.Save();

    }

    private static void SlideScores (int insertion)
    {
        for (int i = LEADER_BOARD_SIZE-1; i > insertion; i--)
        {
            SCORES[i] = SCORES[i - 1];
            PLAYERS[i] = PLAYERS[i - 1];
        }
    }
}
