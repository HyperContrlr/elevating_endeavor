using System.Collections.Generic;
using UnityEngine;

public class topDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    private Vector3 moveInput;
    private float activeMoveSpeed;
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb.linearVelocity = moveInput * activeMoveSpeed;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    animator.SetInteger("WalkDirection", 1);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    animator.SetInteger("WalkDirection", 2);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    animator.SetInteger("WalkDirection", 3);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    animator.SetInteger("WalkDirection", 4);
        //}
        //if (speeeeed.speed <= 0)
        //{
        //    animator.SetInteger("WalkDirection", 0);
        //}
        //else
        //{
        //}
    }
}
