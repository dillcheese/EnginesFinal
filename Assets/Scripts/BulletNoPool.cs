using UnityEngine;

public class BulletNoPool : MonoBehaviour
{
    public int timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player") == false)
        {
            Destroy(gameObject);
        }

    }
 

    private void Update()
    {
    }
}