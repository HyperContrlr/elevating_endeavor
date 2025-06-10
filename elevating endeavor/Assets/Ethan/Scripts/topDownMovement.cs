using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class topDownMovement : MonoBehaviour
{
        float radius = 0.5f;
        float maxDistance = 1f;
    public float moveSpeed;
    public Rigidbody rb;
    private Vector3 moveInput;
    public float jumpForce;
    private float activeMoveSpeed;
    public bool canJump;
    public bool canAtk;
    public float currentDelay;
    //public Animator animator;

    public InputActionReference lite, medium, heavy, special, block, jump;

    private void OnEnable()
    {
        //single click/press events
        lite.action.performed += light_Pressed;
        medium.action.performed += medium_Pressed;
        heavy.action.performed += heavy_Pressed;
        special.action.performed += special_Pressed;
        jump.action.performed += jump_Pressed;
        //held press events
        block.action.performed += block_Started;
        block.action.performed -= block_Released;

        block.action.canceled += block_Released;
        block.action.canceled -= block_Started;

    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        canJump = false;
    }
    private void light_Pressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Light Attack");
        //ok so pretty much copy this for all the different things, make sure that it originates at the arms of sumthin like that
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        if (Physics.SphereCast(origin, radius, direction, out hit, maxDistance))
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
    }
    private void medium_Pressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Medium Attack");
    }
    private void heavy_Pressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Heavy Attack");
    }
    private void special_Pressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Special Attack");
    }
    private void block_Started(InputAction.CallbackContext obj)
    {
        Debug.Log("Blocked");
    }
    public void block_Released(InputAction.CallbackContext obj)
    {
        Debug.Log("Stopped Block");
    }
    private void jump_Pressed(InputAction.CallbackContext obj)
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
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
