using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] GameInput gameInput;

    private bool isWalking;

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        isWalking = moveDirection != Vector3.zero;
        Debug.Log(IsWalking());
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);


    }

    public bool IsWalking() {
        return isWalking;
    }
    public bool Cacaw() {
        return isWalking;
    }
}
