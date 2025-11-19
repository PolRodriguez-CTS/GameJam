using UnityEngine;
using UnityEngine.InputSystem;

public class SisterNote : MonoBehaviour, IGrabeable, IInteractable
{

    [SerializeField] private InputActionAsset _inputActionAsset;
    public bool canva = false;
    public void Grab()
    {
        if(GameManager.Instance.youSeeNote == true)
        {
            ColorEmission _emissionScript = GetComponent<ColorEmission>();

        canva = true;

        _emissionScript.rangeEmission = false;
        UIManager.Instance.sisterNote.SetActive(true);
        _inputActionAsset.FindActionMap("Player").Disable();
        _inputActionAsset.FindActionMap("UI").Enable();
        }
    }

    public void Drop()
    {
        if(GameManager.Instance.youSeeNote == true)
        {
            ColorEmission _emissionScript = GetComponent<ColorEmission>();

            _inputActionAsset.FindActionMap("UI").Disable();
            _inputActionAsset.FindActionMap("Player").Enable();

            _emissionScript.rangeEmission = true;
            UIManager.Instance.sisterNote.SetActive(false);
            canva = false;

        }

    }

    public void Interact()
    {
        if(GameManager.Instance.youSeeNote == true)
        {
            if(canva == true)
            {
                UIManager.Instance.sisterNote.SetActive(false);
                _inputActionAsset.FindActionMap("Player").Enable();
                _inputActionAsset.FindActionMap("UI").Disable();
                canva = false;
        }
        else if(canva == false)
            {
                UIManager.Instance.sisterNote.SetActive(true);
                _inputActionAsset.FindActionMap("UI").Enable();
                _inputActionAsset.FindActionMap("Player").Disable();
                canva = true;

            }
        }
    }
}