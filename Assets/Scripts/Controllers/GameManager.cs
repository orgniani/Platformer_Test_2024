using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 0;
    //[SerializeField] private int nextLevelBuildIndex = 1;
    //[SerializeField] private int firstLevelBuildIndex = 2;
    //[SerializeField] private int mainMenuBuildIndex = 0;

    [SerializeField] private HealthController playerHC;
    [SerializeField] private float waitToRestart;

    [SerializeField] private GameObject inputReader;
    [SerializeField] private float waitToActivateInputReader;

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

    private IEnumerator RestartLevelOnDeath()
    {
        yield return new WaitForSeconds(waitToRestart);

        LoadScene(currentLevel);
    }

    private IEnumerator ActivateInputReader()
    {
        yield return new WaitForSeconds(waitToActivateInputReader);

        inputReader.SetActive(true);
    }

    private void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    private void HandleDeath()
    {
        StartCoroutine(RestartLevelOnDeath());
    }
}
