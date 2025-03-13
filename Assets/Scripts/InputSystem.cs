using UnityEngine;

namespace GladiatorSimulator {
[DefaultExecutionOrder(ExecutionOrder.Lowest)]
public class InputSystem : MonoBehaviour {
    public Vector2 Movement { get; private set; }

    private Inputs _inputs;

    private void Awake() {
        _inputs = new Inputs();
    }

    private void Update() {
        Movement = _inputs.Player.Move.ReadValue<Vector2>();
    }
}
}
