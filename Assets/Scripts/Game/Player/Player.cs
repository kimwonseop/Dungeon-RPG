using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour {
    [SerializeField] private Joystick joystick;
    [SerializeField] private float velocity = 1f;

    private CharacterController characterController;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {
        if (joystick.IsActive) {
            Debug.Log(joystick.Value.normalized);
            transform.localRotation = Quaternion.Euler(-joystick.Value);
            characterController.Move(transform.forward * velocity * Time.deltaTime);
        }
    }
}
