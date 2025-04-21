using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public Transform _cameraPosition;
    void Update()
    {
        //передвижение камеры
        transform.position = _cameraPosition.position;
    }
}
