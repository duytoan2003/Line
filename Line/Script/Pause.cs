using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void PauseMenu(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home(){
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Main Menu");       
    }

    public void Resume(){
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
