using UnityEngine;

public class Sexo : MonoBehaviour, IGrabeable
{
    public void Grab()
    {
        Debug.Log("Agarraste");
    }

    public void Drop()
    {
        Debug.Log("Soltaste");
    }
}
