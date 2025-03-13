using Unity.Entities;
using UnityEngine;

namespace GladiatorSimulator {
public partial struct PlayerMovementSystem : ISystem {
    public void OnCreate(ref SystemState state) {
        state.RequireForUpdate<PlayerInputJumpComponent>();
    }

    public void OnUpdate(ref SystemState state) {
        var jumpComponent = SystemAPI.GetSingleton<PlayerInputJumpComponent>();
        var jumping = jumpComponent.Value;

        if (jumping) {
            Debug.Log("test");
        }
    }
}
}
