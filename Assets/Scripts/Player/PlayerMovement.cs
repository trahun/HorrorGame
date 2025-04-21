using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("MovementStats")]
    [SerializeField]private float _speed;
    
    [Header("CharacterComponents")]
    [SerializeField]private Rigidbody _rb;
    [SerializeField]private Transform _orientation;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(float horizontal, float vertical)
    {
        Vector3 movement = _orientation.forward * vertical + _orientation.right * horizontal;
        Vector3 offset = movement * _speed * Time.deltaTime;
        _rb.MovePosition(_rb.position + offset);
    }
}
