using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    public SpecialNote specialNote;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        } else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpecialNote")
        {
            other.GetComponent<SpecialNote>().GotPickedUp();
        }

        if (other.tag == "EndGameChest")
        {
            if (!other.GetComponent<EndGameChest>().isEndChest)
            {
                Debug.Log("touching the bonepile");
                other.GetComponent<EndGameChest>().SetToBones();
            } else
            {
                Debug.Log("touching the good chest");
                other.GetComponent<EndGameChest>().SetToOpen();
            }
        }
    }

    public void StartSpeedChange()
    {
        StartCoroutine(ChangeSpeed());
    }
    
    private IEnumerator ChangeSpeed()
    {
        moveSpeed = 15.0f;
        yield return new WaitForSeconds(3);
        moveSpeed = 7.0f;
    }
}
