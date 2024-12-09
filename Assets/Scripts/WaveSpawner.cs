using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer <= 0)
        {
            //spawn an enemy
            if(enemiesToSpawn.Count >0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);//spawn first enemy in list
                enemiesToSpawn.RemoveAt(0);//remove it
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
        
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; //gives fixed time between enemies
        waveTimer = waveDuration; //wave duration is read only?
    }

    public void GenerateEnemies()
    {
        /*Creates a temporary liist of enemies to generate
         grab a random enemy
        affordabe?
        if yes, at to list and deduct cost
        rinse and repeat

        no points left, leave the loop
         */
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue>0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue<=0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]

public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
