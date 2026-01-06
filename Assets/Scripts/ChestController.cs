using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestController : MonoBehaviour
{

    [SerializeField] public bool overrideWasOpened;
    private static readonly int WasOpened = Animator.StringToHash("wasOpened");

    private Animator _animator;
    private bool _withinOpeningRange;
    private bool _wasOpened; 
    private InputAction _openAction;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _openAction = InputSystem.actions.FindAction("Interact");

        if (overrideWasOpened)
        {
            _animator.SetBool(WasOpened, overrideWasOpened);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!_withinOpeningRange || _wasOpened)
        {
            return;
        }

        if (_openAction.inProgress && _withinOpeningRange)
        {
            _wasOpened = true;
            _animator.SetBool(WasOpened, _wasOpened);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero" && !_wasOpened)
        {
            _withinOpeningRange = true;
        }
    }    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Hero")
        {
            _withinOpeningRange = false;
        }
    }
}
