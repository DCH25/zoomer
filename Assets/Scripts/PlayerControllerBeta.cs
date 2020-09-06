using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBeta : MonoBehaviour
{
    public GameObject cameraBase;
    public float playerSpeed = 10.0f;
    public float jumpForce = 30.0f;
    public float gravityForce = 10.0f;
    float rotation_base;
    CharacterController controller;
    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = playerVelocity.y;
        playerVelocity = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        playerVelocity = playerSpeed * playerVelocity.normalized;
        playerVelocity.y = y;

        if (controller.isGrounded) {
            playerVelocity.y = 0f;
            if (Input.GetButton("Jump")) {
                playerVelocity.y = jumpForce;
            }
        }

        playerVelocity.y += Physics.gravity.y * gravityForce * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void LateUpdate() 
    {
        PlayerLook();    
    }

    void PlayerLook()
    {
        rotation_base = cameraBase.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, rotation_base, 0);    
    }
}
