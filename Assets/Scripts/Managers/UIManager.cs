using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get ; private set; }

    public GameObject numberCanvas;
    public Text numberText;
    private string numberCorrect = 9358.ToString();
    public Text dialogText;
    public GameObject dialogeText;
    public GameObject momNote;
    public GameObject sisterNote;
    public GameObject calendar;

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
        if (numberText.text == numberCorrect.ToString())
        {
            Debug.Log("Enter");
            //StartCoroutine(CorrectNumber());
        }
    }

    public void DialogText(string Dialog)
    {
        dialogText.text = Dialog;
    }

    public IEnumerator DialogeVisible(int tiempo)
    {
        dialogeText.SetActive(true);
        yield return new WaitForSeconds(tiempo);
        DialogeInvisivle();
    }
    public void DialogeInvisivle()
    {
        dialogeText.SetActive(false);
    }

    /*void NumerCorrect()
    {
        if(numberText.text == numberCorrect)
        {
            StartCoroutine(CorrectNumber(4));
        }
    }
    IEnumerator CorrectNumber(int tiempo)
    {

        yield return new WaitForSeconds(tiempo);
        //Abre la puerta

    }
    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(2);
        DialogeInvisivle();
    }*/

}