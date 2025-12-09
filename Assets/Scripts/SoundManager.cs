using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class NamedAudioClip
{
    public string key;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource audioSource;

    public List<NamedAudioClip> audioClips;
    private Dictionary<string, AudioClip> clipMap;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        clipMap = new Dictionary<string, AudioClip>();
        foreach (var entry in audioClips)
        {
            if (!clipMap.ContainsKey(entry.key))
            {
                clipMap.Add(entry.key, entry.clip);
            }
        }
    }

    public void PlaySFX(string key, float volume = 1f)
    {
        if (clipMap.ContainsKey(key) && clipMap[key] != null)
        {
            audioSource.PlayOneShot(clipMap[key], volume);
        }
        else
        {
            Debug.LogWarning("SoundManager: No clip mapped for key " + key);
        }
    }
}
