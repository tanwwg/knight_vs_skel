using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    public float maxJumpTime;
    public float jumpForce;
    public Rigidbody2D body;
    public float groundedMinVel;

    public ColliderCheck groundCheck;
    
    
    public UnityEvent onJump;

    [Header("Read Only")]
    public float jumpTime;
    public bool isGrounded;
    public bool isJumping;
    
    public void HandleJump(InputSystem_Actions  controls)
    {
        isGrounded = groundCheck.IsOverlap() && Mathf.Abs(body.linearVelocityY) <= groundedMinVel;
        
        if (isGrounded && controls.Player.Jump.WasPressedThisFrame())
        {
            jumpTime = 0f;
            isJumping = true;
            body.AddForceY(jumpTime, ForceMode2D.Force); 
            onJump.Invoke();
        }
        if (isJumping)
        {
            jumpTime += Time.fixedDeltaTime;
            if (jumpTime < maxJumpTime)
            {
                body.AddForceY(jumpForce);
            }
        }
        if (controls.Player.Jump.WasCompletedThisFrame())
        {
            isJumping = false;
            jumpTime = 0f;
        }
    }
}
