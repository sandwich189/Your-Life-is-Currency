using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private Player player;

    public TMP_Dropdown convertInOption;
    public TMP_Dropdown convertOutOption;

    public TextMeshProUGUI inputtext;
    public TextMeshProUGUI outputtext;

    private int wood = 0, stone = 1, iron = 2, gold = 3;

    private bool in_wood = true, in_stone = false, in_iron = false, in_gold = false;
    private bool out_wood = true, out_stone = false, out_iron = false, out_gold = false;

    private int input = 0;
    private int rate = 1;
    private int result;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //selection
        //in
        if(convertInOption.value == wood)
        {
            in_wood = true;
        }
        else
        {
            in_wood = false;
        }

        if (convertInOption.value == stone)
        {
            in_stone = true;
        }
        else
        {
            in_iron = false;
        }

        if (convertInOption.value == iron)
        {
            in_iron = true;
        }
        else
        {
            in_iron = false;
        }

        if (convertInOption.value == gold)
        {
            in_gold = true;
        }
        else
        {
            in_gold = false;
        }

        //out
        if (convertOutOption.value == wood)
        {
            out_wood = true;
        }
        else
        {
            out_wood = false;
        }

        if (convertOutOption.value == stone)
        {
            out_stone = true;
        }
        else
        {
            out_iron = false;
        }

        if (convertOutOption.value == iron)
        {
            out_iron = true;
        }
        else
        {
            out_iron = false;
        }

        if (convertOutOption.value == gold)
        {
            out_gold = true;
        }
        else
        {
            out_gold = false;
        }

        
        //conversion rate 
        //wood
        if(in_wood && out_wood)
        {
            result = input;
        }

        if (in_wood && out_stone)
        {
            if(input%3 == 0)
            {
                result = input / 3;
            }
        }

        if(in_wood && out_iron)
        {
            if (input % 15 == 0)
            {
                result = input / 15;
            }
        }

        if(in_wood && out_gold)
        {
            if (input % 45 == 0)
            {
                result = input / 45;
            }
        }

        //stone
        if (in_stone && out_wood)
        {
            result = input * 3;
        }

        if (in_stone && out_stone)
        {
            rate = 1;
        }

        if (in_stone && out_iron)
        {
            rate = 1/5;
        }

        if (in_stone && out_gold)
        {
            rate = 1/15;
        }

        //iron
        if (in_iron && out_wood)
        {
            rate = 15;
        }

        if (in_iron && out_stone)
        {
            rate = 5;
        }

        if (in_iron && out_iron)
        {
            rate = 1;
        }

        if (in_iron && out_gold)
        {
            rate = 1/3;
        }

        //gold
        if (in_gold && out_wood)
        {
            rate = 45;
        }

        if (in_gold && out_stone)
        {
            rate = 15;
        }

        if (in_gold && out_iron)
        {
            rate = 3;
        }

        if (in_gold && out_gold)
        {
            rate = 1;
        }
        

        inputtext.text = input.ToString();
        outputtext.text = result.ToString();

    }

    public void Convert()
    {
        
    }

    public void Add1()
    {
        input += 1;
    }
    public void Add10()
    {
        input += 10;
    }
    public void Minus1()
    {
        if (input > 0)
        {
            input -= 1;
        }
    }
    public void Minus10()
    {
        if(input >= 10)
        {
            input -= 10;
        }
    }
}
