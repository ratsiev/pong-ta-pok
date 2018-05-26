using System;
using UnityEngine;

public class Ball : MonoBehaviour {

    public event Action<GameObject> TouchedWall;
    public event Action<GameObject> PassedThroughRing;
    public event Action StoppedMoving;

    private readonly float speed = 5f;
    private Rigidbody2D rig;
    private GameObject lastPlayer;

    void Awake() {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!IsMoving() && lastPlayer) {
            StoppedMoving();
            Destroy(gameObject);
        }
    }

    public bool IsMoving() {
        return !rig.IsSleeping();
    }

    public bool MovingRight() {
        return rig.velocity.x > 0;
    }

    public bool MovingUp() {
        return rig.velocity.y > 0;
    }

    public void Serve(Vector3 target) {
        rig.velocity = (target - transform.position).normalized * speed;
    }

    public bool OnRightSide() {
        return transform.position.x > GameObject.FindGameObjectWithTag("MiddleLine").transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Bumper>())
            lastPlayer = collision.gameObject;
        if (collision.gameObject.tag == "OuterWall")
            TouchedWall(lastPlayer);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ring" && GotThroughRing(collision.bounds))
            PassedThroughRing(lastPlayer);
    }

    private bool GotThroughRing(Bounds ringBounds) {
        Bounds ball = GetComponent<CircleCollider2D>().bounds;
        ringBounds = new Bounds(ringBounds.center, new Vector3(0.1f, ringBounds.size.y, ringBounds.size.z));
        return (ball.max.y < ringBounds.max.y && ball.min.y > ringBounds.min.y) && (ball.center.x > ringBounds.center.x || ball.center.x < ringBounds.center.x);
    }

}
