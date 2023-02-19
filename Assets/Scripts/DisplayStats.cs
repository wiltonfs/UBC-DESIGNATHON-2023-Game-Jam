using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    // Start is called before the first frame update
    private int gameTime = 30;
    private Text test;
    void Start()
    { 
        test = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        test.text = "You Survived for: " + gameTime + " seconds";
    }
}
