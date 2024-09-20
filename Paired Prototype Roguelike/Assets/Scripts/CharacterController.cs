using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float jumpForce = 5.0f;
    [SerializeField] protected Rigidbody rb;
    private UnityEngine.Vector3 direction;

    private void Update()
    {
        //movement
        HandleMoveInput();

        //shoot on left(click)
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        //move using WASD/arrows
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

        //look at mouse
        LookAtMouse();
    }
    private void Jump()
    {
        if(transform.position.y < 1.01) 
        {
            rb.AddForce(new UnityEngine.Vector3(0.0f, jumpForce, 0.0f));
            Debug.Log("Jump!");
        }
    }

    private void Shoot()
    {
        throw new NotImplementedException();
    }

    void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            UnityEngine.Vector3 target = hit.point - transform.position;
            target.y = 0;
            transform.rotation = UnityEngine.Quaternion.LookRotation(target);
        }
    }

    void HandleMoveInput()
    {
        UnityEngine.Vector3 input = new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        UnityEngine.Vector3 cameraForward = Camera.main.transform.forward;
        UnityEngine.Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Rotate the input direction based on camera's orientation
        direction = (cameraForward * input.z + cameraRight * input.x).normalized;
    }
}
