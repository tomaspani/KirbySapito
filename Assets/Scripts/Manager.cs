using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private float _enemysToKillInWave;
    [SerializeField] private float _waves;

    private float currentWave;
    private float currentEnemies;


    private void Start()
    {
        currentEnemies = _enemysToKillInWave;
    }

    private void Update()
    {
        if (currentEnemies == 0)
        {
            if(currentWave == _waves)
            {
                //Abrir puerta
            }
            else
            {
                currentWave++;
                currentEnemies = _enemysToKillInWave;
            }
            
        }
    }
}
