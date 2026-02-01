using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioView : MonoBehaviour
{
    [SerializeField] private AudioClip flapClip;
    [SerializeField] private AudioClip scoreClip;
    [SerializeField] private AudioClip hitClip;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
        source.spatialBlend = 0f; // 2D
    }

    private void OnEnable()
    {
    
        PlayerController.Flapped += PlayFlap;
        PlayerController.Scored += PlayScore;
        PlayerController.HitPipe += PlayHit;
    }

    private void OnDisable()
    {
        PlayerController.Flapped -= PlayFlap;
        PlayerController.Scored -= PlayScore;
        PlayerController.HitPipe -= PlayHit;
    }

    private void PlayFlap()
    {
        if (flapClip == null) return;
        source.PlayOneShot(flapClip);
    }

    private void PlayScore()
    {
        if (scoreClip == null) return;
        source.PlayOneShot(scoreClip);
    }

    private void PlayHit()
    {
        if (hitClip == null) return;
        source.PlayOneShot(hitClip);
    }
}
