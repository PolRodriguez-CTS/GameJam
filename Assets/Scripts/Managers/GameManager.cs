using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get ; private set; }

    //Llave
    public bool hasKey = false;
    

    
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
        Debug.Log("Abierto");
        PlayerController _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _playerScript.GrabObject();
        Destroy(_playerScript.key);
    }

    public void DestroyToys()
    {
        
    }
}