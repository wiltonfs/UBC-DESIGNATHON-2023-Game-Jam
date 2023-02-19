using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI betterLuckText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.enabled = false;
        betterLuckText.enabled = false;
        if (DataManager.SUBMIT_SCORE())
        {
            //HIGH SCORE THINGS HERE
            highScoreText.enabled = true;
            DataManager.SAVE_PLAYER_PREFS();
        } else
        {
            betterLuckText.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.fontSize = 30f + 2f * Mathf.Sin(Time.time * 4f);
    }
}
