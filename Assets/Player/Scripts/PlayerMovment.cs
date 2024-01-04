using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMovment : MonoBehaviour
{
    public InventoryObject inventory;
    //speed variables 
    public float moveSpeed;
    public float groundDrag;
    //jump variables
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplyer;
    bool readyToJump;
    public KeyCode jumpKey = KeyCode.Space;
    //Ground check Variables
    public float playerHeight;
    public LayerMask isGround;
    bool Grounded;
    //movment variables
    public Transform Orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    //rigidbody variable
    Rigidbody rb;
    //Event trigger
    public UnityEvent onTriggerEnter = new UnityEvent();

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }
    // Update is called once per frame
    private void Update()
    {
        Grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGround);
        MyInput();
        speedControl();
        if (Grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && Grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer() 
    {
        moveDirection =  Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        
        if (Grounded) 
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!Grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplyer, ForceMode.Force);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.x);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.addItem(item.item, 1);
            Destroy(other.gameObject);
        }
        //triggers Dialogue when etering a collider
        if (other.CompareTag("Player")) onTriggerEnter.Invoke();
    }

    public void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
