using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private float _enemysToKillInWave;
    [SerializeField] private int _waves;

    private int _currentWave = 1;
    private float _currentEnemies;


    public int getCurrentWave()
    {
        return _currentWave;
    }

    public int getWaves()
    {
        return _waves;
    }

    private void Start()
    {
        _currentEnemies = _enemysToKillInWave;
    }

    private void Update()
    {
        if (_currentEnemies == 0)
        {
            if(_currentWave == _waves)
            {
                //Abrir puerta
            }
            else
            {
                _currentWave++;
                _currentEnemies = _enemysToKillInWave;
            }
            
        }
    }
}
