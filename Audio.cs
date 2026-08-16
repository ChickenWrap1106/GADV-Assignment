using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip Music;

    private void Start()
    {
        musicSource.clip = Music;
        musicSource.Play();

    }


}
