using Unity.Entities;
using UnityEngine;

namespace GladiatorSimulator {
public class PlayerAuthoring : MonoBehaviour { }

public struct PlayerTagComponent : IComponentData { }

public class PlayerTagBaker : Baker<PlayerAuthoring> {
    public override void Bake(PlayerAuthoring authoring) {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent<PlayerTagComponent>(entity);
        AddComponent<PlayerInputJumpComponent>(entity);
        AddComponent<PlayerInputMovementComponent>(entity);
    }
}
}
