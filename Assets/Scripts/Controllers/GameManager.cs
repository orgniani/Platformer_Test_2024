using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int nextLevelBuildIndex = 1;

    [SerializeField] private HealthController playerHC;
    [SerializeField] private float waitToRestart;

    [SerializeField] private GameObject inputReader;
    [SerializeField] private float waitToActivateInputReader;

    [SerializeField] private float waitToNextLevel = 2f;

    private void OnEnable()
    {
        playerHC.onDead += HandleDeath;
    }

    private void OnDisable()
    {
        playerHC.onDead -= HandleDeath;
    }

    private void Start()
    {
        StartCoroutine(ActivateInputReader());
    }

    private IEnumerator ActivateInputReader()
    {
        yield return new WaitForSeconds(waitToActivateInputReader);

        if(inputReader)
            inputReader.SetActive(true);
    }

    public void DeactivateInputReader()
    {
                if(inputReader)
        inputReader.SetActive(false);
    }

    private void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void GoToNextLevel()
    {
        StartCoroutine(WaitToNextLevel());
    }

    private void HandleDeath()
    {
        StartCoroutine(RestartLevelOnDeath());
    }

    private IEnumerator RestartLevelOnDeath()
    {
        yield return new WaitForSeconds(waitToRestart);

        LoadScene(currentLevel);
    }

    private IEnumerator WaitToNextLevel()
    {
        yield return new WaitForSeconds(waitToNextLevel);
        LoadScene(nextLevelBuildIndex);
    }
}
