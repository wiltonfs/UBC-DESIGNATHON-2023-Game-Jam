using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalIslandDisplay : MonoBehaviour
{
    private ArrayList houses;

    [SerializeField] SpriteRenderer[] characterHouses;

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
    }

    private void RenderHouses()
    {
        for (int i = 0; i < houses.Count; i++)
        {
            ((SpriteRenderer)houses[i]).enabled = (i < Upgrades.population);

        }
        
        characterHouses[0].enabled = Upgrades.hasWizard;
        characterHouses[1].enabled = Upgrades.hasCompass;
        characterHouses[2].enabled = Upgrades.hasSpyglass;
        characterHouses[3].enabled = Upgrades.hasCarpenter;


    }
}
