using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public static event Action<bool> OnStateChange;
    private bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (!isPaused)
                Pause();
            else
                Resume();
    }

    private void Resume()
    {
        pausePanel.SetActive(false);

        isPaused = false;
        Time.timeScale = 1f;

        OnStateChange?.Invoke(true);
    }

    private void Pause()
    {
        pausePanel.SetActive(true);

        isPaused = true;
        Time.timeScale = 0f;

        OnStateChange?.Invoke(false);
    }
}
