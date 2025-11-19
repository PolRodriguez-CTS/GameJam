using UnityEngine;
using UnityEngine.InputSystem;

public class Calendary : MonoBehaviour, IInteractable
{
    private bool isActive = false;
    [SerializeField] private InputActionAsset _inputActionAsset;

    public void Interact()
    {
        if(GameManager.Instance.youSeeSisterNote == true)
        {
            ColorEmission _emissionScript = GetComponent<ColorEmission>();
            isActive = !isActive;
            if(isActive)
            {
                _inputActionAsset.FindActionMap("Player").Disable();
                _inputActionAsset.FindActionMap("UI").Enable();
        
                _emissionScript.rangeEmission = false;
                UIManager.Instance.momNote.SetActive(false);
                UIManager.Instance.sisterNote.SetActive(false);
                UIManager.Instance.calendar.SetActive(true);
            }
            else if(!isActive)
            {
                _inputActionAsset.FindActionMap("UI").Disable();
                _inputActionAsset.FindActionMap("Player").Enable();
                
                _emissionScript.rangeEmission = true;
                UIManager.Instance.calendar.SetActive(false);
                UIManager.Instance.momNote.SetActive(false);
                UIManager.Instance.sisterNote.SetActive(false);
            }
        }
        
    }
}
