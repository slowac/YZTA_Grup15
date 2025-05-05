using UnityEngine;

public class SceneMusicStarter : MonoBehaviour
{
    [Tooltip("LevelMusic listesindeki hangi müzik çalýnacak?")]
    public int musicIndex = 0;

    void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayLevelMusic(musicIndex);
        }
    }
}