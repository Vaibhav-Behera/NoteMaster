using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float sensitivity = 1.0f;

    [SerializeField] private Button lockButton; // assign the lock button in the Inspector
    [SerializeField] private Button moveButton; // assign the move button in the Inspector

    [SerializeField] private Button lockflashcam; // assign the lock button in the Inspector
    [SerializeField] private Button locksavecam; // assign the move button in the Inspector

    
    private bool isLocked = false;
    
    private Vector3 lockedPosition = new Vector3(11.09f, 4.70f, -7.47f);
    private Vector3 lockedRotation = new Vector3(4.001f, -0.3f, 0);
    private Vector3 movedPosition = new Vector3(-45.4f, 6.22f, -6.89f);
    private Vector3 movedRotation = new Vector3(-0.35f, 0.05f, 0);

    private Vector3 flashcampos = new Vector3(-43.34f,20.99f,-41.92f);
    private Vector3 flashcamrot = new Vector3(1.20f,179.6f,0);
    private Vector3 savecampos = new Vector3(2.54f,4.90f,-63.69f);
    private Vector3 savecamrot = new Vector3(4.7f,179.98f,0);

    

    void Start()
    {
        lockButton.onClick.AddListener(ToggleLock);
        moveButton.onClick.AddListener(MoveCamera);

        locksavecam.onClick.AddListener(SaveCameraStop);
        lockflashcam.onClick.AddListener(FlashCameraStop);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("takenSS");
            ScreenCapture.CaptureScreenshot("ScreenshotTaken.png");
        }
        if (!isLocked)
        {
            // rotation
            Vector3 rotCam = transform.rotation.eulerAngles;
            rotCam.x -= Input.GetAxis("Mouse Y") * sensitivity;
            rotCam.y += Input.GetAxis("Mouse X") * sensitivity;
            transform.rotation = Quaternion.Euler(rotCam);

            // dash
  
            
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

    void FlashCameraStop()
    {
        isLocked = !isLocked;
        if(isLocked)
        {
        transform.position = flashcampos;
        transform.rotation = Quaternion.Euler(flashcamrot);
        }
    }

    void SaveCameraStop()
    {
        isLocked = !isLocked;
        if(isLocked)
        {
        transform.position = savecampos;
        transform.rotation = Quaternion.Euler(savecamrot);
        }
    }
}
