using UnityEngine;

public class Drawer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            if(GameManager.Instance.hasKey)
            {
                GameManager.Instance.Open();
            }
        }
    }
}