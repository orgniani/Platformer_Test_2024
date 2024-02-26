using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject inputReader;
    [SerializeField] private float waitToActivateInputReader;

    private void Start()
    {
        StartCoroutine(ActivateInputReader());
    }

    private IEnumerator ActivateInputReader()
    {
        yield return new WaitForSeconds(waitToActivateInputReader);

        if (inputReader)
            inputReader.SetActive(true);
    }

    public void DeactivateInputReader()
    {
        if (inputReader)
            inputReader.SetActive(false);
    }
}
