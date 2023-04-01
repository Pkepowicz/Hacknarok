using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Dragon : Fighter
{
    public string dragonType;
    
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    protected float damage = 1, attackSpeed = 1; // time between attacks, 0.5 means 0.5 time between each attack

    public List<GameObject> projectilesSpawnPoints;
    
    [SerializeField] public GameObject spawnPointParent;

    private int level = 1;
    private int experience = 0;

    private int[] levelRequirements = { 100, 150, 200, 250, 300, 350, 400, 450, 500, 550 };
    

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < spawnPointParent.transform.childCount; i++)
        {
            projectilesSpawnPoints.Add(spawnPointParent.transform.GetChild(i).gameObject);
        }
    }


    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            ShootProjectile();
        }
    }

    protected void ShootProjectile()
    {
        foreach (GameObject point in projectilesSpawnPoints)
        {
            Instantiate(projectilePrefab, point.transform.position, Quaternion.identity);
        }
        
    }

    public void AddXp(int xp)
    {
        experience += xp;
        if(experience >= levelRequirements[level - 1])
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (level < levelRequirements.Length)
        {
            level++;
            Debug.Log("Level up! Now i'm lvl: " + level);
            TriggerUpgrade(level);
        }
        else
        {
            Debug.Log("I'm Alrady max lvl!");
        }
    }

    protected virtual void TriggerUpgrade(int lvl)
    {
        Debug.Log("setting upgrade for lvl: " + lvl);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Debug.Log("You got hit by an emeny, you should take damage");
        }

    }


}
