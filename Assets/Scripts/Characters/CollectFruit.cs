using UnityEngine;

public class CollectFruit : MonoBehaviour
{
    [SerializeField] private string fruitTag = "Fruit";

    public VoidDelegateType onCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(fruitTag))
        {
            Destroy(collision.gameObject);

            if (onCollect != null)
                onCollect();
        }
    }
}
