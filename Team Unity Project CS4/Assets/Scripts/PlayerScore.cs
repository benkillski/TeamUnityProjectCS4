using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    private int playerScore = 0;
    [SerializeField] TextMeshProUGUI playerScoreUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerScore = 0;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        playerScoreUI.text = "SCORE: " + playerScore;
    }
}
