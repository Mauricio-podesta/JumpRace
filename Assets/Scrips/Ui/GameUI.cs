using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] UIElements;

    private void GameUIElementsStateChange(bool newState)
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(newState);
        }
    }

    private void OnEnable()
    {
        GameStateManager.OnStateChange += GameUIElementsStateChange;
    }

    private void OnDisable()
    {
        GameStateManager.OnStateChange -= GameUIElementsStateChange;
    }
}
