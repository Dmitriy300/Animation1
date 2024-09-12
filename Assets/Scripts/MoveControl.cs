using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public float Speed = 2f;
    public float rotationSpeed = 10f;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
   
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(horizontal, 0, vertical );
        if (directionVector.magnitude > Mathf.Abs(0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(directionVector),Time.deltaTime * rotationSpeed);

        _animator.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        _rigidbody.velocity = Vector3.ClampMagnitude ( directionVector,1) * Speed;
    }
}
