using UnityEngine;

public class Key : MonoBehaviour, IGrabeable
{
    public void Grab()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._keySFX);
        GameManager.Instance.hasKey = true;
        StartCoroutine(UIManager.Instance.DialogeVisible(5));
        UIManager.Instance.DialogText("Vaya… que raro… no recordaba que tuviera una llave en mi habitación…");
    }

    public void Drop()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._dropKeySFX);
        GameManager.Instance.hasKey = false;
    }
}