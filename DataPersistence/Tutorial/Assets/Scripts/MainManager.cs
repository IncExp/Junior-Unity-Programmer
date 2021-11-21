using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    private static MainManager instance;
    private SaveData saveManager;
    private Color teamColor;

    private void Awake()
    {
        saveManager = GetComponent<SaveData>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public static MainManager GetInstance()
    {
        return instance;
    }

    public Color GetTeamColor()
    {
        return teamColor;
    }

    public void SetTeamColor(Color color)
    {
        teamColor = color;
    }

    public void Save()
    {
        saveManager.SetColor(teamColor);
        saveManager.Save();
    }

    public void Load()
    {
        saveManager.Load();
        teamColor = saveManager.GetColor();
    }
}
