using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
   

    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
   public  void AddScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = "Score:" + score;
    }

   
   
}
