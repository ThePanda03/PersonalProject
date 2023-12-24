using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loading the Scene which is next in the build index
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Quits the game with debug to make sure it works in engine
    public void ExitGame() 
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
