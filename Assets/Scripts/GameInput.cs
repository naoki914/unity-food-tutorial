using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;
    PlayerInputActions playerInputActions;
    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy() {
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;

        playerInputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext callback) {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext callback) {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext callback) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    void OnEnable() {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
