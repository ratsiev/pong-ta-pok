using System;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public event Action<GameObject> TouchedMiddleLine;
    public event Action TouchedBall;
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
        controller = GetComponent<BumperController>();
    }

    void Update() {
        if (isBumpOne)
            controller.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        else
            controller.Move(new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")));
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag=="Ball")
            TouchedBall();
    }

    public virtual void DisableBumper() {
        controller.rig.velocity = Vector3.zero;
        controller.rig.position = initialPosition;
        enabled = false;
    }

}
