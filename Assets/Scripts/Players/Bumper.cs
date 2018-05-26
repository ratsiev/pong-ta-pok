using System;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public event Action<GameObject> TouchedMiddleLine;

    protected BumperController controller;
    protected GameObject middleLine;

    protected virtual void Start() {
        if (!middleLine)
            middleLine = GameObject.FindGameObjectWithTag("MiddleLine");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        TouchedMiddleLine(gameObject);
    }

}
