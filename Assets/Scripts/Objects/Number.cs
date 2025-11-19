using UnityEngine;
using UnityEngine.InputSystem;

public class Number : MonoBehaviour, IInteractable
{
    private bool isActive = false;

    public PlayerInput _playerInput;

    private InputAction _lookAction;
    private InputAction _moveAction;

    private void Awake() 
    {
        _playerInput = FindAnyObjectByType<PlayerInput>().GetComponent<PlayerInput>();
    }
    public void Interact()
    {
        ColorEmission _emissionScript = GetComponent<ColorEmission>();
        isActive = !isActive;
        if(isActive)
        {
            _playerInput.actions.FindActionMap("Player").Disable();
            _emissionScript.rangeEmission = false;
            UIManager.Instance.numberCanvas.SetActive(true);
        }
        else if(!isActive)
        {
            _playerInput.actions.FindActionMap("Player").Enable();
            _emissionScript.rangeEmission = true;
            UIManager.Instance.numberCanvas.SetActive(false);
            UIManager.Instance.DeleteText();
        }
    }
}
