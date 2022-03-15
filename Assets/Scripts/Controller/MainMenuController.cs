using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;

    void Start()
    {
        
    }

    public void newGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void options()
    {
        mainMenu.SetActive(false);
    }



    public void back()
    {
        mainMenu.SetActive(true);
    }

    public void save()
    {

    }

    public void highScores()
    {

    }

    public void quit()
    {
        Application.Quit();
    }
}
