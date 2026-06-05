using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BgMusic;
    public AudioClip MenuMusic;

    public void playBgMusic()
    {
        audioSource.clip = BgMusic;
        audioSource.Play();
    }

    public void playMenuMusic()
    {
        audioSource.clip = MenuMusic;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
