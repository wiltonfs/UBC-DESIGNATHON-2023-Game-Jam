using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int SECONDS_SURVIVED;
    public static string PLAYER_NAME;

    public static float MAIN_VOLUME;
    public static float MUSIC_VOLUME;
    public static float FX_VOLUME;


    public static string[] PLAYERS;
    public static int[] SCORES;
    public static int LEADER_BOARD_SIZE = 3;

    public static void LOAD_PLAYER_PREFS()
    {
        SCORES = new int[LEADER_BOARD_SIZE];
        PLAYERS = new string[LEADER_BOARD_SIZE];
        for (int i = 0; i < LEADER_BOARD_SIZE; i++)
        {
            SCORES[i] = PlayerPrefs.GetInt("PLAYER_SCORE" + i);
            PLAYERS[i] = PlayerPrefs.GetString("PLAYER_NAME" + i, "[N/A]");
        }

        MAIN_VOLUME = PlayerPrefs.GetFloat("MAIN_VOLUME", 0.75f);
        MUSIC_VOLUME = PlayerPrefs.GetFloat("MUSIC_VOLUME", 1f);
        FX_VOLUME = PlayerPrefs.GetFloat("FX_VOLUME", 1f);
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
        return false;
    }

    public static void SAVE_PLAYER_PREFS()
    {
        return;
        // TODO: remove return statement to save player preferences
        for (int i = 0; i < LEADER_BOARD_SIZE; i++)
        {
            PlayerPrefs.SetInt("PLAYER_SCORE" + i, SCORES[i]);
            PlayerPrefs.SetString("PLAYER_NAME" + i, PLAYERS[i]);
        }

        PlayerPrefs.SetFloat("MAIN_VOLUME", MAIN_VOLUME);
        PlayerPrefs.SetFloat("MUSIC_VOLUME", MUSIC_VOLUME);
        PlayerPrefs.SetFloat("FX_VOLUME", FX_VOLUME);

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
