using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resouces : MonoBehaviour
{
    public int hp = 1;

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject.Find("Level Generator").GetComponent<LevelGenerator>().curSpawn -= 1;
    }
}
