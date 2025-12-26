using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BoulderEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Transform target;
    private static readonly int IsAggrod = Animator.StringToHash("isAggrod");
    private Animator _animator;
    private bool _isAggrod;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!_isAggrod)
        {
            return;
        } 
        
        var targetRotation = Quaternion.LookRotation (target.position - transform.parent.position);
        var str = Mathf.Min (speed * Time.deltaTime, 1);
        transform.parent.rotation = Quaternion.Lerp (transform.parent.rotation, targetRotation, str);
        transform.parent.position  = Vector3.MoveTowards(transform.parent.position, target.position, speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _animator.SetBool(IsAggrod, true);
            _isAggrod = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _animator.SetBool(IsAggrod, false);
            _isAggrod = false;
        }
    }
}
