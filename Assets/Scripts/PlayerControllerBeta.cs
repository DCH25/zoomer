using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBeta : MonoBehaviour
{
    float horizontal, vertical;
    float rotation_base;
    bool isGrounded;
    Vector3 move_direction;
    Vector3 jump;
    Rigidbody rb;
    public float jumpForce = 2.0f;
    public float speed = 10.0f;
    public GameObject cameraBase;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        jump = new Vector3(0.0f, 2.0f, 0.0f);        
    }

    void OnCollisionStay() 
    {
        isGrounded = true;    
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    
    void LateUpdate() 
    {
        PlayerLook();
    }
    
    void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }

    void PlayerLook()
    {
        rotation_base = cameraBase.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, rotation_base, 0);    
    }
}
