using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public GameObject camerapos;

    void Update()
    {
        transform.position = camerapos.transform.position;
    }
}
