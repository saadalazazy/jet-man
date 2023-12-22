using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootClip;
    [SerializeField][Range(0, 1)] float volume = 1.0f;
    [Header("Explosion")]
    [SerializeField] AudioClip ExplosionClip;
    [SerializeField][Range(0, 1)] float Explosionvolume = 1.0f;
    private void Awake()
    {
        mangeSelgalton();
    }
    void mangeSelgalton()
    {
        int instant = FindObjectsOfType(GetType()).Length;
        if (instant > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void playShootingSoundEffect()
    {
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, volume);
    }
    public void playExplosionSoundEffect()
    {
        AudioSource.PlayClipAtPoint(ExplosionClip, Camera.main.transform.position, Explosionvolume);
    }
}
