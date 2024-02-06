using System.Runtime.InteropServices;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private CharacterJump jump;
    [SerializeField] private HealthController death;
    [SerializeField] private CollectFruit collect;

    private void OnEnable()
    {
        if (jump)
            jump.onJump += HandleJump;

        if (death)
            death.onDead += HandleDead;

        if (collect)
            collect.onCollect += HandleCollect;
    }

    private void OnDisable()
    {
        if (jump)
            jump.onJump -= HandleJump;

        if (death)
            death.onDead -= HandleDead;

        if (collect)
            collect.onCollect -= HandleCollect;
    }

    private void HandleJump()
    {
        jumpSoundEffect.Play();
    }

    private void HandleDead()
    {
        deathSoundEffect.Play();
    }

    private void HandleCollect()
    {
        collectSoundEffect.Play();
    }
}
