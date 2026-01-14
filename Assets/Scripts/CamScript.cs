using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform Player;

    void Start()
    {

    }

    void LateUpdate()
    {   
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z - 14f);
    }

}
