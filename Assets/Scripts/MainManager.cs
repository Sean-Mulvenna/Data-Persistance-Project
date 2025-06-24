using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;
    
    
    private void Awake() {
        //this is us making the main manager a singleton.
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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
}
