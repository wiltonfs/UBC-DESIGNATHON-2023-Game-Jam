using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.SUBMIT_SCORE())
        {
            //HIGH SCORE THINGS HERE
            Debug.Log("New high score!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
