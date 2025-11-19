using UnityEngine;
using UnityEngine.InputSystem;
public class Note : MonoBehaviour, IInteractable
{
    [SerializeField] private InputActionAsset _inputActionAsset;
    private bool isActive = false;
    public void Interact()
    {
        if (GameManager.Instance.isOpened == true)
        { 
            ColorEmission _emissionScript = GetComponent<ColorEmission>();
            isActive = !isActive;
            if (isActive && GameManager.Instance.isOpened == true)
            {
                _inputActionAsset.FindActionMap("Player").Disable();
                _inputActionAsset.FindActionMap("UI").Enable();

                _emissionScript.rangeEmission = false;
                UIManager.Instance.momNote.SetActive(true);
                GameManager.Instance.youSeeNote = true;
                GameManager.Instance.CanToy();
            }
            else if (!isActive && GameManager.Instance.isOpened == true)
            {
                _inputActionAsset.FindActionMap("UI").Disable();
                _inputActionAsset.FindActionMap("Player").Enable();

                _emissionScript.rangeEmission = true;
                UIManager.Instance.momNote.SetActive(false);
            }
        }
        return;
    }
}