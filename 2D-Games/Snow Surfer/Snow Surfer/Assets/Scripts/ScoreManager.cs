using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int Score = 0;

    public void AddScore(int AdditionalScore)
    {
        Score += AdditionalScore;
        scoreText.text = "SCORE : " + Score;
    }

}
