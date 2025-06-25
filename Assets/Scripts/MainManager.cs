using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;

    public int highScore;
    public string highScoreName;


    private void Awake() {
        //this is us making the main manager a singleton.
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }


    public void StartGame() {
        SceneManager.LoadScene("main");
    }
    public void QuitGame() {
        SceneManager.LoadScene("startMenu");
    }

    public void SubmitName(string name) {
        if (string.IsNullOrEmpty(name)) {
            Debug.LogError("Name is empty!");
            return;
        }

        //whats typed as a name is saved as the playerName string
        playerName = name;
        Debug.Log("Player name submitted: " + playerName);
    }

    [System.Serializable]
    class SaveData {

        public int highScore;
        public string highScoreName;
    }

    public void SaveScore() {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }
}
