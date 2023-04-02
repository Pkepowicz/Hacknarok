using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // uncomment to text gaining XP
        StartCoroutine(XPLoop());
    }

    public void GetXPFromMobKill(int xpAmount)
    {
        player.AddXp(xpAmount);
    }

    private IEnumerator XPLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GetXPFromMobKill(49);
            Debug.Log("Adding xp to Player");
        }
        
    }
    
}
