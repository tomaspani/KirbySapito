using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject typeOfBullet;
    [SerializeField] public float shotDelay;

    public float shotCounter;

    public Transform pointToShoot;
    public bool isFiring;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = shotDelay;
                
                Instantiate(typeOfBullet, pointToShoot.position, pointToShoot.rotation);
            }
        }
        else
        {
            shotCounter -= Time.deltaTime;

        }
    }
}
