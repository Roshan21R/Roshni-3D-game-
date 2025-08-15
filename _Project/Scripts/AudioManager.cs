using UnityEngine;

/// <summary>
/// Manages all audio playback in the game.
/// Implemented as a persistent Singleton.
/// </summary>
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    public bool loop = false;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public Sound[] musicTracks;
    public Sound[] sfxTracks;

    private AudioSource _musicSource;
    private AudioSource _sfxSource;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Create audio sources dynamically
            _musicSource = gameObject.AddComponent<AudioSource>();
            _musicSource.loop = true;

            _sfxSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musicTracks, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("AudioManager: Music track not found: " + name);
            return;
        }

        _musicSource.clip = s.clip;
        _musicSource.volume = s.volume;
        _musicSource.pitch = s.pitch;
        _musicSource.loop = s.loop;
        _musicSource.Play();
    }

    public void PlaySfx(string name)
    {
        Sound s = System.Array.Find(sfxTracks, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("AudioManager: SFX track not found: " + name);
            return;
        }

        // We use PlayOneShot for SFX to allow multiple sounds to be played at the same time
        // without cutting each other off. We can pass volume scale directly.
        _sfxSource.PlayOneShot(s.clip, s.volume);
    }
}
