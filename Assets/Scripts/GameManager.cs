using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enableGraphics;
    public Player player;
    public UIManager ui;
    public EnemyManager em;

    public bool day = true, night = false;
    public int num_day;

    private float timebtwday = 0;
    public float dayDuration = 60;

    private float timebtwnight = 0;
    public float nightDuration = 30;

    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        enableGraphics.SetActive(true);
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        timebtwday = dayDuration;
        timebtwnight = nightDuration;
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

        if (timebtwday <= 0)
        {
            day = false;
            night = true;
            timebtwday = dayDuration;
        }
        
        if(day)
        {
            timebtwday -= Time.deltaTime;
        }

        if (timebtwnight <= 0)
        {
            day = true;
            night = false;
            timebtwnight = nightDuration;
            num_day += 1;
        }
        
        if(night)
        {
            timebtwnight -= Time.deltaTime;
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
