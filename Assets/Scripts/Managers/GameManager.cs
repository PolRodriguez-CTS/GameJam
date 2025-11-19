using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get ; private set; }

    //Llave
    public bool hasKey = false;
    public bool isOpened = false;
    
    public bool youSeeNote;

    public List<GameObject> toys;

    public int toyToTrash = 0;
    public bool allTrashed = false;
    
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
        foreach (GameObject obj in toys)
        {
            if (obj != null)
            {
                obj.layer = 6;
                obj.tag = "Toy";
            }
        }
    }

    public void ToyTrashed()
    {
        if(toyToTrash == 5)
        {
            allTrashed = true;
        }
    }
}