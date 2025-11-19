using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get ; private set; }

    //Llave
    public bool hasKey = false;
    public bool isOpened = false;
    
    public GameObject toys;
    public bool youSeeNote;
    
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
    }
    public void Open()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._lockSFX);
        isOpened = true;
        PlayerController _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _playerScript.GrabObject();
        Destroy(_playerScript.key);
    }

    public void CanToy()
    {
        toys.layer = 6;
    }
}