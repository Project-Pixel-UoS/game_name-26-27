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
    /// pitchVariance is multiplicative
    /// </summary>
    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume, bool isPersistent = false, float pitch = 1f, float pitchVariance = 0f)
    {
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);
        if (isPersistent)
        {
            DontDestroyOnLoad(audioSource.gameObject);
        }

        float varianceMultiplier = Random.Range(1f - pitchVariance, 1f + pitchVariance);
        float finalPitch = Mathf.Max(0.01f, pitch * varianceMultiplier);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = finalPitch;
        audioSource.Play();

        float clipLength = audioSource.clip.length / finalPitch;
        Destroy(audioSource.gameObject, clipLength);
    }

    /// <summary> 
    /// plays a random oneshot audio clip from a pool of clips, set persistent = true if audio needs to persist between scene changes
    /// pitchVariance is multiplicative
    /// </summary>
    public void PlayRandomSFXClip(AudioClip[] audioClips, Transform spawnTransform, float volume, bool isPersistent = false, float pitch = 1f, float pitchVariance = 0f)
    {
        int rand = Random.Range(0, audioClips.Length);
        PlaySFXClip(audioClips[rand], spawnTransform, volume, isPersistent, pitch, pitchVariance);
    }
}
