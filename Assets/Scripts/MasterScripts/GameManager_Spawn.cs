using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Spawn : MonoBehaviour
{
    private Vector2[] spawnLocation;
    Electron electron;
    public Electron electronPrefab;

    private int randomLocation;

    void Start()
    {
        spawnLocation = new Vector2[10];
        InitializeSpawnLocations();
        Spawn();
    }

    public void Spawn()
    {
        randomLocation = Random.Range(0, 9);
        electron = Instantiate(electronPrefab, spawnLocation[randomLocation], Quaternion.identity) as Electron;

    }
    public void InitializeSpawnLocations()
    {
        spawnLocation[0] = new Vector2(-15.3f, 1f);
        spawnLocation[1] = new Vector2(-16f, 5f);
        spawnLocation[2] = new Vector2(-3.83f, 7.4f);
        spawnLocation[3] = new Vector2(-5.33f, 1f);
        spawnLocation[4] = new Vector2(-12f, 9f);
        spawnLocation[5] = new Vector2(8f, 1f);
        spawnLocation[6] = new Vector2(2.67f, 3.1f);
        spawnLocation[7] = new Vector2(-15.83f, 4.6f);
        spawnLocation[8] = new Vector2(4.67f, 11f);
        spawnLocation[9] = new Vector2(11.67f, 5.95f);
    }
}

