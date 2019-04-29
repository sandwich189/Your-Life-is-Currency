using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enableGraphics;
    public Player player;
    public UIManager ui;

    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        enableGraphics.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.wood_hp <= 0|| player.stone_hp <= 0 || player.gold_hp <= 0 || player.iron_hp <= 0)
        {
            player.enabled = false;
            ui.gameOver.SetActive(true);
            ui.HUD.SetActive(false);

            gameOver = true;
        }
    }


    public void ExitGame()
    {

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
