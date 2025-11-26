using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource ambienceSource;

    [Header("SFX")]
    public AudioSource sfxSource;
    public AudioClip footstepClip;
    public AudioClip uiHoverClip;
    public AudioClip uiClickClip;

    [Header("Fade Config")]
    [SerializeField] private float musicFadeTime = 1.5f;
    [SerializeField] private float ambienceFadeTime = 1.0f;

    private Coroutine musicFadeCoroutine;
    private Coroutine ambienceFadeCoroutine;

    // Guarda a última localização de áudio ativa
    private LocationSO currentLocation;
    public LocationSO CurrentLocation => currentLocation;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ---------- MÚSICA COM FADE ----------

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null)
            return;

        // Se já está tocando essa música, não faz nada
        if (musicSource.clip == clip && musicSource.isPlaying)
            return;

        // Cancela fade anterior, se tiver
        if (musicFadeCoroutine != null)
            StopCoroutine(musicFadeCoroutine);

        musicFadeCoroutine = StartCoroutine(FadeMusicCoroutine(clip));
    }

    private IEnumerator FadeMusicCoroutine(AudioClip newClip)
    {
        float startVolume = musicSource.volume;
        float fadeTime = musicFadeTime;

        // Fade out
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeTime);
            yield return null;
        }

        musicSource.clip = newClip;
        musicSource.Play();

        // Fade in
        t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0f, startVolume, t / fadeTime);
            yield return null;
        }

        musicFadeCoroutine = null;
    }

    // ---------- AMBIENTE COM FADE (OPCIONAL) ----------

    public void PlayAmbience(AudioClip clip)
    {
        if (clip == null)
            return;

        if (ambienceSource.clip == clip && ambienceSource.isPlaying)
            return;

        if (ambienceFadeCoroutine != null)
            StopCoroutine(ambienceFadeCoroutine);

        ambienceFadeCoroutine = StartCoroutine(FadeAmbienceCoroutine(clip));
    }

    private IEnumerator FadeAmbienceCoroutine(AudioClip newClip)
    {
        float startVolume = ambienceSource.volume;
        float fadeTime = ambienceFadeTime;

        // Fade out
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            ambienceSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeTime);
            yield return null;
        }

        ambienceSource.clip = newClip;
        ambienceSource.loop = true;
        ambienceSource.Play();

        // Fade in
        t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            ambienceSource.volume = Mathf.Lerp(0f, startVolume, t / fadeTime);
            yield return null;
        }

        ambienceFadeCoroutine = null;
    }

    // ---------- CHAMADO AO ENTRAR EM UMA LOCATION ----------

    public void OnLocationEntered(LocationSO location)
    {
        if (location == null)
            return;

        // Se for a mesma location, não refaz o fade
        if (currentLocation == location)
            return;

        currentLocation = location;

        if (location.locationMusic != null)
            PlayMusic(location.locationMusic);

        if (location.locationAmbience != null)
            PlayAmbience(location.locationAmbience);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayFootstep()
    {
        PlaySFX(footstepClip);
    }

    public void PlayUIHover()
    {
        PlaySFX(uiHoverClip);
    }

    public void PlayUIClick()
    {
        PlaySFX(uiClickClip);
    }
}
