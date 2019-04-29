using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIManager ui;

    public int wood_hp = 1, stone_hp = 1, iron_hp = 1, gold_hp = 1;
    public int heartslot = 4;
    public int wood = 0, stone = 0, iron = 0, gold = 0;
    public float moveSpeed = 1;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int type)
    {
        switch (type)
        {
            case 0:
                wood_hp -= 1;
                break;
            case 1:
                stone_hp -= 1;
                break;
            case 2:
                iron_hp -= 1;
                break;
            case 3:
                gold_hp -= 1;
                break;
        }

        heartslot += 1;
        ui.RemoveHP();
    }
}
