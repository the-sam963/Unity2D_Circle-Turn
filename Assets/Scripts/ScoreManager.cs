using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI scoreText;
    int coin;
    int score;

    void Awake() 
    {
        coin = PlayerPrefs.GetInt("coin");
        score = PlayerPrefs.GetInt("score");
    }
    
    
    void Update()
    {
        coinText.text = coin.ToString();
        scoreText.text = score.ToString();
    }
    


}
