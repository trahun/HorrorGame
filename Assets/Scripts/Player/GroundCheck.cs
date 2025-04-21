using UnityEngine;


public class GroundChecker : MonoBehaviour {
    [SerializeField] private float checkDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGrounded() 
    {
        return Physics.Raycast(transform.position, Vector3.down, checkDistance, groundLayer); 
    }
        
}

