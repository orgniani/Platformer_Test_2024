using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuInputReader : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void StartButton()
    {
        gameManager.GoToNextLevel();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
