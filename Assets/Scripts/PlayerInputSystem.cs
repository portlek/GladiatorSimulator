using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GladiatorSimulator {
public struct PlayerInputMovementComponent : IComponentData {
    public float2 Value;
}

public struct PlayerInputJumpComponent : IComponentData {
    public bool Value;
}

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
public partial class PlayerInputSystem : SystemBase {
    private PlayerInput _input;

    protected override void OnCreate() {
        RequireForUpdate<PlayerInputMovementComponent>();
        RequireForUpdate<PlayerInputJumpComponent>();

        _input = new PlayerInput();
    }

    protected override void OnStartRunning() {
        _input.Enable();
        _input.Player.Jump.started += OnJumpStarted;
        _input.Player.Jump.canceled += OnJumpCancelled;
    }

    protected override void OnUpdate() {
        var movement = _input.Player.Move.ReadValue<Vector2>();

        SystemAPI.SetSingleton(new PlayerInputMovementComponent {
            Value = movement
        });
    }

    protected override void OnStopRunning() {
        _input.Disable();
        _input.Player.Jump.started -= OnJumpStarted;
        _input.Player.Jump.canceled -= OnJumpCancelled;
    }
    
    private void OnJumpStarted(InputAction.CallbackContext ctx) {
        SystemAPI.SetSingleton(new PlayerInputJumpComponent {
            Value = true
        });
    }
    
    private void OnJumpCancelled(InputAction.CallbackContext ctx) {
        SystemAPI.SetSingleton(new PlayerInputJumpComponent {
            Value = false
        });
    }
}
}
