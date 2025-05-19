using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    
    private InputSystem_Actions _controls;

    public Vector2 speed;

    public Cooldown attack;
    public PlayerJump jump;
    
    public AnimatorState animState;
    
    private void OnEnable()
    {
        _controls ??= new InputSystem_Actions();
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    private void FixedUpdate()
    {
        if (attack.isActivated) return;
        if (_controls.Player.Attack.IsPressed() && !attack.isActivated)
        {
            attack.Activate();
        }
        
        jump.HandleJump(_controls);

        var moveInput = _controls.Player.Move.ReadValue<Vector2>();
        var vel = Vector2.Scale(speed, moveInput);
        body.linearVelocityX = vel.x;
        
        if (vel.x != 0) this.transform.localScale = new Vector3(Mathf.Sign(vel.x), 1, 1);

        animState.SetState(Math.Abs(body.linearVelocityX) > 0 ? "run" : "idle");
    }

}
