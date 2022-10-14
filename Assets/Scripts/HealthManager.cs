using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    public Image myBar;

    internal void Initalize()
    {
        _health = _maxHealth;
    }

    void TakeDamage()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Spikes spike = other.gameObject.GetComponent<Spikes>();

        if (spike)
        {
            //spike._damage --> como entro si es privado??
            _health -= 5;
        }

        myBar.fillAmount = _health / _maxHealth;
    }

}
