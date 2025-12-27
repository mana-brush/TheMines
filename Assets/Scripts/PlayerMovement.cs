using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float gravity = -9.81f;
    public float downwardForce = -2f; // A small constant downward force
    
    // [SerializeField] private GameManager _gameManager;
    [SerializeField] private float speed = 5f;
    
    private CharacterController _characterController;
    private InputAction _moveAction;
    private GameManager _gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _moveAction = InputSystem.actions.FindAction("Move");
        String currentScene = SceneManager.GetActiveScene().name;
        GameObject foundObject = GameObject.FindGameObjectWithTag("GameController");
        if (foundObject)
        {
            _gameManager = foundObject.GetComponent<GameManager>();
        }
        
        if (_gameManager && _gameManager.HasScene(currentScene))
        {
            transform.position =
                _gameManager.LastScenePositionDictionary.GetValueOrDefault(currentScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);    
        if (_characterController.isGrounded)
        {
            // Reset vertical velocity when grounded, but apply a constant downward force
            // to keep it stuck to the ground, especially on slopes/stairs.
            if (movement.y < 0)
            {
                movement.y = downwardForce; 
            }
        }
        else
        {
            // Apply regular gravity when in the air
            movement.y += gravity * Time.deltaTime;
        }
        _characterController.Move(movement * (speed * Time.deltaTime));
    }
}
