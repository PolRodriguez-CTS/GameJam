using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set; }
    [SerializeField] private AudioSource _sfxAudioSource;
    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioSource _stepsAudioSource;
    public AudioClip _bgmClip;
    public AudioClip _staticBgm;
    public AudioClip _stepsSFX;
    public AudioClip _buttonsSFX;
    public AudioClip _keySFX;
    public AudioClip _dropKeySFX;
    public AudioClip _doorSFX;
    public AudioClip _dropObjectSFX;
    public AudioClip _lockSFX;
    public AudioClip _canvasNoteSFX;
    public AudioClip _pelotaSFX;
    public AudioClip _cajaJuguetesSFX;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(_sfxAudioSource);
        DontDestroyOnLoad(_bgmAudioSource);
        DontDestroyOnLoad(_stepsAudioSource);
    }

    public void PlayBGM(AudioClip clip)
    {
        if (clip == null) return;

        // Si ya está sonando esta música, no la reinicies
        if (_bgmAudioSource.clip == clip && _bgmAudioSource.isPlaying)
            return;

        _bgmAudioSource.clip = clip;
        _bgmAudioSource.loop = true;
        _bgmAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxAudioSource.PlayOneShot(clip);
    }

    public void StepSFX(AudioClip _clip)
    {
        _stepsAudioSource.PlayOneShot(_clip);
    }
}
