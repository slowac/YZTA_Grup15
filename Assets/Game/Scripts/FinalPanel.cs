using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPanel : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Oyun kapatýlýyor...");
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
