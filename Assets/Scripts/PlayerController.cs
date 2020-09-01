using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public float playerSpeed;
    public float jumpForce;
    public float gravityForce;
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
        playerVelocity = playerSpeed * (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal"));
        playerVelocity = playerVelocity.normalized * playerSpeed;
        playerVelocity.y = y;

        if (controller.isGrounded) {
            playerVelocity.y = 0f;
            if (Input.GetButtonDown("Jump")) {
                playerVelocity.y = jumpForce;
            }
        }

        playerVelocity.y += Physics.gravity.y * gravityForce * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
