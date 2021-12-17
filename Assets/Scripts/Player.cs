using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    public int lives = 3;

    public bool pooling;
    public Rigidbody2D rb;
    public GameObject bullet;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pooling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject shot = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + bullet.transform.localScale.y * 1.5f), Quaternion.identity);
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void Shoot()
    {
        var bullet = ObjectPool.Instance.GetFromPool();
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y + bullet.transform.localScale.y * 1.5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }
}