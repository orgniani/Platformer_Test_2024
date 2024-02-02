using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStickToPlayer : MonoBehaviour
{
    [SerializeField] private string playerName = "Player";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == playerName)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == playerName)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
