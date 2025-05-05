using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Müzikler")]
    public AudioClip mainMenuMusic;
    public AudioClip[] levelMusic;

    [Header("Ses Efektleri")]
    public AudioClip walkSFX;
    public AudioClip crouchSFX;
    public AudioClip jumpSFX;
    public AudioClip timeStopSFX;
    public AudioClip rewindSFX;
    public AudioClip reverseSFX;
    public AudioClip cloneSFX;
    public AudioClip gravitySFX;
    public AudioClip portalSFX;
    public AudioClip respawnSFX;


    private AudioSource rewindSource;
    private AudioSource musicSource;
    private AudioSource sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true;
            musicSource.volume = 0.5f;

            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.loop = false;
            sfxSource.volume = 0.6f;

            rewindSource = gameObject.AddComponent<AudioSource>();
            rewindSource.clip = rewindSFX;
            rewindSource.loop = false;
            rewindSource.volume = 0.6f;
        }
        else
        {
            Destroy(gameObject);
        }

        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        SetMusicVolume(savedMusicVolume);

    }

    public void PlayMainMenuMusic()
    {
        musicSource.clip = mainMenuMusic;
        musicSource.Play();
    }

    public void PlayLevelMusic(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelMusic.Length)
        {
            musicSource.clip = levelMusic[levelIndex];
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayRewindSFX()
    {
        if (!rewindSource.isPlaying)
            rewindSource.Play();
    }

    public void StopRewindSFX()
    {
        if (rewindSource.isPlaying)
            rewindSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void PlayWalkSFX() => sfxSource.PlayOneShot(walkSFX);
    public void PlayCrouchSFX() => sfxSource.PlayOneShot(crouchSFX);
    public void PlayJumpSFX() => sfxSource.PlayOneShot(jumpSFX);
    public void PlayTimeStopSFX() => sfxSource.PlayOneShot(timeStopSFX);
    public void PlayReverseSFX() => sfxSource.PlayOneShot(reverseSFX);
    public void PlayCloneSFX() => sfxSource.PlayOneShot(cloneSFX);
    public void PlayGravitySFX() => sfxSource.PlayOneShot(gravitySFX);
    public void PlayPortalSFX() => sfxSource.PlayOneShot(portalSFX);
    public void PlayRespawnSFX() => sfxSource.PlayOneShot(respawnSFX);

}