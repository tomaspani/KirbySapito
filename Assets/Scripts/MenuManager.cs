using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene("Juego");
    }

    public void HowToPlay()
    {
        //SceneManager.LoadScene("Controles");
    }

    public void Try()
    {
        SceneManager.LoadScene("Prueba");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
