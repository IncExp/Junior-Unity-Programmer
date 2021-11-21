using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData : MonoBehaviour
{
    private Color teamColor;
    public void Save()
    {
        string savePath = Application.persistentDataPath + "/savefile.json";
        var data = new SaveData();
        data.teamColor = teamColor;

        var json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    public void Load()
    {
        string savePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(savePath))
        {
            var json = File.ReadAllText(savePath);
            var data = JsonUtility.FromJson<SaveData>(json);
            teamColor = data.teamColor;
        }
    }

    public Color GetColor()
    {
        return teamColor;
    }
    public void SetColor(Color color)
    {
        teamColor = color;
    }
}
