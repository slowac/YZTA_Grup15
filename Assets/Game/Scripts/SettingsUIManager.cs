using TMPro;
using UnityEngine;

public class SettingsUIManager : MonoBehaviour
{
    public TextMeshProUGUI musicText;
    private int musicLevel = 5; // 0-10 arasý

    void Start()
    {
        // Kaydedilen deðeri al, int olarak
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicLevel = Mathf.RoundToInt(savedVolume * 10f);
        UpdateMusic(applyVolume: false);
    }

    public void IncreaseMusic()
    {
        musicLevel = Mathf.Min(musicLevel + 1, 10);
        UpdateMusic();
    }

    public void DecreaseMusic()
    {
        musicLevel = Mathf.Max(musicLevel - 1, 0);
        UpdateMusic();
    }

    void UpdateMusic(bool applyVolume = true)
    {
        float volume = musicLevel / 10f;
        musicText.text = musicLevel.ToString();

        if (applyVolume)
        {
            SoundManager.Instance.SetMusicVolume(volume);
            PlayerPrefs.SetFloat("MusicVolume", volume);
            PlayerPrefs.Save();
        }
    }
}
