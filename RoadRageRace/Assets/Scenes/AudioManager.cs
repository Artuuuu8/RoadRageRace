using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // AudioClips for different sounds
    public AudioClip countdownSound;
    public AudioClip carCrashSound;
    public AudioClip carAccelerationSound;
    public AudioClip startSound;
    public AudioClip finishSound;
    public AudioClip restartSound;

    // AudioSource to play sounds
    private AudioSource audioSource;

    void Awake()
    {
        // Ensure a single instance persists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Play the countdown sound once 
    public void PlayCountdownSound()
    {
        audioSource.PlayOneShot(countdownSound);
    }

    // Play the car crash sound
    public void PlayCarCrashSound()
    {
        audioSource.PlayOneShot(carCrashSound);
    }

    // For car acceleration
    public void StartCarAccelerationSound()
    {
        if (audioSource.clip != carAccelerationSound)
        {
            audioSource.clip = carAccelerationSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopFinishSound()
    {
        if (audioSource.clip == finishSound)
        {
            audioSource.Stop();
            audioSource.clip = null;
            audioSource.loop = false;
        }
    }

    // Play the start sound
    public void PlayStartSound()
    {
        audioSource.PlayOneShot(startSound);
    }

    // Play the finish sound
    public void PlayFinishSound()
    {
        audioSource.PlayOneShot(finishSound);
    }

    // Play the restart sound
    public void PlayRestartSound()
    {
        audioSource.PlayOneShot(restartSound);
    }
}