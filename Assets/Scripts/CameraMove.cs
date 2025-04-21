using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float _sensX;
    public float _sensY;
    public Transform _Orientation;
    float _xRotation;
    float _yRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        //считывание мышки
        float mouseX = Input.GetAxis("Mouse X") * _sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensY * Time.deltaTime;
        _xRotation -= mouseY;
        _yRotation += mouseX;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        //вращение модели orientation и камеры
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        _Orientation.rotation = Quaternion.Euler(0, _yRotation, 0f);
    }
}
