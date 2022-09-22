using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    private Vector3 _nextSpawnPoint;


    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, _nextSpawnPoint, Quaternion.identity);
        _nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    void Start()
    {
        for(int i = 0; i < 15; i++)
            SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
