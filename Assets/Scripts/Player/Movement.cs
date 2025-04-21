using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("MovementStats")]
    [SerializeField]private float _speed;
    
    [Header("CharacterComponents")]
    [SerializeField]private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 movement)
    {
        Vector3 offset = movement * _speed * Time.deltaTime;
        _rb.MovePosition(_rb.position + offset);
    }
}
