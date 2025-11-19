using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get ; private set; }

    public GameObject numberCanvas;
    public Text numberText;
    private int numberCorrect = 9358;
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

    public void NumberText(string number)
    {
        Debug.Log("sadas");
        numberText.text = numberText.text + number;
    }

    public void DeleteText()
    {
        numberText.text = "";
    }

    public void CorrectText()
    {
        if(numberText.text == numberCorrect.ToString())
        {
            Debug.Log("Enter");
        }
    }

}
