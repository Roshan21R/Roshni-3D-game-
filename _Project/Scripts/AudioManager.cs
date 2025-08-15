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

    private Dictionary<string, Sound> _musicDict;
    private Dictionary<string, Sound> _sfxDict;

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

            // Initialize and populate the dictionaries for fast lookups
            _musicDict = new Dictionary<string, Sound>();
            foreach (var sound in musicTracks)
            {
                if (_musicDict.ContainsKey(sound.name))
                {
                    Debug.LogWarning($"AudioManager: Duplicate music track name found: '{sound.name}'. It will not be added.");
                    continue;
                }
                _musicDict.Add(sound.name, sound);
            }

            _sfxDict = new Dictionary<string, Sound>();
            foreach (var sound in sfxTracks)
            {
                if (_sfxDict.ContainsKey(sound.name))
                {
                    Debug.LogWarning($"AudioManager: Duplicate SFX track name found: '{sound.name}'. It will not be added.");
                    continue;
                }
                _sfxDict.Add(sound.name, sound);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        if (_musicDict.TryGetValue(name, out Sound s))
        {
            _musicSource.clip = s.clip;
            _musicSource.volume = s.volume;
            _musicSource.pitch = s.pitch;
            _musicSource.loop = s.loop;
            _musicSource.Play();
        }
        else
        {
            Debug.LogWarning($"AudioManager: Music track not found: '{name}'");
        }
    }

    public void PlaySfx(string name)
    {
        if (_sfxDict.TryGetValue(name, out Sound s))
        {
            // We use PlayOneShot for SFX to allow multiple sounds to be played at the same time
            // without cutting each other off. We can pass volume scale directly.
            _sfxSource.PlayOneShot(s.clip, s.volume);
        }
        else
        {
            Debug.LogWarning($"AudioManager: SFX track not found: '{name}'");
        }
    }
}
