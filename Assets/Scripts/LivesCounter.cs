using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public int Value;
    public Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void counterl()
    {
        _text.text = "Lives: " + Value.ToString();
    }

    private void Update()
    {
        Value = GameObject.FindWithTag("Player").GetComponent<Player>().lives;
        _text.text = Value.ToString();
    }
}