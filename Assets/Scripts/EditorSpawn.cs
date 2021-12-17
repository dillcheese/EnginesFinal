using UnityEngine;

public class EditorSpawn : MonoBehaviour
{
    public GameObject enemy;
    private float inputDelay;

    // Use this for initialization
    private void Start()
    {
        inputDelay = 0.2f;
    }

    public void Update()
    {
        inputDelay = inputDelay - Time.deltaTime;

        if (Input.GetMouseButton(1) && inputDelay <= 0f)
        {
            SpawnEnemy(Input.mousePosition);

            // Instantiate(enemy, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity);
            inputDelay = 0.2f;
        }
    }

    public void SpawnEnemy(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        GameObject.Instantiate(enemy, new Vector2(hit.point.x, hit.point.y + 5f), Quaternion.identity);
    }

    public RaycastHit RayFromCamera(Vector2 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}