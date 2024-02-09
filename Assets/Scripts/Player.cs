using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private long _playerScore = 0;
    
    public long GetPlayerScore()
    {
        return this._playerScore;
    }

    public void SetPlayerScore(long points)
    {
        this._playerScore = points;
    }

    public void IncreasePlayerScore(long pointsIncrease)
    {
        this._playerScore += pointsIncrease;
    }
}
