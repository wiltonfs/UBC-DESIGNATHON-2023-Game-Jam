using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalIslandDisplay : MonoBehaviour
{
    private ArrayList houses;

    [SerializeField] SpriteRenderer[] characterHouses;
    [SerializeField] Image[] characterHeads;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        GetHouses();
        RenderHouses();
        RenderCharacters();
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

    private void RenderCharacters()
    {
        for (int i = 0; i < characterHeads.Length; i++)
        {
            characterHeads[i].color = Color.black;
        }
        
        if (Upgrades.hasWizard)
        {
            characterHeads[0].color = Color.white;
        }

        if (Upgrades.hasCompass)
        {
            characterHeads[1].color = Color.white;
        }

        if (Upgrades.hasSpyglass)
        {
            characterHeads[2].color = Color.white;
        }

        if (Upgrades.hasCarpenter)
        {
            characterHeads[3].color = Color.white;
        }



    }
}
