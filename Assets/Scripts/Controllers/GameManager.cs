using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int nextLevelBuildIndex = 1;
    [SerializeField] private int mainMenuIndex = 0;

    [SerializeField] private HealthController playerHC;
    [SerializeField] private float waitToRestart;

    [SerializeField] private float waitToNextLevel = 2f;

    private void OnEnable()
    {
        playerHC.onDead += HandleDeath;
    }

    private void OnDisable()
    {
        playerHC.onDead -= HandleDeath;
    }

    private void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void GoToNextLevel()
    {
        StartCoroutine(WaitToNextLevel());
    }

    public void RestartLevel()
    {
        LoadScene(currentLevel);
    }

    public void ReturnToMainMenu()
    {
        LoadScene(mainMenuIndex);
    }

    private void HandleDeath()
    {
        StartCoroutine(RestartLevelOnDeath());
    }

    private IEnumerator RestartLevelOnDeath()
    {
        yield return new WaitForSeconds(waitToRestart);
        RestartLevel();
    }

    private IEnumerator WaitToNextLevel()
    {
        yield return new WaitForSeconds(waitToNextLevel);
        LoadScene(nextLevelBuildIndex);
    }
}
