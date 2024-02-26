using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private AudioSource winLevelSoundEffect;

    [SerializeField] private string tagToSearch = "Player";
    [SerializeField] private GameManager gameManager;
    [SerializeField] private InputDeactivator inputDeactivator;

    [SerializeField] private CharacterMovement playerCM;
    [SerializeField] private GameObject waypoint;

    private bool shouldMove = false;
    private float targetDistance;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == tagToSearch)
        {
            inputDeactivator.DeactivateInputReader();
            winLevelSoundEffect.Play();

            shouldMove = true;

            gameManager.GoToNextLevel();
        }

    }

    private void Update()
    {
        if(shouldMove)
        {
            Vector2 currentPosition = playerCM.transform.position;
            Vector2 nextPosition = waypoint.transform.position;

            targetDistance = Vector2.Distance(currentPosition, nextPosition);

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            playerCM.SetDirection(directionToNextPos);

            if(targetDistance < .5)
            {
                playerCM.SetDirection(Vector2.zero);
            }
        }
    }
}
