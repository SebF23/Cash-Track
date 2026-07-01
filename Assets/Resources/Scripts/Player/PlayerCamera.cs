using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraPivot;
    public float cameraSensitivity;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraSensitivity = 500f;
    }

    void Update()
    {
        AdjustCameraX(Input.GetAxis("Mouse X") * cameraSensitivity);
        AdjustCameraY(Input.GetAxis("Mouse Y") * -cameraSensitivity);
    }

    void AdjustCameraX(float speed)
    {
        cameraPivot.localEulerAngles += new Vector3(0, speed, 0) * Time.deltaTime;
    }

    void AdjustCameraY(float speed)
    {
        cameraPivot.localEulerAngles += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
}
