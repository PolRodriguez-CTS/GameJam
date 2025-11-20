using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

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

    void Start()
    {
        SoundManager.Instance.PlayBGM(SoundManager.Instance._staticBgm);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        ChangeBGM(sceneName);
    }


    public void ChangeBGM(string sceneName)
    {
        if(sceneName == "MainMenu")
        {
            Debug.Log("MenuPrincipal");
            SoundManager.Instance.PlayBGM(SoundManager.Instance._staticBgm);
        }
        if(sceneName == "Testeo")
        {
            Debug.Log("Escena1");
            SoundManager.Instance.PlayBGM(SoundManager.Instance._bgmClip);
        }

        //Añadir escena de nivel
        /*
        if(sceneName == Nivel)
        {
            SoundManager.Instance.PlayBGM(SoundManager.Instance._bgmClip);
        }
        */
    }
}
