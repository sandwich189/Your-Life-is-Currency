using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resouces : MonoBehaviour
{
    public int hp = 1;

    private SpriteRenderer sprite;
    public Sprite[] sprite_variants;

    public bool wood = true, stone = false, iron = false, gold = false;
    private int resourcetype;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if(sprite_variants.Length != 0)
        {
            sprite.sprite = sprite_variants[Random.Range(0, sprite_variants.Length)];
        }

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
                GameObject.Find("Player").GetComponent<Player>().wood += 1;
                break;

            case 1:
                GameObject.Find("Player").GetComponent<Player>().stone += 1;
                break;

            case 2:
                GameObject.Find("Player").GetComponent<Player>().iron += 1;
                break;

            case 3:
                GameObject.Find("Player").GetComponent<Player>().gold += 1;
                break;
            }

            GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().curSpawn -= 1;
            Destroy(gameObject);
        }
    }
}
