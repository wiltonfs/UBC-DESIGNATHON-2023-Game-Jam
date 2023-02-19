using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Upgrades
{

    //The Cook, The Sailmaker, The Cartographer, The Carpenter, The Navigator, The Wizard
    //Movement mechanics
    public static float moveSpeed = 10f;
    public static float sprintMultiplier = 1.8f;
    public static bool hasSprint = true;
    public static int capacity = 25;

    public static bool hasSpyglass = false;
    public static bool hasCompass = true;
    public static bool hasWizard = false;
    public static int population = 1;

    public static void Reset()
    {
        capacity = 15;
        moveSpeed = 10f;
        sprintMultiplier = 1.8f;
        hasSprint = true;
        hasSpyglass = false;
        hasCompass = false;
        hasWizard = false;
        population = 1;
    }
    public static void Recruit(int passenger)
    {
        switch (passenger)
        {
            case -1:
                //Nothing
                break;
            case 1:
                // Wizard
                hasWizard = true;
                sprintMultiplier = 2.4f;
                break;
            case 2:
                // Captain
                hasCompass = true;
                break;
            case 3:
                // Cartographer
                hasSpyglass = true;
                break;
            case 4:
                //Builder
                capacity = 25;
                break;
            default:
                // code block
                break;
        }
    }
}
