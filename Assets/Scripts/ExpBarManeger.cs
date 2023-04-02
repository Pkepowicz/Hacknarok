using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarManeger : MonoBehaviour
{
    public Image[] expGreen;
    private int greenDragonExp = 8;
    public Image[] expPurple;
    private int purpleDragonExp = 7;
    public Image[] expRed;
    private int redDragonExp = 3;

    void Start()
    {
        // Disable all elements in each bar
        foreach (Image element in expGreen)
        {
            element.enabled = false;
        }
        foreach (Image element in expPurple)
        {
            element.enabled = false;
        }
        foreach (Image element in expRed)
        {
            element.enabled = false;
        }

        // Show the specified number of elements in each bar 
        for (int i = 0; i < greenDragonExp; i++)
        {
            if (i < expGreen.Length)
            {
                expGreen[i].enabled = true;
            }
        }
        for (int i = 0; i < purpleDragonExp; i++)
        {
            if (i < expPurple.Length)
            {
                expPurple[i].enabled = true;
            }
        }
        for (int i = 0; i < redDragonExp; i++)
        {
            if (i < expRed.Length)
            {
                expRed[i].enabled = true;
            }
        }
    }

    void Update()
    {
        
        // Hide all elementsin each bar
        foreach (Image element in expGreen)
        {
            element.enabled = false;
        }
        foreach (Image element in expPurple)
        {
            element.enabled = false;
        }
        foreach (Image element in expRed)
        {
            element.enabled = false;
        }

        // Show the specified number of elements in each bar 
        for (int i = 0; i < greenDragonExp; i++)
        {
            if (i < expGreen.Length)
            {
                expGreen[i].enabled = true;
            }
        }
        for (int i = 0; i < redDragonExp; i++)
        {
            if (i < expRed.Length)
            {
                expRed[i].enabled = true;
            }
        }
        for (int i = 0; i < purpleDragonExp; i++)
        {
            if (i < expPurple.Length)
            {
                expPurple[i].enabled = true;
            }
        }
    }
}

