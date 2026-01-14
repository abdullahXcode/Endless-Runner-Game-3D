using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Coins_Counter_Script : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI total_coins_text;
    [SerializeField] TextMeshProUGUI current_score_text;

    [SerializeField] Transform Player;
    
    void Update()
    {
        total_coins_text.text = PlayerPrefs.GetInt("total_coins", 0).ToString("00");
        current_score_text.text = Player.transform.position.z.ToString("00.0") + "m";

        if(Player.transform.position.z >=  PlayerPrefs.GetFloat("high_score", 0f))
        {
            PlayerPrefs.SetFloat("high_score", Player.transform.position.z);    
        }
    }





}
