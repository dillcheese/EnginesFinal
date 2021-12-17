using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 4f;
    private Vector2 target;
    private Vector2 position;
    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        position = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().lives--;
            Destroy(gameObject);

            //SceneManager.LoadScene("Lose");
        }
    }
}