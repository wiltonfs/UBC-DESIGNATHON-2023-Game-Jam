using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    //The Cook, The Sailmaker, The Cartographer, The Carpenter, The Navigator, The Wizard


    //Movement mechanics
    [SerializeField] private float moveSpeed = 2;
    private float sprintMultiplier = 2.0f;
    private bool hasSprint = true;

    private bool hasRam = true;
    private bool hasCompass = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }

    public float GetSprintMultiplier()
    {
        return sprintMultiplier;
    }

    public bool Sprint()
    {
        return hasSprint;
    }

    public bool Ram()
    {
        return hasRam;
    }

    public bool Compass()
    {
        return hasCompass;
    }
}
