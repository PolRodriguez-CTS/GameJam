using UnityEngine;
public class Drawer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            if(GameManager.Instance.hasKey)
            {
                StartCoroutine(UIManager.Instance.DialogeVisible(5));
                UIManager.Instance.DialogText("Si mamá lo se… ¡ya te dije que lo iba hacer hoy!");
                GameManager.Instance.Open();
            }
        }
    }
}