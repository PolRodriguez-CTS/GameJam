using UnityEngine;

public class Key : MonoBehaviour, IGrabeable
{
    public void Grab()
    {
        GameManager.Instance.hasKey = true;
    }

    public void Drop()
    {
        GameManager.Instance.hasKey = false;
    }
}
