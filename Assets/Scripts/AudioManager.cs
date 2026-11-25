using UnityEngine;

/// <summary> 
/// Manages audio 
/// </summary>

/// <remarks>
/// Maintained by: Xiangyu Luo
/// </remarks>
public class AudioManager : MonoBehaviour 
{
    public static AudioManager instance;
    [SerializeField] private AudioSource sfxObject;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary> 
    /// plays a oneshot audio clip, set persistent = true if audio needs to persist between scene changes
    /// </summary>
    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume, bool persistent = false)
    {
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);
        if (persistent)
        {
            DontDestroyOnLoad(audioSource.gameObject);
        }

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    /// <summary> 
    /// plays a random oneshot audio clip from a pool of clips, set persistent = true if audio needs to persist between scene changes
    /// </summary>
    public void PlayRandomSFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume, bool persistent = false)
    {
        int rand = Random.Range(0, audioClip.Length);

        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);
        if (persistent)
        {
            DontDestroyOnLoad(audioSource.gameObject);
        }

        audioSource.clip = audioClip[rand];
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
