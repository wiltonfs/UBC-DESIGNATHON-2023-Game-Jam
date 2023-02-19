using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalIslandDisplay : MonoBehaviour
{
    private ArrayList houses;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        GetHouses();
        RenderHouses();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetHouses()
    {
        houses = new ArrayList();

        foreach (Transform child in transform)
        {
            houses.Add(child.GetComponent<SpriteRenderer>());
        }

        Debug.Log("" + houses.Count + " houses");

    }

    private void RenderHouses()
    {
        Debug.Log("" + Upgrades.population + " population");
        for (int i = 0; i < houses.Count; i++)
        {
            ((SpriteRenderer)houses[i]).enabled = (i < Upgrades.population);

        }

    }
}
