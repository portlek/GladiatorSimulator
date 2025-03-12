using Unity.Entities;
using UnityEngine;

namespace GladiatorSimulator;

public class CameraHolderAuthoring : MonoBehaviour {
    public GameObject cameraObject;
}

public struct CameraHolderComponent : IComponentData {
    public Entity CameraEntity;
}

public class CameraHolderAuthoringBaker : Baker<CameraHolderAuthoring> {
    public override void Bake(CameraHolderAuthoring authoring) {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new CameraHolderComponent {
            CameraEntity = GetEntity(authoring.cameraObject, TransformUsageFlags.Dynamic)
        });
    }
}
