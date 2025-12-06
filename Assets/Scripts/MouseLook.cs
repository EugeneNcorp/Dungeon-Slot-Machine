using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float _xRotation = 0f;
    public float rotSpeed = 100.0f;
    public Transform playerBody;

    public float tiltAmount = 5f;
    public float tiltStartSpeed;
    public float tiltEndSpeed;
    private float horCurrentTilt = 0f;
    private float horTargetTilt = 0f;
    private float verCurrentTilt = 0f;
    private float verTargetTilt = 0f;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        CameraRotate();
        HorCameraTilt();
        VerCameraTilt();
    }

    private void CameraRotate()
    {
         float mouseX = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
         float mouseY = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        
        _xRotation -= mouseY; 
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        
        transform.localRotation = Quaternion.Euler(_xRotation + verCurrentTilt, 0f, horCurrentTilt); 
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void HorCameraTilt()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            horTargetTilt = -tiltAmount;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            horTargetTilt = tiltAmount;
        }
        else
        {
            horTargetTilt = 0f;
        }

        float smoothTilt;

        if (horTargetTilt == 0)
        {
            smoothTilt = tiltEndSpeed;
        }
        else
        {
            smoothTilt = tiltStartSpeed;
        }

        horCurrentTilt = Mathf.Lerp(horCurrentTilt, horTargetTilt, smoothTilt * Time.deltaTime);
    }
    
    private void VerCameraTilt()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            verTargetTilt = tiltAmount;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            verTargetTilt = -tiltAmount;
        }
        else
        {
            verTargetTilt = 0f;
        }

        float smoothTilt;

        if (verTargetTilt == 0)
        {
            smoothTilt = tiltEndSpeed;
        }
        else
        {
            smoothTilt = tiltStartSpeed;
        }

        verCurrentTilt = Mathf.Lerp(verCurrentTilt, verTargetTilt, smoothTilt * Time.deltaTime);
    }
    
}
