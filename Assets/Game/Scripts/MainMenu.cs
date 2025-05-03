using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUIContainer;
    public GameObject skillUIContainer;
    public GameObject playerContainer;
    public PlayerClone player;

    public void StartGame()
    {
        player.enabled = true;

        menuUIContainer.transform.DOMoveX(-400, 1f).SetEase(Ease.InOutCubic);

        playerContainer.transform.DOMoveX(22.5f, 1f).SetEase(Ease.OutBack);

        skillUIContainer.transform.DOMoveY(100f, 1f).SetEase(Ease.OutBack);
    }

    public void QuitGame()
    {
        Debug.Log("Oyun kapatýlýyor...");
        Application.Quit();
    }
}
