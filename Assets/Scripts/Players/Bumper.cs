using System;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public event Action<GameObject> TouchedMiddleLine;
    [HideInInspector] public bool isBumpOne;
    protected BumperController controller;
    protected GameObject middleLine;

    protected virtual void Start() {
        if (!middleLine)
            middleLine = GameObject.FindGameObjectWithTag("MiddleLine");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isBumpOne) {
            if (transform.position.x <= middleLine.transform.position.x)
                TouchedMiddleLine(gameObject);
        } else {
            if (transform.position.x >= middleLine.transform.position.x)
                TouchedMiddleLine(gameObject);
        }
    }

}
