using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private int _enemysToKillInWave;
    [SerializeField] private int _waves;

    public Transform door;

    private int _currentWave = 1;
    private int currentEnemies;

    

    private void Start()
    {
        currentEnemies = _enemysToKillInWave;
    }

    private void Update()
    {
        if (currentEnemies == 0)
        {
            if(_currentWave == _waves)
            {
                OpenDoor();
            }
            else
            {
                _currentWave++;
                currentEnemies = _enemysToKillInWave;
            }
            
        }
    }

    public void EnemyDown()
    {
        currentEnemies--;
    }


    public int getCurrentWave()
    {
        return _currentWave;
    }

    public int getWaves()
    {
        return _waves;
    }

    private void OpenDoor()
    {
        if (door.transform.position.x < 6f)
            door.transform.position += Vector3.right * 5f * Time.deltaTime;
    }
}
