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
        playerVelocity = new Vector3(Input.GetAxis("Horizontal") * playerSpeed, playerVelocity.y, Input.GetAxis("Vertical") * playerSpeed);

        if (Input.GetButtonDown("Jump") && controller.isGrounded) {
            playerVelocity.y = jumpForce;
        }

        playerVelocity.y += Physics.gravity.y * gravityForce;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
