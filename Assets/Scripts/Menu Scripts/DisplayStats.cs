using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    // Start is called before the first frame update
    private int gameTime;
    private Text test;
    void Start()
    {
        gameTime = DataManager.SECONDS_SURVIVED;
        test = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime < 60)
        {
            test.text = "You Survived for: " + gameTime + " seconds";
        }
        else
        {
            test.text = "You Survived for: " + gameTime / 60 + " minutes and " + gameTime % 60 + " seconds";
        }
    }
}
