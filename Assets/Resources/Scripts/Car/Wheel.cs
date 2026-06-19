using UnityEngine;

public class Wheel : MonoBehaviour
{
    public WheelCollider wheelCollider;
    public Transform wheelMesh;
    public bool allowTurn;
    public float steerAngleVal;
    
    void Awake()
    {
        if(wheelCollider == null)
        {
            wheelCollider = GetComponent<WheelCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        steerAngleVal = wheelCollider.steerAngle;
        if (allowTurn)
        {
            wheelMesh.localEulerAngles = new Vector3(wheelMesh.localEulerAngles.x, wheelCollider.steerAngle, wheelMesh.localEulerAngles.z);
        }
        wheelMesh.Rotate(0, -wheelCollider.rpm / 60 * 360 * Time.deltaTime, 0);
    }
}
