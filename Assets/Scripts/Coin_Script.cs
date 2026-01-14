using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    //  PlayerSound playerSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            FindFirstObjectByType<Player_Controller>().PlayCoin();



            // playerSound.PlayCoin();
            PlayerPrefs.SetInt("total_coins", PlayerPrefs.GetInt("total_coins", 0) + 1);
            Destroy(this.gameObject);
        }
    }
}
