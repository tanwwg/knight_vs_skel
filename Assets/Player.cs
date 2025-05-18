using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    
    private InputSystem_Actions _controls;

    public float jumpForce;
    public Vector2 speed;
    
    public Animator animator;
    public AnimatorState animState;
    
    private void OnEnable()
    {
        _controls = new InputSystem_Actions();
        _controls.Player.Enable();
    }

    private void FixedUpdate()
    {
        if (animState.State == "attack") return;

        if (_controls.Player.Attack.IsPressed())
        {
            animState.SetState("attack");
            return;
        }

        if (_controls.Player.Jump.IsPressed())
        {
            body.AddForceY(jumpForce, ForceMode2D.Force);
            animState.SetState("jump");
            return;
        }

        var moveInput = _controls.Player.Move.ReadValue<Vector2>();
        var vel = Vector2.Scale(speed, moveInput);
        body.linearVelocityX = vel.x;
        
        if (vel.x != 0) this.transform.localScale = new Vector3(Mathf.Sign(vel.x), 1, 1);

        animState.SetState(Math.Abs(body.linearVelocityX) > 0.1f ? "run" : "idle");
    }
}
