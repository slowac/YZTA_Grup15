using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    private static bool player1Ready = false;
    private static bool player2Ready = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerClone_1")
            player1Ready = true;

        if (other.name == "PlayerClone_2")
            player2Ready = true;

        CheckPlayers();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerClone_1")
            player1Ready = false;

        if (other.name == "PlayerClone_2")
            player2Ready = false;
    }

    void CheckPlayers()
    {
        if (player1Ready && player2Ready)
        {
            Debug.Log("Ýki oyuncu da çýkýþta. Sonraki levele geçiliyor...");

            SoundManager.Instance.PlayPortalSFX();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
