using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayControler : MonoBehaviour
{
    GameObject pauseMenu;
    private void Awake() 
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }
    public void PauseGame()
    {   
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void PauseToRestart()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
}
