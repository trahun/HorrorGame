using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;

    public bool IsRunning => Input.GetKey(KeyCode.LeftShift);
    public bool IsJumping => Input.GetKeyDown(KeyCode.Space);

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
    }
}
