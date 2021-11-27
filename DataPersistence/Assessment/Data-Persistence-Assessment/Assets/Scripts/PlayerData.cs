using System;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private int highestScore;

    public string GetPlayerName()
    {
        return playerName;
    }
    
    public int GetHighestScore()
    {
        return highestScore;
    }

    public void SetPlayerName(string player)
    {
        playerName = player;
    }
    
    public void SetHighestScore(int score)
    {
        highestScore = score;
    }

    public string AsText()
    {
        return GetPlayerName() + " - " + GetHighestScore() + " Points";
    }
}
