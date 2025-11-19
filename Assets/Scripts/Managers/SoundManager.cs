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

    void Start()
    {
        
    }

    public void PlayBGM(AudioClip _clip)
    {
        if(_bgmAudioSource.clip == _clip && _bgmAudioSource.isPlaying)
        {
            return;
        }
        
        _bgmAudioSource.Play();
    }

    public void PlaySFX(AudioClip _clip)
    {
        _sfxAudioSource.PlayOneShot(_clip);
    }

    public void StepSFX(AudioClip _clip)
    {
        _stepsAudioSource.PlayOneShot(_clip);
    }
}
