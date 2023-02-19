using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsLoader : MonoBehaviour
{
    //Implement max and min level once determined
    
    [SerializeField] Sprite[] island_state;
    public int lvl = 0;
    // Start is called before the first frame update
    void Start()
    {
        //lvl = PlayerPrefs.GetInt("level");
        GetComponent<Image>().sprite = island_state[lvl];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
