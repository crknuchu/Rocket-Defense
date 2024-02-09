using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI numberOfAvailableRocketsText;
    private long _playerScore = 0;
    [SerializeField]
    private int numberOfAvailableRockets = 10;
    
    public long GetPlayerScore()
    {
        return this._playerScore;
    }

    public void SetPlayerScore(long points)
    {
        this._playerScore = points;
        scoreText.text = this._playerScore.ToString();
    }

    public void IncreasePlayerScore(long pointsIncrease)
    {
        this._playerScore += pointsIncrease;
        scoreText.text = this._playerScore.ToString();
    }

    public void DecreaseNumberOfRockets()
    {
        this.numberOfAvailableRockets--;
        numberOfAvailableRocketsText.text = this.numberOfAvailableRockets.ToString();
    }

    public long GetNumberOfRockets()
    {
        return this.numberOfAvailableRockets;
    }

    private void Start()
    {
        scoreText.text = this._playerScore.ToString();
        numberOfAvailableRocketsText.text = this.numberOfAvailableRockets.ToString();
    }
    
}
