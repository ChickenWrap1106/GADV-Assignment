using UnityEngine;   // Import Unity’s core library (needed for MonoBehaviour, GameObject, AudioSource, AudioClip, etc.)

public class Audio : MonoBehaviour   // Define a class called Audio that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    [SerializeField] AudioSource musicSource; 
    // Reference to the AudioSource component that will play the music.
    // [SerializeField] makes it visible in the Inspector even though it’s private.

    public AudioClip Music; 
    // Public variable to assign the audio clip (music track) in the Inspector.
    // This is the sound file that will be played.

    private void Start() 
    {
        musicSource.clip = Music;   // Assign the chosen AudioClip to the AudioSource.
        musicSource.Play();         // Play the audio when the game starts.
    }
}
