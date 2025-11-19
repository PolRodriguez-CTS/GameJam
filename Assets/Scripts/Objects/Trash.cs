using UnityEngine;

public class Trash : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Toy")
        {
                /*StartCoroutine(UIManager.Instance.DialogeVisible(5));
                UIManager.Instance.DialogText("Si mamá lo se… ¡ya te dije que lo iba hacer hoy!");*/
                GameManager.Instance.toyToTrash +=1;
                GameManager.Instance.ToyTrashed();
                PlayerController _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                Destroy(_playerScript._grabbedObject.gameObject);
                Debug.Log("gika");
        }
    } 
}