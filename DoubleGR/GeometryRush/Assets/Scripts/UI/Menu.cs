using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Open(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
