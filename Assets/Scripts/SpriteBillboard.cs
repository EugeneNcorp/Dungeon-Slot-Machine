using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    private Vector3 originalRotation;
    void Awake()
    {
        originalRotation = transform.rotation.eulerAngles;
    }
    void Update()
    {
        //transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.x = originalRotation.x;
        //rotation.y = originalRotation.y;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
