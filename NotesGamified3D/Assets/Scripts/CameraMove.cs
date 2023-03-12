// using UnityEngine;

// public class CameraMove: MonoBehaviour
// {
//     [SerializeField] private float speed = 10f; // The speed at which the camera moves
//     [SerializeField] private float rotationSpeed = 5f; // The speed at which the camera rotates

//     private float yaw = 0.0f; // The horizontal rotation of the camera
//     private float pitch = 0.0f; // The vertical rotation of the camera


//     void Start()
//     {
//         // Cursor code
//         // Lock and hide the cursor at the start of the game
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;
//     }
//     // Update is called once per frame
//     void Update()
//     {
//          if (Input.GetMouseButtonDown(0)) //Cursor Code
//         {
//             // Unlock and show the cursor when the mouse button is clicked
//             Cursor.lockState = CursorLockMode.None;
//             Cursor.visible = true;
//         }

//         float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input
//         float vertical = Input.GetAxis("Vertical"); // Get vertical input

//         // Calculate the camera's new position based on the input
//         Vector3 newPos = transform.position + new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;

//         // Move the camera to the new position
//         transform.position = newPos;

//         // Get mouse input for rotation
//         float mouseX = Input.GetAxis("Mouse X");
//         float mouseY = Input.GetAxis("Mouse Y");

//         // Calculate new rotation based on mouse input
//         yaw += mouseX * rotationSpeed;
//         pitch -= mouseY * rotationSpeed;

//         // Limit pitch rotation to avoid camera flipping
//         pitch = Mathf.Clamp(pitch, -90f, 90f);

//         // Apply rotation to camera
//         transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
//     }
// }
// using System.Collections;
// using UnityEngine;

//     public class CameraMove : MonoBehaviour
//     {
//         [SerializeField] private float speed = 10.0f;
//         [SerializeField] private float sensitivity = 1.0f;
//         [SerializeField] private float dashSpeed = 20.0f;
//         [SerializeField] private float dashDuration = 0.5f;

//         private bool isDashing = false;
//         private float dashTimer = 0.0f;

//         void Update()
//         {
//             //Cursor.lockState = CursorLockMode.Locked;

//             // rotation
//             Vector3 rotCam = transform.rotation.eulerAngles;
//             rotCam.x -= Input.GetAxis("Mouse Y") * sensitivity;
//             rotCam.y += Input.GetAxis("Mouse X") * sensitivity;
//             transform.rotation = Quaternion.Euler(rotCam);

//             // dash
//             // if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
//             // {
//             //     FindObjectOfType<AudioManager>().Play("Dash");
//             //     isDashing = true;
//             //     dashTimer = 0.0f;
//             // }

//             if (isDashing)
//             {
//                 dashTimer += Time.deltaTime;
//                 transform.Translate(Vector3.forward * Time.deltaTime * dashSpeed);
//                 if (dashTimer >= dashDuration)
//                 {
//                     isDashing = false;
//                 }
//             }
//             else
//             {
//                 // translation
//                 Vector3 transCam = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//                 transCam = transCam * Time.deltaTime * speed * sensitivity;
//                 transform.Translate(transCam);

//                 // vertical movement
//                 if (Input.GetKey(KeyCode.Q))
//                 {
//                     transform.Translate(Vector3.down * Time.deltaTime * speed * sensitivity, Space.World);
//                 }
//                 if (Input.GetKey(KeyCode.E))
//                 {
//                     transform.Translate(Vector3.up * Time.deltaTime * speed * sensitivity, Space.World);
//                 }
//             }
//         }
//     }

// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;

// public class CameraMove : MonoBehaviour
// {
//     [SerializeField] private float speed = 10.0f;
//     [SerializeField] private float sensitivity = 1.0f;
//     [SerializeField] private float dashSpeed = 20.0f;
//     [SerializeField] private float dashDuration = 0.5f;
//     [SerializeField] private Button lockButton; // assign the lock button in the Inspector

//     private bool isDashing = false;
//     private bool isLocked = false;
//     private float dashTimer = 0.0f;
//     private Vector3 lockedPosition = new Vector3(8, 5, -8);
//     private Vector3 lockedRotation = new Vector3(4.7f, -0.25f, 0);

//     void Start()
//     {
//         lockButton.onClick.AddListener(ToggleLock);
//     }

//     void Update()
//     {
//         if (!isLocked)
//         {
//             // rotation
//             Vector3 rotCam = transform.rotation.eulerAngles;
//             rotCam.x -= Input.GetAxis("Mouse Y") * sensitivity;
//             rotCam.y += Input.GetAxis("Mouse X") * sensitivity;
//             transform.rotation = Quaternion.Euler(rotCam);

//             // dash
//             if (isDashing)
//             {
//                 dashTimer += Time.deltaTime;
//                 transform.Translate(Vector3.forward * Time.deltaTime * dashSpeed);
//                 if (dashTimer >= dashDuration)
//                 {
//                     isDashing = false;
//                 }
//             }
//             else
//             {
//                 // translation
//                 Vector3 transCam = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//                 if (!isLocked)
//                 {
//                     transCam = transCam * Time.deltaTime * speed * sensitivity;
//                 }
//                 transform.Translate(transCam);

//                 // vertical movement
//                 if (Input.GetKey(KeyCode.Q))
//                 {
//                     transform.Translate(Vector3.down * Time.deltaTime * speed * sensitivity, Space.World);
//                 }
//                 if (Input.GetKey(KeyCode.E))
//                 {
//                     transform.Translate(Vector3.up * Time.deltaTime * speed * sensitivity, Space.World);
//                 }
//             }
//         }
//     }

//     void ToggleLock()
//     {
//         isLocked = !isLocked;
//         if (isLocked)
//         {
//             transform.position = lockedPosition;
//             transform.rotation = Quaternion.Euler(lockedRotation);
//         }
//     }
// }
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float sensitivity = 1.0f;
    [SerializeField] private float dashSpeed = 20.0f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private Button lockButton; // assign the lock button in the Inspector
    [SerializeField] private Button moveButton; // assign the move button in the Inspector

    private bool isDashing = false;
    private bool isLocked = false;
    private float dashTimer = 0.0f;
    private Vector3 lockedPosition = new Vector3(8, 5, -8);
    private Vector3 lockedRotation = new Vector3(4.7f, -0.25f, 0);
    private Vector3 movedPosition = new Vector3(-46.9f, 6.7f, -8.29f);
    private Vector3 movedRotation = new Vector3(5.3f, -4.5f, 0);

    void Start()
    {
        lockButton.onClick.AddListener(ToggleLock);
        moveButton.onClick.AddListener(MoveCamera);
    }

    void Update()
    {
        if (!isLocked)
        {
            // rotation
            Vector3 rotCam = transform.rotation.eulerAngles;
            rotCam.x -= Input.GetAxis("Mouse Y") * sensitivity;
            rotCam.y += Input.GetAxis("Mouse X") * sensitivity;
            transform.rotation = Quaternion.Euler(rotCam);

            // dash
            if (isDashing)
            {
                dashTimer += Time.deltaTime;
                transform.Translate(Vector3.forward * Time.deltaTime * dashSpeed);
                if (dashTimer >= dashDuration)
                {
                    isDashing = false;
                }
            }
            else
            {
                // translation
                Vector3 transCam = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                if (!isLocked)
                {
                    transCam = transCam * Time.deltaTime * speed * sensitivity;
                }
                transform.Translate(transCam);

                // vertical movement
                if (Input.GetKey(KeyCode.Q))
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed * sensitivity, Space.World);
                }
                if (Input.GetKey(KeyCode.E))
                {
                    transform.Translate(Vector3.up * Time.deltaTime * speed * sensitivity, Space.World);
                }
            }
        }
    }

    void ToggleLock()
    {
        isLocked = !isLocked;
        if (isLocked)
        {
            transform.position = lockedPosition;
            transform.rotation = Quaternion.Euler(lockedRotation);
        }
    }

    void MoveCamera()
    {
        isLocked = !isLocked;
        if(isLocked)
        {
        transform.position = movedPosition;
        transform.rotation = Quaternion.Euler(movedRotation);
        }
    }
}
