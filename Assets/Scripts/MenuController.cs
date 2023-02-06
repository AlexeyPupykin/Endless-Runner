using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level001");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
