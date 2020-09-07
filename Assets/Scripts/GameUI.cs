using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseScreen;

    public void LoadMenu() {
        Time.timeScale = 1f;
        GamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    void Pause() {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GamePaused = true;
    }

    void Resume() {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GamePaused = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }
}