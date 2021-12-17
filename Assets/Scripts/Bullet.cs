using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false)
        {
            ObjectPool.Instance.AddToPool(gameObject);
        }
    }

    private void Update()
    {
    }
}