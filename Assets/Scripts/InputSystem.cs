using UnityEngine;

namespace GladiatorSimulator {
[DefaultExecutionOrder(ExecutionOrder.Lowest)]
public class InputSystem : MonoBehaviour {
    public Vector2 Movement { get; private set; }

    #region Player

    #region Move
    private bool IsPlayerMoveEnabled() => _inputs.Player.Move.enabled;

    public void EnablePlayerMove() {
        _inputs.Player.Move.Enable();
    }

    public void DisablePayerMove() {
        _inputs.Player.Move.Disable();
    }
    #endregion

    #endregion

    #region Internal
    private Inputs _inputs;

    private void Awake() {
        _inputs = new Inputs();
    }

    private void Update() {
        Movement = _inputs.Player.Move.ReadValue<Vector2>();
    }

    private void OnDisable() {
        _inputs.Disable();
    }
    #endregion
}
}
