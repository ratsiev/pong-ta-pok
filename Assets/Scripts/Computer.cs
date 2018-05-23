using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour {

    private BumperController controller;

    private void Awake() {
        controller = GetComponent<BumperController>();
    }

}
