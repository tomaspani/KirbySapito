using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succ : MonoBehaviour
{
    public float range;
    public GameObject tongue;


    private void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.forward, range))
        {
            Debug.Log("Toque algo");
        }
        Succing();
    }


    private void Succing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //tongue.gameObject.transform.position = new Vector3(1f, 4.57f, Mathf.Lerp(5.48f, 28f, 0.1f));
            tongue.gameObject.transform.localScale = new Vector3 (1, 1, Mathf.Lerp(0f, 500f, 0.1f));
        }
        else
        {
            tongue.gameObject.transform.localScale = new Vector3(1, 1, Mathf.Lerp(tongue.gameObject.transform.localScale.z, 1, 0.1f));
        }
    }
}
