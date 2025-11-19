using UnityEngine;
using UnityEngine.InputSystem;

public class Number : MonoBehaviour, IInteractable
{
    private bool isActive = false;
    [SerializeField] private InputActionAsset _inputActionAsset;

    public void Interact()
    {
        ColorEmission _emissionScript = GetComponent<ColorEmission>();
        isActive = !isActive;
        if(isActive)
        {
            _inputActionAsset.FindActionMap("Player").Disable();
            _inputActionAsset.FindActionMap("UI").Enable();
    
            _emissionScript.rangeEmission = false;
            UIManager.Instance.numberCanvas.SetActive(true);
        }
        else if(!isActive)
        {
            _inputActionAsset.FindActionMap("UI").Disable();
            _inputActionAsset.FindActionMap("Player").Enable();
            
            _emissionScript.rangeEmission = true;
            UIManager.Instance.numberCanvas.SetActive(false);
            UIManager.Instance.DeleteText();
        }
    }
}
