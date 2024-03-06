using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteReplacer : MonoBehaviour
{
    [SerializeField] private FollowerEnemy enemy;

    [SerializeField] private GameObject enemyNeutralSprite;
    [SerializeField] private GameObject enemyAngrySprite;

    [SerializeField] private AudioSource spriteChange;


    private void OnEnable()
    {
        enemy.onReplaceSprite += ReplaceSprite;
    }

    private void OnDisable()
    {
        enemy.onReplaceSprite -= ReplaceSprite;
    }

    private void ReplaceSprite()
    {
        if (enemyNeutralSprite.activeSelf && enemy.attackNumber == 1)
        {
            enemyNeutralSprite.SetActive(false);
            enemyAngrySprite.SetActive(true);
            spriteChange.Play();
        }

        else if (enemyAngrySprite.activeSelf && enemy.attackNumber == 2)
        {
            enemyAngrySprite.SetActive(false);
            enemyNeutralSprite.SetActive(true);
            spriteChange.Play();
        }
    }
}
