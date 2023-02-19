using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
