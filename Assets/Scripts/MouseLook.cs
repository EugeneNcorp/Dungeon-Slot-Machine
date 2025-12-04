using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float _xRotation = 0f;
    public float rotSpeed = 100.0f;
    public Transform playerBody;

    public float tiltAmount = 5f;
    public float tiltStartSpeed;
    public float tiltEndSpeed;
    private float currentTilt = 0f;
    private float targetTilt = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        
    }
    void Update()
    {
        CameraRotate();
        HorCameraTilt();
    }

    private void CameraRotate()
    {
         float mouseX = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
         float mouseY = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        
        _xRotation -= mouseY; 
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, currentTilt); 
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void HorCameraTilt()
    {
        //bool leftStrafe = Input.GetKey(KeyCode.A);
        //bool rightStrafe = Input.GetKey(KeyCode.D);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            targetTilt = -tiltAmount;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            targetTilt = tiltAmount;
        }
        else
        {
            targetTilt = 0f;
        }

        float smoothTilt;

        if (targetTilt == 0)
        {
            smoothTilt = tiltEndSpeed;
        }
        else
        {
            smoothTilt = tiltStartSpeed;
        }

        currentTilt = Mathf.Lerp(currentTilt, targetTilt, smoothTilt * Time.deltaTime);
    }
    
}
