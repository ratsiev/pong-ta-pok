using System;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public event Action<GameObject> TouchedMiddleLine;
    [HideInInspector] public bool isBumpOne;
    protected BumperController controller;
    protected GameObject middleLine;
    [HideInInspector] public Vector3 initialPosition;

    private void Awake() {
        initialPosition = transform.position;
    }
    protected virtual void Start() {
        if (!middleLine)
            middleLine = GameObject.FindGameObjectWithTag("MiddleLine");      
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isBumpOne) {
            if (transform.position.x <= middleLine.transform.position.x)
                TouchedMiddleLine?.Invoke(gameObject);
        } else {
            if (transform.position.x >= middleLine.transform.position.x)
                TouchedMiddleLine?.Invoke(gameObject);
        }
    }

    public virtual void ResetBumper(bool enable) {
        controller.rig.velocity = Vector3.zero;
        controller.rig.position = initialPosition;
    }

}
