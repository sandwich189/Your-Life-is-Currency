using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resouces : MonoBehaviour
{
    public int hp = 1;

    public bool wood = true, stone = false, iron = false, gold = false;
    private int resourcetype;

    private void Start()
    {
        if (wood)
        {
            resourcetype = 0;
        }

        if (stone)
        {
            resourcetype = 1;
        }

        if (iron)
        {
            resourcetype = 2;
        }

        if (gold)
        {
            resourcetype = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            switch (resourcetype)

            {
            case 0:
                GameObject.Find("UIManager").GetComponent<UIManager>().ui_wood += 1;
                break;

            case 1:
                GameObject.Find("UIManager").GetComponent<UIManager>().ui_stone += 1;
                break;

            case 2:
                GameObject.Find("UIManager").GetComponent<UIManager>().ui_iron += 1;
                break;

            case 3:
                GameObject.Find("UIManager").GetComponent<UIManager>().ui_gold += 1;
                break;
            }

            GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().curSpawn -= 1;
            Destroy(gameObject);
        }
    }
}
