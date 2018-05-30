using System;
using UnityEngine;

public class Ball : MonoBehaviour {

    public event EventHandler<BallEventArgs> PassedThroughRing;
    public event EventHandler<BallEventArgs> StoppedMoving;

    private readonly float speed = 5f;
    private Rigidbody2D rig;
    private GameObject lastPlayer;
    private Vector3 initialPosition;
    private Score score;

    void Awake() {
        rig = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        lastPlayer = GameObject.FindGameObjectWithTag("PlayerOne");
    }

    void Start() {
        score = FindObjectOfType<Score>();
        score.MaxScoreReached += Score_MaxScoreReached;
    }

    private void Score_MaxScoreReached(string obj) {
        rig.position = initialPosition;
        rig.Sleep();
    }

    private void Update() {
        if (!IsMoving())
            StoppedMoving?.Invoke(gameObject, new BallEventArgs(lastPlayer, transform.position.x));
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
        rig.position = initialPosition;
        rig.velocity = (target - initialPosition).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Bumper>())
            lastPlayer = collision.gameObject;
        if (collision.gameObject.tag == "OuterWall") {
            rig.velocity = Vector3.zero;
            rig.angularVelocity = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ring" && GotThroughRing(collision.bounds))
            PassedThroughRing?.Invoke(gameObject, new BallEventArgs(lastPlayer, transform.position.x));
    }

    private bool GotThroughRing(Bounds ringBounds) {
        Bounds ball = GetComponent<CircleCollider2D>().bounds;
        ringBounds = new Bounds(ringBounds.center, new Vector3(0.1f, ringBounds.size.y, ringBounds.size.z));
        return (ball.max.y < ringBounds.max.y && ball.min.y > ringBounds.min.y) && (ball.center.x > ringBounds.center.x || ball.center.x < ringBounds.center.x);
    }


}
