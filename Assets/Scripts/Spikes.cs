using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private float _damage = 10;

    void Start()
    {
        StartCoroutine(Go());
    }
    
    IEnumerator Go()
    {
        while(true)
        {
            var number = Random.Range(3, 8);
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(number);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<HealthManager>().TakeDamage(_damage);
        }
    }

}
