using UnityEngine;

public class Box : MonoBehaviour, IGrabeable
{
    public void Grab()
    {
        Debug.Log("Grab");
    }

    public void Drop()
    {
        Debug.Log("Drop");
    }
}
