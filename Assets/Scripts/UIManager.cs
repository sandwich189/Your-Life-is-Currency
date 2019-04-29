using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager gm;
    public GameObject HUD;
    private Player player;

    private GameObject resourceHolder;
    private TextMeshProUGUI txt_wood;
    private TextMeshProUGUI txt_stone;
    private TextMeshProUGUI txt_iron;
    private TextMeshProUGUI txt_gold;

    private GameObject woodHolder;
    private GameObject stoneHolder;
    private GameObject ironHolder;
    private GameObject goldHolder;

    private int ui_wood = 0;
    private int ui_stone = 0;
    private int ui_iron = 0;
    private int ui_gold = 0;

    private int wood_hp, stone_hp, iron_hp, gold_hp;

    public GameObject woodHpHolder;
    public GameObject stoneHpHolder;
    public GameObject ironHpHolder;
    public GameObject goldHpHolder;

    public GameObject woodHpIcon;
    public GameObject stoneHpIcon;
    public GameObject ironHpIcon;
    public GameObject goldHpIcon;

    public TextMeshProUGUI soulHpText;

    public GameObject gameOver;

    public TextMeshProUGUI num_dayText;

    private int w = 0, s = 0, i = 0, g = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject.GetComponent<Player>();
        HUD = this.gameObject.transform.GetChild(0).gameObject;
        resourceHolder = HUD.transform.GetChild(0).gameObject;

        woodHolder = resourceHolder.transform.GetChild(0).gameObject;
        stoneHolder = resourceHolder.transform.GetChild(1).gameObject;
        ironHolder = resourceHolder.transform.GetChild(2).gameObject;
        goldHolder = resourceHolder.transform.GetChild(3).gameObject;

        wood_hp = player.wood_hp;
        stone_hp = player.stone_hp;
        iron_hp = player.iron_hp;
        gold_hp = player.gold_hp;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        DrawHP();
    }

    // Update is called once per frame
    void Update()
    {
        wood_hp = player.wood_hp;
        stone_hp = player.stone_hp;
        iron_hp = player.iron_hp;
        gold_hp = player.gold_hp;

        ui_wood = player.wood;
        ui_stone = player.stone;
        ui_iron = player.iron;
        ui_gold = player.gold;

        txt_wood = woodHolder.GetComponent<TextMeshProUGUI>();
        txt_wood.text = "Wood: " + ui_wood;

        txt_stone = stoneHolder.GetComponent<TextMeshProUGUI>();
        txt_stone.text = "Stone: " + ui_stone;

        txt_iron = ironHolder.GetComponent<TextMeshProUGUI>();
        txt_iron.text = "Iron: " + ui_iron;

        txt_gold = goldHolder.GetComponent<TextMeshProUGUI>();
        txt_gold.text = "Gold: " + ui_gold;

        num_dayText.text = "DAY: " + gm.num_day;
    }

    public void DrawHP()
    {
        if(wood_hp < player.wood_hp)
        {
            w++;
            GameObject whp = Instantiate(woodHpIcon, new Vector3(woodHpIcon.transform.position.x, woodHpIcon.transform.position.y - (w* 40)), Quaternion.identity);
            whp.transform.SetParent(woodHpHolder.transform);
        }

        if(stone_hp < player.stone_hp)
        {
            s++;
            GameObject shp = Instantiate(stoneHpIcon, new Vector3(stoneHpIcon.transform.position.x, stoneHpIcon.transform.position.y - (s*40)), Quaternion.identity);
            shp.transform.SetParent(stoneHpHolder.transform);
        }

        if(iron_hp < player.iron_hp)
        {
            i++;
            GameObject ihp = Instantiate(ironHpIcon, new Vector3(ironHpIcon.transform.position.x, ironHpIcon.transform.position.y - (i * 40)), Quaternion.identity);
            ihp.transform.SetParent(ironHpHolder.transform);
        }

        if(gold_hp < player.gold_hp)
        {
            g++;
            GameObject ghp = Instantiate(goldHpIcon, new Vector3(goldHpIcon.transform.position.x, goldHpIcon.transform.position.y - (g * 40)), Quaternion.identity);
            ghp.transform.SetParent(goldHpHolder.transform);
        }

        soulHpText.text = "x " + player.heartslot;
    }

    public void RemoveHP()
    {
        if (!gm.gameOver)
        {
            if (wood_hp > player.wood_hp)
            {
                if (woodHpHolder.transform.GetChild(w).gameObject != null)
                {
                    Destroy(woodHpHolder.transform.GetChild(w).gameObject);
                    w--;
                }

            }

            if (stone_hp > player.stone_hp)
            {
                if (stoneHpHolder.transform.GetChild(w).gameObject != null)
                {
                    Destroy(stoneHpHolder.transform.GetChild(s).gameObject);
                    s--;
                }

            }

            if (iron_hp > player.iron_hp)
            {
                if (ironHpHolder.transform.GetChild(w).gameObject != null)
                {
                    Destroy(ironHpHolder.transform.GetChild(i).gameObject);
                    i--;
                }

            }

            if (gold_hp > player.gold_hp)
            {
                if (goldHpHolder.transform.GetChild(g).gameObject != null)
                {
                    Destroy(goldHpHolder.transform.GetChild(g).gameObject);
                    g--;
                }

            }
        }
    }

}
