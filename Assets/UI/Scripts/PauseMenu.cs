using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Variables for different Ui objects
    public GameObject pauseMenu;
    public GameObject Crosshair;
    //tells us wether game is paused or not 
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //setting Ui objects to true or false on start
        pauseMenu.SetActive(false);
        Crosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Runs different commands depending on if the game is paused 
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(isPaused) 
            { 
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    //Sets Ui obj to true/false and turns off the internal timer 
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Crosshair.SetActive(false);
        
    }
    //Sets Ui obj to true/false and turns the internal timer back on
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Crosshair.SetActive(true);
        
    }
    //changes scene back to main menu and turns internal timer back on
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }
    //Quits the application
    public void QuitGame()
    {
        Application.Quit();
    }

}
