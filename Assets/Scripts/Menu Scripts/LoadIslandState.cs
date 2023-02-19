using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadIslandState : MonoBehaviour
{
    [SerializeField] private GameObject[] island_state;
    private Dictionary<string, GameObject> island_state_dict;

    private void Awake()
    {
        foreach (GameObject building in island_state)
        {
            island_state_dict.Add(building.name, building);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (string building in DataManager.BUILDINGS)
        {
            island_state_dict[building].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
