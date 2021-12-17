using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
      public void changeScenes(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void play()
    {
        SceneManager.LoadScene("Play");
    }

    public void quit()
    {
        Application.Quit();
    }
}