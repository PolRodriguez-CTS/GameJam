using System;
using System.Collections;
using UnityEditor;
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
    private float playerSpeed = 5f;
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
    /*private float _standHeight = 1.2f;
    private float _crouchHeight = 0.6f;*/
    [SerializeField] private float _crouchSpeed = 5f;
    
    //se le puede meter numero si vemos que se controla mejor, de momento asignamos en el start
    [SerializeField] private float _cameraStandY = 1f;
    [SerializeField] private float _cameraCrouchY = 0.2f;

    public bool _isCrouched = false;
    private float _targetY;

    //Grab
    //Tamaño del sensor
    [SerializeField] private Vector3 _grabSensorSize;
    [SerializeField] private Transform _grabSensor;

    //Posición a la que se va a llevar al objeto grabeado
    [SerializeField] private Transform _hands;
    [SerializeField] private Vector3 _handsSize;
    //Transfomr del objeto grabeado
    private Transform _grabbedObject;


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

    void Start()
    {
        _targetY = _cameraStandY;
        _cameraHolder.localPosition = new Vector3(0, _cameraStandY, 0);

        //Queda intentar que al iniciar la cámara no mire hacia abajo
        //_xRotation = _cameraHolder.localRotation.eulerAngles.x;
    }

    void Update()
    {
        _moveValue = _moveAction.ReadValue<Vector2>();
        _lookValue = _lookAction.ReadValue<Vector2>();

        Movement();

        if (_crouchAction.WasPressedThisFrame())
        {
            //con esta línea evitamos tener que cambiar la booleana cada vez que agachamos y levantamos
            _isCrouched = !_isCrouched;
            //ToggleCrouch();

            if (_isCrouched)
            {
                _targetY = _cameraCrouchY;
            }

            else
            {
                _targetY = _cameraStandY;
            }
        }
        float newY = Mathf.MoveTowards(_cameraHolder.localPosition.y, _targetY, _crouchSpeed * Time.deltaTime);
        _cameraHolder.localPosition = new Vector3(0, newY, 0);

        if(_interactAction.WasPressedThisFrame())
        {
            GrabObject();
        }

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

    void Gravity(){}
    
    void ToggleCrouch()
    {
        //StartCoroutine(SmoothCrouch());
        if (!_isCrouched)
        {
            float newHeight = Mathf.Lerp(_cameraStandY, _cameraCrouchY, _crouchSpeed * Time.deltaTime);
            _cameraHolder.localPosition = new Vector3(0, -newHeight, 0);
        }
        else if (_isCrouched)
        {
            _cameraHolder.localPosition = new Vector3(0, _cameraStandY, 0);
        }
    }

    private void GrabObject()
    {
        if(_grabbedObject == null)
        {
            Collider[] objectsToGrab = Physics.OverlapBox(_grabSensor.position, _grabSensorSize);

            foreach(Collider item in objectsToGrab)
            {
                IGrabeable grabeable = item.GetComponent<IGrabeable>();

                if(grabeable != null)
                {
                    _grabbedObject = item.transform;
                    _grabbedObject.SetParent(_hands);
                    _grabbedObject.position = _hands.position;
                    _grabbedObject.rotation = _hands.rotation;
                    _grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        else
        {
            _grabbedObject.SetParent(null);
            _grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            _grabbedObject = null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_hands.position, _handsSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_grabSensor.position, _grabSensorSize);
    }
}
