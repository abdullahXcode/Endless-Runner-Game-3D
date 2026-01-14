using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButtonScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI best_score_text;


    Transform Player;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        score_text.text = Player.transform.position.z.ToString("00.0") + "m";
        best_score_text.text = PlayerPrefs.GetFloat("high_score", 0).ToString("00.0") + "m";
    }


    public void Restart_Button()
    {
        SceneManager.LoadScene(0);
    }

}
