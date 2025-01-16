using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ShowDeathMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReturnToScreen()
    {
        Application.Quit();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
