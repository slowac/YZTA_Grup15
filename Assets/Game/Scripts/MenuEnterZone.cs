using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEnterZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameScene_1"); // sahne ismi ya da index
        }
    }
}
