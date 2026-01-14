using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Tile_Script : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player").gameObject;
    }

    void Update()
    {
        if (Player.transform.position.z > transform.position.z + 38f)
        {
            Road_Spawner_Script.instance.Spawn_Road();
            Destroy(this.gameObject);
        }

    }
}
