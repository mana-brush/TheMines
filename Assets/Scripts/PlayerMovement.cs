using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float speed = 5f;
    
    private CharacterController _characterController;
    private InputAction _moveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        movement = _gameManager.GameState.ActiveCamera.gameObject.transform.TransformDirection(movement); // adjust rotation to the current camera
        movement.y = 0.0f; // prevent levitation from grabbed camera transform
        _characterController.Move(movement * (speed * Time.deltaTime));
    }
}
