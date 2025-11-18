using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Components
    //------------------------------------------------
    private CharacterController _characterController;
    //------------------------------------------------

    //Inputs
    //------------------------------------------------
    private Vector2 _moveValue;
    private InputAction _moveAction;

    //private InputAction _jumpAction;
    public Vector2 _lookValue;
    private InputAction _lookAction;

    private InputAction _crouchAction;

    private InputAction _interactAction;
    //------------------------------------------------

    //Movement
    //------------------------------------------------
    public float playerSpeed = 5f;
    //------------------------------------------------

    //Camera
    //------------------------------------------------
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private Transform _cameraHolder;
    private float _cameraSens = 20f;
    private float _xRotation;
    //------------------------------------------------

    //Crouch
    //------------------------------------------------
    private float _standHeight = 1.2f;
    private float _crouchHeight = 0.6f;
    private float _crouchSpeed = 2;

    void Awake()
    {
        //Components
        _characterController = GetComponent<CharacterController>();

        //Inputs
        _moveAction = InputSystem.actions["Move"];
        _crouchAction = InputSystem.actions["Crouch"];
        _interactAction = InputSystem.actions["Interact"];
        _lookAction = InputSystem.actions["Look"];
    }

    void Update()
    {
        _moveValue = _moveAction.ReadValue<Vector2>();
        _lookValue = _lookAction.ReadValue<Vector2>();

        Movement();
    }

    void Movement()
    {
        Vector3 direction = new Vector3(_moveValue.x, 0, _moveValue.y);

        float mouseX = _lookValue.x * _cameraSens * Time.deltaTime;
        float mouseY = _lookValue.y * _cameraSens * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        //Yaw
        transform.Rotate(Vector3.up, mouseX);

        //Pitch
        _cameraHolder.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        if(direction != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _characterController.Move(moveDirection * playerSpeed * Time.deltaTime);
        }
    }

    void Crouch()
    {
        //Altura nueva
        //Interpolación cambio de alturas
        
    }
}
