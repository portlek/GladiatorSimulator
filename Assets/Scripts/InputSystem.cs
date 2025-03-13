using UnityEngine;

namespace GladiatorSimulator {
[DefaultExecutionOrder(ExecutionOrder.Lowest)]
public class InputSystem : MonoBehaviour {
    private Inputs _inputs;
    private Vector2 _movement;

    private void Update() {
        _movement = _inputs.Player.Move.ReadValue<Vector2>();
    }

    private void Awake() {
        _inputs = new Inputs();
    }
}
}
