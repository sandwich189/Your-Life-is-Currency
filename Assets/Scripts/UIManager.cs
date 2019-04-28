using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject ui;
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

    public int ui_wood = 0;
    public int ui_stone = 0;
    public int ui_iron = 0;
    public int ui_gold = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject.GetComponent<Player>();
        ui = this.gameObject.transform.GetChild(0).gameObject;
        resourceHolder = ui.transform.GetChild(0).gameObject;

        woodHolder = resourceHolder.transform.GetChild(0).gameObject;
        stoneHolder = resourceHolder.transform.GetChild(1).gameObject;
        ironHolder = resourceHolder.transform.GetChild(2).gameObject;
        goldHolder = resourceHolder.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
