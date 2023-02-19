using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    //Implement max and min level once determined
    
    [SerializeField] Sprite[] island_state;
    public int lvl = 0;
    private GameObject[] components;
    
    // Start is called before the first frame update
    void Start()
    {
        //lvl = PlayerPrefs.GetInt("level");

        components = GetComponentsInChildren<GameObject>();

        foreach (var obj in components)
            if (obj.name == "Island")
            {
                obj.GetComponent<Image>().sprite = island_state[lvl];
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
