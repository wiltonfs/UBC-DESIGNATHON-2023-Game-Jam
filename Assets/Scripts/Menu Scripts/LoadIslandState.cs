using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadIslandState : MonoBehaviour
{
    //Implement max and min level once determined
    private int lvl = 0;
    [SerializeField] Sprite[] island_state; 
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = island_state[lvl];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
