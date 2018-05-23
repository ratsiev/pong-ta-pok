using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private BumperController controller;

    private void Awake() {
        controller = GetComponent<BumperController>();
    }

    void FixedUpdate() {
        if (controller.isBumpOne)
            controller.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        else
            controller.Move(new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")));
    }

}