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

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void ChangeBGM(Scene scene)
    {
        if(scene.name == "MainMenu")
        {
            Debug.Log("MenuPrincipal");
            SoundManager.Instance.PlayBGM(SoundManager.Instance._staticBgm);
        }
        if(scene.name == "SampleScene")
        {
            Debug.Log("Escena1");
            SoundManager.Instance.PlayBGM(SoundManager.Instance._bgmClip);
        }
    }
}
