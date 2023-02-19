using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameSubmit : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private TextMeshProUGUI errorDisplay;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.LOAD_PLAYER_PREFS();
    }

    // Update is called once per frame
    void Update()
    {
        if (errorDisplay.alpha > 0)
        {
            errorDisplay.alpha -= 0.5f * Time.deltaTime;
        }
        
    }

    public void SubmitName()
    {
        string name = inputField.text;

        //Name cleaning
        string cleanedName = "";

        for (int i = 0; i < name.Length; i++)
        {
            if (char.IsLetterOrDigit(name[i]))
            {
                cleanedName += name[i];
            }
        }
        name = cleanedName;

        inputField.text = name;


        if (name.Length < 11 && name.Length > 0)
        {
            DataManager.PLAYER_NAME = name;
            SceneManager.LoadScene("Title Screen");
        } 
        else
        {
            //Display error
            errorDisplay.alpha = 1.0f;
        }
    }
}
