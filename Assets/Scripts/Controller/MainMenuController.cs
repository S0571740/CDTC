using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tutorial;

    public void newGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        tutorial.SetActive(false);
    }

    public void openTutorial()
    {
        mainMenu.SetActive(false);
        tutorial.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }
}
