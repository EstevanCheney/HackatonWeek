using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Bunker");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
