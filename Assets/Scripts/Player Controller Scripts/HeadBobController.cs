using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool enable = true;

    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10.0f;

    [SerializeField] private Transform camera = null;
 

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    private CharacterController _controller;


    void Awake()
    {
         _controller = GetComponent<CharacterController>();
         _startPos = camera.localPosition;
    }
    void Update()
    {
        ResetPosition();
        if (!enable)
        {
            return;
        }
        CheckMotion();
    }

    private void CheckMotion()
    {
        float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;

        if (speed < _toggleSpeed)
        {
            return;
        }
        

        PlayMotion(FootStepMotion());
    }

    private void PlayMotion(Vector3 motion)
    {
        camera.localPosition += motion;
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude / 2;
        return pos;
    }

    private void ResetPosition()
    {
        if (camera.localPosition == _startPos)
        {
            return;
        }

        camera.localPosition = Vector3.Lerp(camera.localPosition, _startPos, 5 * Time.deltaTime);
    }
}
