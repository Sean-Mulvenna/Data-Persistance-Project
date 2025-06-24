using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public TMP_InputField nameInputField;

    public void QuitButtonPressed() {
        if (MainManager.Instance != null) {
            MainManager.Instance.QuitGame();
        }
    }

    public void StartButtonPressed() {
        if (MainManager.Instance != null) {
            MainManager.Instance.StartGame();
        }
    }
    public void SubmitButtonPressed() {
        if (MainManager.Instance != null) {
            MainManager.Instance.SubmitName(nameInputField.text);
        }
    }
}