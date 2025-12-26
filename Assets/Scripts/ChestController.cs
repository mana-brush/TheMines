using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestController : MonoBehaviour
{

    [SerializeField] private Canvas helpText;
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
        if (other.gameObject.name == "Player" && !_wasOpened)
        {
            _withinOpeningRange = true;
            helpText.gameObject.SetActive(true);
        }
    }    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _withinOpeningRange = false;
            helpText.gameObject.SetActive(false);
        }
    }
}
