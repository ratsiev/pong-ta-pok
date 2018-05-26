using UnityEngine;

public class Bumper : MonoBehaviour {

    protected BumperController controller;
    protected GameObject middleLine;

    protected virtual void Start() {
        if (!middleLine)
            middleLine = GameObject.FindGameObjectWithTag("MiddleLine");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // opponent gains a point
    }

}
