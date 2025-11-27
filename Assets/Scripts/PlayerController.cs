using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12.0f;

    public CharacterController controller;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Vector3 moveNormal = move * speed * Time.deltaTime;
        controller.Move(moveNormal);
    }
}
