using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Upgrades
{

    //The Cook, The Sailmaker, The Cartographer, The Carpenter, The Navigator, The Wizard
    //Movement mechanics
    public static float moveSpeed = 10f;
    public static float sprintMultiplier = 2.0f;
    public static bool hasSprint = true;

    private static bool hasRam = true;
    public static bool hasCompass = true;
    public static bool hasWizard = false;

    public static void Reset()
    {
        moveSpeed = 10f;
        sprintMultiplier = 2.0f;
        hasSprint = true;
        hasRam = false;
        hasCompass = false;
        hasWizard = false;
    }
    public static void Recruit(ArrayList passengers)
    {
        foreach (int p in passengers)
        {
            switch (p)
            {
                case 1:
                    // Wizard
                    hasWizard = true;
                    break;
                case 2:
                    // Captain
                    hasCompass = true;
                    break;
                default:
                    // code block
                    break;
            }
        }
    }
}
