using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private bool debug;

    void Start()
    {
        debug = gameManager.getDebug();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && debug)
        {
            gameManager.advance(0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && debug)
        {
            gameManager.advance(1);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && debug)
        {
            gameManager.advance(2);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && debug)
        {
            gameManager.advance(3);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameManager.pauseGame();
        }
    }
}