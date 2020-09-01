using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform pivot;
    public Vector3 offset;
    public float rotateSpeed;
    public float maxViewAngle;
    public float minViewAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + offset;

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxisRaw("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxisRaw("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {
            pivot.rotation = Quaternion.Euler(360f - minViewAngle, 0, 0);
        }

        float y = target.eulerAngles.y;
        float x = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(x, y, 0);
        transform.position = target.position + (rotation * offset);

        if (transform.position.y < target.position.y) {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }

        transform.LookAt(target);
    }
}
