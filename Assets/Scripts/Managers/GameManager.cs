using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get ; private set; }

    //Llave
    public bool hasKey = false;
    public bool isOpened = false;
    
    public bool youSeeNote;

    public bool youSeeSisterNote = false;

    public List<GameObject> toys;


    
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
                Toys _toysScrits = obj.gameObject.GetComponent<Toys>();
                _toysScrits.enabled = true;
                obj.layer = 6;
                obj.tag = "Toy";
            }
        }
    }
}