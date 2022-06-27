using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameManager  gameManager;
    public void StartGame()
    {
        gameManager.isSpawn = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
