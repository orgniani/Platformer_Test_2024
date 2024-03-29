using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

}
