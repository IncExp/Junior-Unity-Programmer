using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Security.Cryptography;

public class DataManager : MonoBehaviour
{

    public PlayerData playerData;
    public static DataManager Instance;
    
    [SerializeField] private InputField nameInput;
    [SerializeField] private Text playerNameHighestScore;

    private string _savePath;
    private PlayerData _highestScorePlayer;

    private void Awake()
    {
        _savePath = Application.persistentDataPath + "/savefile.json";
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
        }
        Instance = this;
        playerNameHighestScore.text = "Highest Score not set yet!";
        LoadHighScore();
    }

    private void LoadHighScore()
    {
        if (!File.Exists(_savePath)) return;
        _highestScorePlayer = Load();
        if(!string.IsNullOrEmpty(_highestScorePlayer.name))
            playerNameHighestScore.text = _highestScorePlayer.AsText();
    }

    public void SaveName()
    {
        if(Instance.playerData == null)
        {
            Instance.playerData = gameObject.AddComponent<PlayerData>();
        }
        Instance.playerData.SetPlayerName(nameInput.text);
        Instance.playerData.SetHighestScore(0);
    }
    public void Save()
    {
        File.WriteAllText(_savePath, JsonUtility.ToJson(playerData));
    }

    private PlayerData Load()
    {
        var data = File.ReadAllText(_savePath);
        var player = gameObject.AddComponent<PlayerData>();
        JsonUtility.FromJsonOverwrite(data, player);
        return player;
    }

    public PlayerData GetHighestScorePlayer()
    {
        return _highestScorePlayer;
    }

    public void UpdateHighestScorePlayer()
    {
        _highestScorePlayer = playerData;
    }

}
