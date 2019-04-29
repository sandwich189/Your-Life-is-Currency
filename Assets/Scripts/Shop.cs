using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private Player player;
    public UIManager ui;

    public TMP_Dropdown convertInOption;
    public TMP_Dropdown convertOutOption;

    public TextMeshProUGUI inputtext;
    public TextMeshProUGUI outputtext;

    public TextMeshProUGUI exchangetable;

    public int num_woodToStone = 3;
    public int num_stoneToIron = 5;
    public int num_ironToGold = 3;

    private bool in_wood = true, in_stone = false, in_iron = false, in_gold = false;
    private bool out_wood = true, out_stone = false, out_iron = false, out_gold = false;

    private int input = 0;
    private int result = 0;

    private int in_opt_value = 0;
    private int out_opt_value = 0;

    public int price_woodheart = 0;
    public int price_stoneheart = 0;
    public int price_ironheart = 0;
    public int price_goldheart = 0;
    public int price_soulheart = 0;

    public int price_sell_woodheart = 0;
    public int price_sell_stoneheart = 0;
    public int price_sell_ironheart = 0;
    public int price_sell_goldheart = 0;

    public TextMeshProUGUI txt_price_woodheart;
    public TextMeshProUGUI txt_price_stoneheart;
    public TextMeshProUGUI txt_price_ironheart;
    public TextMeshProUGUI txt_price_goldheart;
    public TextMeshProUGUI txt_price_soulheart;

    public TextMeshProUGUI txt_price_sell_woodheart;
    public TextMeshProUGUI txt_price_sell_stoneheart;
    public TextMeshProUGUI txt_price_sell_ironheart;
    public TextMeshProUGUI txt_price_sell_goldheart;

    private bool enufHearts = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(convertInOption.value != in_opt_value)
        {
            in_opt_value = convertInOption.value;
            input = 0;
            result = 0;
        }

        if(convertOutOption.value != out_opt_value)
        {
            out_opt_value = convertOutOption.value;
            input = 0;
            result = 0;
        }

        in_wood = false;
        in_stone = false;
        in_iron = false;
        in_gold = false;

        out_wood = false;
        out_stone = false;
        out_iron = false;
        out_gold = false;

        switch (convertInOption.value)
        {
            case 0:
                in_wood = true;
                break;

            case 1:
                in_stone = true;
                break;

            case 2:
                in_iron = true;
                break;

            case 3:
                in_gold = true;
                break;
        }

        switch (convertOutOption.value)
        {
            case 0:
                out_wood = true;
                break;

            case 1:
                out_stone = true;
                break;

            case 2:
                out_iron = true;
                break;

            case 3:
                out_gold = true;
                break;
        }

        if (player.heartslot - 1 >= 0)
        {
            enufHearts = true;
        }
        else
        {
            enufHearts = false;
        }

        Convert();

        txt_price_woodheart.text = price_woodheart.ToString();
        txt_price_stoneheart.text = price_stoneheart.ToString();
        txt_price_ironheart.text = price_ironheart.ToString();
        txt_price_goldheart.text = price_goldheart.ToString();

        txt_price_sell_woodheart.text = price_sell_woodheart.ToString();
        txt_price_sell_stoneheart.text = price_sell_stoneheart.ToString();
        txt_price_sell_ironheart.text = price_sell_ironheart.ToString();
        txt_price_sell_goldheart.text = price_sell_goldheart.ToString();

        inputtext.text = input.ToString();
        outputtext.text = result.ToString();

    }

    public void Convert()
    {
        //wood

        if (in_wood && out_wood)
        {
            result = input;
        }

        if (in_wood && out_stone)
        {
            result = input / num_woodToStone;
        }

        if (in_wood && out_iron)
        {
            result = input / num_woodToStone / num_stoneToIron;
        }

        if (in_wood && out_gold)
        {
            result = input / num_woodToStone / num_stoneToIron / num_ironToGold;
        }

        //stone

        if (in_stone && out_wood)
        {
            result = input * num_woodToStone;
        }

        if (in_stone && out_stone)
        {
            result = input;
        }

        if (in_stone && out_iron)
        {
            result = input / num_stoneToIron;
        }

        if (in_stone && out_gold)
        {
            result = input / num_stoneToIron / num_ironToGold;
        }

        //iron

        if (in_iron && out_wood)
        {
            result = input * num_woodToStone * num_stoneToIron;
        }

        if (in_iron && out_stone)
        {
            result = input * num_stoneToIron;
        }

        if (in_iron && out_iron)
        {
            result = input;
        }

        if (in_iron && out_gold)
        {
            result = input / num_ironToGold;
        }

        //gold

        if (in_gold && out_wood)
        {
            result = input * num_woodToStone * num_stoneToIron * num_ironToGold;
        }

        if (in_gold && out_stone)
        {
            result = input * num_stoneToIron * num_ironToGold;
        }

        if (in_gold && out_iron)
        {
            result = input * num_ironToGold;
        }

        if (in_gold && out_gold)
        {
            result = input;
        }

        //Exchange table
        exchangetable.text = "exchange rate" + "\n" + num_woodToStone + " Wood --> 1 Stone" + "\n" + num_stoneToIron + " Stone --> 1 Iron" + "\n" + num_ironToGold + " Iron --> 1 Gold";
    }

    public void Add1()
    {
        if (out_wood)
        {
            input += 1;
        }

        if (out_stone && in_wood)
        {
            input += num_woodToStone;
        }
        else if (out_stone)
        {
            input += 1;
        }

        if(out_iron && in_wood)
        {
            input += num_woodToStone * num_stoneToIron;
        }
        else if(out_iron && in_stone)
        {
            input += num_stoneToIron;
        }
        else if(out_iron)
        {
            input += 1;
        }

        if(out_gold && in_wood)
        {
            input += num_woodToStone * num_stoneToIron * num_ironToGold;
        }
        else if(out_gold && in_stone)
        {
            input += num_ironToGold * num_stoneToIron;
        }
        else if(out_gold && in_iron)
        {
            input += num_ironToGold;
        }
    }

    public void Add10()
    {
        if (out_wood)
        {
            input += 3;
        }

        if (out_stone && in_wood)
        {
            input += num_woodToStone * 3;
        }
        else if (out_stone)
        {
            input += 3;
        }

        if (out_iron && in_wood)
        {
            input += num_woodToStone * num_stoneToIron * 3;
        }
        else if (out_iron && in_stone)
        {
            input += num_stoneToIron * 3;
        }
        else if (out_iron)
        {
            input += 3;
        }

        if (out_gold && in_wood)
        {
            input += num_woodToStone * num_stoneToIron * num_ironToGold * 3;
        }
        else if (out_gold && in_stone)
        {
            input += num_ironToGold * num_stoneToIron * 3;
        }
        else if (out_gold && in_iron)
        {
            input += num_ironToGold * 3;
        }
    }
    public void Minus1()
    {
        if (out_wood)
        {
            input -= 1;
        }

        if (out_stone && in_wood)
        {
            input -= num_woodToStone;
        }
        else if (out_stone)
        {
            input -= 1;
        }

        if (out_iron && in_wood)
        {
            input -= num_woodToStone * num_stoneToIron;
        }
        else if (out_iron && in_stone)
        {
            input -= num_stoneToIron;
        }
        else if (out_iron)
        {
            input -= 1;
        }

        if (out_gold && in_wood)
        {
            input -= num_woodToStone * num_stoneToIron * num_ironToGold;
        }
        else if (out_gold && in_stone)
        {
            input -= num_ironToGold * num_stoneToIron;
        }
        else if (out_gold && in_iron)
        {
            input -= num_ironToGold;
        }
    }
    public void Minus10()
    {
        if (out_wood)
        {
            input -= 3;
        }

        if (out_stone && in_wood)
        {
            input -= num_woodToStone * 3;
        }
        else if (out_stone)
        {
            input -= 3;
        }

        if (out_iron && in_wood)
        {
            input -= num_woodToStone * num_stoneToIron * 3;
        }
        else if (out_iron && in_stone)
        {
            input -= num_stoneToIron * 3;
        }
        else if (out_iron)
        {
            input -= 3;
        }

        if (out_gold && in_wood)
        {
            input -= num_woodToStone * num_stoneToIron * num_ironToGold * 3;
        }
        else if (out_gold && in_stone)
        {
            input -= num_ironToGold * num_stoneToIron * 3;
        }
        else if (out_gold && in_iron)
        {
            input -= num_ironToGold * 3;
        }
    }

    public void addToInventory()
    {
        bool enuf = false;
        if (out_wood)
        {
            if(player.wood >= result)
            {
                enuf = true;
                player.wood -= result;
            }
        }

        if (out_stone)
        {
            if (player.stone >= result)
            {
                enuf = true;
                player.stone -= result;
            }
        }

        if (out_iron)
        {
            if (player.iron >= result)
            {
                enuf = true;
                player.iron -= result;
            }
        }

        if (out_gold)
        {
            if (player.gold >= result)
            {
                enuf = true;
                player.gold -= result;
            }
        }

        if (enuf)
        {
            if (in_wood)
            {
                player.wood += input;
            }

            if (in_stone)
            {
                player.stone += input;
            }

            if (in_iron)
            {
                player.iron += input;
            }

            if (in_gold)
            {
                player.gold += input;
            }
        }
        
    }

    public void BuyWoodHP()
    { 
        if(enufHearts && player.wood - price_woodheart >= 0)
        {
            player.wood -= price_woodheart;
            player.wood_hp += 1;
            player.heartslot -= 1;
            ui.DrawHP();
        }
    }

    public void BuyStoneHP()
    {
        if (enufHearts && player.stone - price_stoneheart >= 0)
        {
            player.stone -= price_stoneheart;
            player.stone_hp += 1;
            player.heartslot -= 1;
            ui.DrawHP();
        }
    }

    public void BuyIronHP()
    {
        if(enufHearts && player.iron - price_ironheart >= 0)
        {
            player.iron -= price_ironheart;
            player.iron_hp += 1;
            player.heartslot -= 1;
            ui.DrawHP();
        }
    }

    public void BuyGoldHP()
    {
        if(enufHearts && player.gold - price_goldheart >= 0)
        {
            player.gold -= price_goldheart;
            player.gold_hp += 1;
            player.heartslot -= 1;
            ui.DrawHP();
        }
    }

    public void BuySoulHP()
    {
        if (player.gold - price_soulheart >= 0)
        {
            player.gold -= price_soulheart;
            player.heartslot += 1;
            ui.DrawHP();
        }
    }

    public void sellWoodHP()
    {
        if(player.wood_hp - 1 >= 1)
        {
            player.wood_hp -= 1;
            player.wood += price_sell_woodheart;
            player.heartslot += 1;
            ui.RemoveHP();
        }   
    }

    public void sellStoneHP()
    {
        if (player.stone_hp - 1 >= 1)
        {
            player.stone_hp -= 1;
            player.stone += price_sell_stoneheart;
            player.heartslot += 1;
            ui.RemoveHP();
        }
    }

    public void sellIronHP()
    {
        if (player.iron_hp - 1 >= 1)
        {
            player.iron_hp -= 1;
            player.iron += price_sell_ironheart;
            player.heartslot += 1;
            ui.RemoveHP();
        }
    }

    public void sellGoldHP()
    {
        if (player.gold_hp - 1 >= 1)
        {
            player.gold_hp -= 1;
            player.gold += price_sell_goldheart;
            player.heartslot += 1;
            ui.RemoveHP();
        }
    }

}
