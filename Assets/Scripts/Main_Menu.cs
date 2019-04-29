using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject how;
    private bool inmenu = true;

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void howtoplay()
    {
        if (inmenu)
        {
            inmenu = false;
            menu.SetActive(false);
            how.SetActive(true);
        }
        else
        {
            inmenu = true;
            menu.SetActive(true);
            how.SetActive(false);
        }
    }
}
